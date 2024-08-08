namespace Dtos
{
    public class AppointmentCreateDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string ActivityName { get; set; }
        public string? QRCodeUrl { get; set; }
    }
}
