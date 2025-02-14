using AutoMapper;

namespace EmailSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailerController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mapper;

    public MailerController(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        return Ok("Uspesno ste snimili mail");
    }
}
