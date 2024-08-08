namespace Dtos
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; } // Kullanıcının rol adı
        public string Gender { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
