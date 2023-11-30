using purebaTecnicaQualityCode.Models.DTOs;

namespace purebaTecnicaQualityCode.Services.Interfaces
{
    public interface IHorarioService
    {

        bool Cargarhorarios(List<Cita> citas);
        int ConsultaEspacios(consultaDto data);
    }
}
