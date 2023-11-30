using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using purebaTecnicaQualityCode.Models.DTOs;
using purebaTecnicaQualityCode.Services.Interfaces;

namespace purebaTecnicaQualityCode.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private IHorarioService horarioService;

        public AgendaController(IHorarioService horarioService)
        {
            this.horarioService = horarioService;
        }

     [Route("api/[controller]/[action]")]
        [HttpPost]
        public bool CargarDatos([FromBody] List<Cita> data)
        {
            return horarioService.Cargarhorarios(data);

        }

       [Route("api/[controller]/[action]")]
        [HttpPost]
        public int ConsultaEspacios([FromBody] consultaDto data)
        {
            return horarioService.ConsultaEspacios(data);

        }

    }
}
