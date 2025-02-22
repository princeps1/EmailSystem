
namespace EmailSystem.Controllers;

[Route("api/")]
[ApiController]
public class LogController : ControllerBase
{
    private const string path = "./Logs";
    private readonly IWebHostEnvironment _env;
    private readonly IFileProvider _fileProvider;
    private readonly ILogger<LogController> _logger;
    private readonly IFileService _fileService;

    public LogController(IWebHostEnvironment env, ILogger<LogController> logger,IFileService fileService)
    {
        _env = env;
        _fileProvider = env.ContentRootFileProvider; 
        _logger = logger;
        _fileService = fileService;
    }


    [HttpGet("Get")]
    [Produces("application/xml", "application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, "Uspesno prikazani svi fajlovi.")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Folder ne sadrzi fajlove.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Folder ne postoji.")]
    public IActionResult Get([FromQuery,DataType(DataType.Date)] DateTime? startDate,
                             [FromQuery, DataType(DataType.Date)] DateTime? endDate)
    {
        try
        {
            _logger.LogInformation("Metoda za prikaz svih fajlova je startovana....");

            var directoryContents = _fileProvider.GetDirectoryContents(path);

            var files = directoryContents.Where(c => !c.IsDirectory &&
                                                (startDate == null || c.LastModified >= startDate) &&
                                                (endDate == null || c.LastModified <= endDate))
                                         .Select(c => c.Name).ToList();

            if (!files.Any())
            {
                return NotFound("Folder ne postoji ili je prazan.");
            }

            _logger.LogInformation("Metoda za prikaz svih fajlova je zavrsena....");
            return Ok(files);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Doslo je do greske u metodi Get.");
            return StatusCode(500, "Doslo je do greske prilikom obrade.");
        }
    }



    [HttpGet("Download")]
    [SwaggerResponse(StatusCodes.Status200OK, "Fajl je uspesno preuzet.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Fajl sa zadatim imenom nije pronadjen.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Ime fajla nije uneto ili je neispravno.")]
    public IActionResult Download([FromQuery,
                                   Required,
                                   StringLength(255)] 
                                   string fileName)
    {
        try
        {
            _logger.LogInformation("Metoda za download specificiranog fajla je startovana....");


            var content = _fileProvider.GetDirectoryContents(path);
            var file = content.FirstOrDefault(f => f.Name == fileName && !f.IsDirectory);

            if (file == null)
            {
                return NotFound("Fajl nije pronadjen.");
            }


            using (var stream = file.CreateReadStream())
            {
                var memory = new MemoryStream();
                stream.CopyTo(memory);
                memory.Position = 0; 

                var contentType = "application/octet-stream";

                _logger.LogInformation("Metoda za download specificiranog fajla je zavrsena....");
                return File(memory, contentType, file.Name);  
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Doslo je do greske prilikom prikaza fajlova.");
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("Delete")]
    [SwaggerResponse(StatusCodes.Status200OK, "Fajl je uspesno obrisan.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Fajl sa zadatim imenom nije pronadjen.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Ime fajla nije uneto ili je neispravno.")]
    public IActionResult Delete([FromQuery,
                                   Required,
                                   StringLength(255)]
                                   string fileName)
    {
        try
        {
            _logger.LogInformation("Metoda za delete specificiranog fajla je startovana....");


            var fullPath = Path.Combine(path, fileName);
            var file = _fileProvider.GetFileInfo(fullPath);

            if (file.Exists && !string.IsNullOrEmpty(file.PhysicalPath))
            {
                System.IO.File.Delete(file.PhysicalPath!);
                _logger.LogInformation($"Fajl '{fileName}' je uspesno obrisan.");
                return Ok("Fajl je uspesno obrisan.");
            }
            else
            {
                _logger.LogWarning($"Fajl sa imenom '{fileName}' nije pronadjen.");
                return NotFound("Fajl nije pronadjen.");
            }


        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Doslo je do greske prilikom brisanja fajla.");
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("UploadFiles")]
    [SwaggerResponse(StatusCodes.Status200OK, "Fajl je uspešno sačuvan.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Fajl nije upload-ovan.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Došlo je do greske.")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> uploadedFiles)
    {
        try
        {
            _logger.LogInformation("Metoda za upload fajla je startovana....");

            if (uploadedFiles == null || uploadedFiles.Count() == 0)
            {
                return BadRequest("Nijedan fajl nije upload-ovan");
            }
                

            int filesUploaded = 0;
            int filesLengthZero = 0;
            int filesAlreadyExists = 0;
            int filesWithError = 0;

            foreach (var file in uploadedFiles)
            {
                if (file.Length == 0)
                {
                    filesLengthZero++;
                    continue;
                }

                var fullPath = Path.Combine(path, file.FileName);
                var fileInfo = _fileProvider.GetFileInfo(fullPath);

                if (fileInfo.Exists && !string.IsNullOrEmpty(fileInfo.PhysicalPath))
                {
                    filesAlreadyExists++;
                    continue;
                }

                try
                {
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    await file.CopyToAsync(stream);

                    filesUploaded++;
                }
                catch (Exception ex)
                {
                    filesWithError++;
                    _logger.LogError(ex, $"Greska prilikom cuvanja fajla: {file.FileName}");
                }
            }

            _logger.LogInformation($"Upload zavrsen: {filesUploaded} fajlova uspesno, {filesAlreadyExists} vec postoji, {filesLengthZero} je bilo prazno, {filesWithError} je imalo error");
            return Ok(new
            {
                Message = "Upload zavrsen.",
                FilesUploaded = filesUploaded,
                FilesAlreadyExists = filesAlreadyExists,
                FilesLengthZero = filesLengthZero,
                FilesWithError = filesWithError
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Doslo je do greske prilikom upload-a fajla.");
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("ProcesFile")]
    [SwaggerResponse(StatusCodes.Status200OK, "Fajl je uspesno obradjen.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Fajl sa zadatim imenom nije pronadjen.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Ime fajla nije uneto ili je neispravno.")]
    public IActionResult ProcesFile([FromQuery ,Required,StringLength(255)] string fileName,
                                    [FromQuery] string? returnOnlyThisLevel)
    {
        try
        {
            _logger.LogInformation("Metoda za procesiranje fajla je startovana....");
            var fullPath = Path.Combine(path, fileName);
            var fileInfo = _fileProvider.GetFileInfo(fullPath);

            if (!fileInfo.Exists)
            {
                return NotFound("Fajl nije pronadjen.");
            }

            using (var fileStream = fileInfo.CreateReadStream())
            {
                if (fileStream == null || fileStream.Length == 0)
                {
                    return BadRequest("Fajl je prazan ili nije validan.");
                }


                //var result = _fileService.ProcessFile(fileStream);
                var result = _fileService.ProcessFileAsString(fileStream,returnOnlyThisLevel!);

                
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Doslo je do greske prilikom procesiranja fajla.");
            return BadRequest(ex.Message);
        }
    }
}


