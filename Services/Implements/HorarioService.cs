using purebaTecnicaQualityCode.Models;
using purebaTecnicaQualityCode.Models.DTOs;
using purebaTecnicaQualityCode.Services.Interfaces;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace purebaTecnicaQualityCode.Services.Implements
{
    public class HorarioService : IHorarioService
    {
        private List<CitaInterna> ListadoCitas = new List<CitaInterna>();

        public bool Cargarhorarios(List<Cita> citas)
        {
            try
            {
                foreach (var cita in citas)
                {
                    var citaInterna = new CitaInterna()
                    {
                        Day = seleccionDia(cita.Day),
                        Duration = Convert.ToInt32(cita.Duration),
                        Hour = TimeOnly.FromTimeSpan(DateTime.ParseExact(cita.Hour, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
                    };
                    ListadoCitas.Add(citaInterna);
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }

        public int ConsultaEspacios(consultaDto data)
        {
            var citas = ListadoCitas.Where(x => x.Day == data.dia).OrderBy(x => x.Hour).ToList();
            // El horario de atención del sistema se encuentra entre las 9:00 y las 17:00 horas
            var horaInicial = new TimeOnly(9, 0);
            var horaFinal = new TimeOnly(17, 0);
            var cursor = new TimeOnly(9, 0);
            var minutosMinimos = 30;
            var espaciosDisponibles = 0;

            while (cursor < horaFinal)
            {

                var citaTmp = citas.FirstOrDefault(x =>
                (cursor < x.HoraFin && cursor.AddMinutes(minutosMinimos) > x.Hour)
                ||
                (x.Hour < cursor.AddMinutes(minutosMinimos) && x.HoraFin > cursor)
                );

                if (citaTmp != null)

                {

                    cursor = citaTmp.HoraFin;
                }
                else
                {
                    espaciosDisponibles++;
                    cursor = cursor.AddMinutes(minutosMinimos);
                }
            }
            return espaciosDisponibles;
        }

        private int seleccionDia(string dia)
        {
            switch (dia)
            {
                case "lunes":
                    return 1;
                case "martes":
                    return 2;
                case "miércoles":
                    return 3;
                case "jueves":
                    return 4;
                case "viernes":
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
