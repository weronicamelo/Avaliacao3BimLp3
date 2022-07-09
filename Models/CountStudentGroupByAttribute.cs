 public class CountStudentGroupByAttribute
{
    public string AttributeName { get; set; }
    public int StudentNumber { get; set; }

    public CountStudentGroupByAttribute(){}

    public CountStudentGroupByAttribute(string attributeName, int studentNumber)
    {
        AttributeName = attributeName;
        StudentNumber = studentNumber;
    }
}