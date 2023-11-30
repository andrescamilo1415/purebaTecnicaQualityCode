namespace purebaTecnicaQualityCode.Models
{
    public class CitaInterna
    {
        public int Day { get; set; }
        public TimeOnly Hour { get; set; }
        public int Duration { get; set; }

        public TimeOnly HoraFin { get {
                return Hour.AddMinutes(Duration); 
            } }

    }
}
