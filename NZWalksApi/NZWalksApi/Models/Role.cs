namespace NZWalksApi.Models
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public List<User_Role> UserRoles { get; set; }
    }
}
