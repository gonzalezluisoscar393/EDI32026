using AutoMapper;
using Libros.Application;
using Libros.Application.Dtos.Autor;
using Libros.Application.Dtos.Genero;
using Libros.Controllers;
using Libros.Entitties;
using Libros.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<AutoresController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Genero> _genero;
        private readonly IMapper _mapper;
        public GenerosController(IApplication<Genero> genero
            , ILogger<AutoresController> logger
            , IStringService stringService
            , IMapper mapper)
        {
            _genero = genero;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<GeneroResponseDto>>(_genero.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Genero genero = _genero.GetById(Id.Value);
            if (genero is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GeneroResponseDto>(genero));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GeneroRequestDto generoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var genero = _mapper.Map<Genero>(generoRequestDto);
            _genero.Save(genero);
            return Ok(genero.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, GeneroRequestDto generoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Genero generoBack = _genero.GetById(Id.Value);
            if (generoBack is null)
            { return NotFound(); }
            _mapper.Map(generoRequestDto, generoBack);
            _genero.Save(generoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Genero generoBack = _genero.GetById(Id.Value);
            if (generoBack is null)
            { return NotFound(); }
            _genero.Delete(generoBack.Id);
            return Ok();
        }
    }
}
