using AutoMapper;


namespace EmailSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailerController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mapper;
    private readonly EmailService _emailService;


    public MailerController(Context context, IMapper mapper, EmailService emailService)
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
    }

    [HttpPost("Snimi")]
    [SwaggerResponse(StatusCodes.Status200OK, "Uspesno snimljen mail.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Greska pri snimanju.")]
    public async Task<IActionResult> SnimiAsync([FromBody] MailDefinitionDTO dto)
    {
        try
        {
            var mailDefinition = _mapper.Map<MailDefinition>(dto);

            _context.MailDefinitions.Add(mailDefinition);
            await _context.SaveChangesAsync();

           
            await _emailService.PosaljiEmailAsync(mailDefinition.MailDefinitionCore.Subject,
                                           mailDefinition.MailDefinitionCore.To,
                                           mailDefinition.MailDefinitionCore.From!,
                                           mailDefinition.MailDefinitionCore.ContentText!);

            return Ok("Uspesno ste snimili podatke o mail-u koji treba biti poslat");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        } 
    }

    //[HttpPost("Posalji Email")]
    //[SwaggerResponse(StatusCodes.Status200OK, "Uspesno poslat mail.")]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, "Greska pri slanju.")]

    //public async Task<IActionResult> PosaljiEmailAsync([FromQuery,Required]string subject,  
    //                                                   [FromQuery, Required] string toEmail, 
    //                                                   [FromQuery, Required] string username, 
    //                                                   [FromQuery, Required] string message)
    //{
    //    try
    //    {
    //        //if (subject == null || toEmail == null || username == null || message == null)
    //        //{
    //        //    return BadRequest("Niste uneli sve podatke");
    //        //}
    //        await _emailService.PosaljiEmailAsync(subject, toEmail, username, message);
    //        return Ok("Mail je poslat");
    //    }
    //    catch (Exception)
    //    {
    //        return BadRequest("Greska pri slanju");
    //    }
    //}
}
