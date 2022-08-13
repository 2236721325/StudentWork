namespace User_DLL.Models
{
    public class CheckRecord:BaseEntity
    {
        public bool IsDanger { get; set; }//0阳性 1阴性 
        public User User { get; set; }
        public int UserId { get; set; }
        public string IDCard { get; set; }//身份证号

    }
}