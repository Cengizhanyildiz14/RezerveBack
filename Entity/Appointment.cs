namespace Entity
{
    public class Appointment : IBaseEntity
    {
        public int Id { get; set; } // Randevu ID
        public DateTime Date { get; set; } // Randevu tarihi
        public string Time { get; set; } // Randevu saati
        public string ActivityName { get; set; } // Aktivite adı
        public int UserId { get; set; } // İlişkili kullanıcı ID
        public User User { get; set; } // İlişkili kullanıcı
        public string? QRCodeUrl { get; set; }
    }
}
