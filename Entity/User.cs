namespace Entity
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Gender { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
