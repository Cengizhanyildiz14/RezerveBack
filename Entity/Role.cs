namespace Entity
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
