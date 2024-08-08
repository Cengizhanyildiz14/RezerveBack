namespace Entity
{
    public class Duyuru : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } // Duyurunun başlığı
        public string Content { get; set; } // Duyurunun içeriği
        public DateTime CreatedAt { get; set; } // Duyurunun oluşturulma tarihi
    }
}
