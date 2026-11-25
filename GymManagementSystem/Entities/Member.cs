namespace GymManagementSystem.Entities
{
    public class Member : GymUser
    {
        public string? Photo {  get; set; }
        public ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();
    }
}
