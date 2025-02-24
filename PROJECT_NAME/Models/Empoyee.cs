namespace PROJECT_NAME.Models;
public class Employee : Person
{
    public required string EmployeeId { get; set; }
    public int Age { get; set; }
}