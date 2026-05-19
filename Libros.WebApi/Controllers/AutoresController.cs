using Libros.Entitties;
using Libros.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ILogger<Autor> _logger;
        private readonly IStringService _stringService;
        public AutoresController(ILogger<Autor> logger, IStringService stringService)
        {
            _logger = logger;
            _stringService = stringService;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok();
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? id)
        {
            //List<Autor> autores = GetAutores();
            Autor autor = new Autor();
            if (autor == null) { return BadRequest(); }
            else { return Ok(_stringService.GetCompleteName(autor.Nombre, autor.Apellido)); };
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            autor.Id = 4;
            return Created($"/api/ById?Id={autor.Id}", autor);
        }        
    }
}
