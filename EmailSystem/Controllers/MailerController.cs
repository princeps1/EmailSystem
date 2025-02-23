using AutoMapper;


namespace EmailSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailerController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;


    public MailerController(Context context, IMapper mapper, IEmailService emailService)
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
    }

    [HttpPost("Snimi")]
    [SwaggerResponse(StatusCodes.Status200OK, "Uspešno snimljen fajl.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Greška pri snimanju.")]
    public async Task<IActionResult> Snimi([FromBody] MailDefinitionDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var mailDefinition = _mapper.Map<MailDefinition>(dto);

        _context.MailDefinitions.Add(mailDefinition);
        await _context.SaveChangesAsync();

        return Ok("Uspesno ste snimili podatke o mail-u koji treba biti poslat");
    }

    [HttpPost("Posalji Email")]
    public async Task<IActionResult> PosaljiEmailAsync(string subject, string toEmail, string username, string message)
    {
        if (subject == null || toEmail == null || username == null || message == null)
        {
            return BadRequest("Niste uneli sve podatke");
        }
        await _emailService.PosaljiEmailAsync(subject, toEmail, username, message);
        return Ok("Mail je poslat");
    }
}
