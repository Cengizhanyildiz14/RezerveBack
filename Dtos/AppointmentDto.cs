namespace Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } // Randevu saati
        public string ActivityName { get; set; } // Aktivite adı
        public string QRCodeUrl { get; set; }
        public string Gender { get; set; }
    }
}
