namespace EmailSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailerController : ControllerBase
{
    private readonly Context _context;
    public MailerController(Context con) 
    {
        _context = con;
    }
    
    [HttpPost("Snimi")]
    [SwaggerResponse(StatusCodes.Status200OK, "Uspesno snimljen fajl.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Greska sa snimanjem.")]
    public async Task<IActionResult> Snimi([FromBody] string value)
    {
        try
        {
            return Ok("Sve u redu");
        }
        catch (Exception)
        {

            throw;
        }
    }

}
