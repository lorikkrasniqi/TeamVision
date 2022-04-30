namespace VisionStore.Models
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }  

        public ICollection<User> users { get; set; }
        
    }
}
