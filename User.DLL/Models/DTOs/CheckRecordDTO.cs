namespace User_DLL.Models.DTOs
{
    public class CheckRecordDTO:BaseEntity
    {
        public bool IsDanger { get; set; }
        public string IDCard { get; set; }//身份证号

    }
}
