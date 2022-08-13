namespace User_DLL.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }//账号
        public string UserPwd { get; set; }
        public string IDCard { get; set; }//身份证号
        public bool Gender { get; set; }//0 男 1 女
        public string PhoneNumber { get; set; }//电话号码
        public string AddressDetail { get; set; }//地址
        public string CurrentUnit { get; set; }
        public string Remarks { get; set; }
        public List<CheckRecord> CheckRecords { get; set; }
    }
}