namespace User_DLL.Models
{
    public class CheckRecord:BaseEntity
    {
        public bool ResultType { get; set; }//0阳性 1阴性 
        public User User { get; set; }
        public int UserId { get; set; }
    }
}