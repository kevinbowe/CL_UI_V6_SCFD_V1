namespace CL_UI_V6_SCFD_V1;
using System.Reflection;
using System.Text;
public class Person
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SSN { get; set; }
    public DateTime InsertDte_sys { get; set; }
    public DateOnly doB_sys { get; set; }
    public TimeOnly WorkStartsAt_sys { get; set; } = new TimeOnly(8,0,0);
    public DateTimeOffset CurrentTime_sys { get; set; }
}
public class PersonResponse : Person {
	public System.Net.HttpStatusCode? ResponseCode {get; set;} = null;

	public string? ResponseMessage {get; set;} = null;
	
	public Person? Person {get; set;} = null;
}
public class PersonListResponse : Person {
	public System.Net.HttpStatusCode? ResponseCode {get; set;} = null;

	public string? ResponseMessage {get; set;} = null;
	
	public List<Person>? PersonList {get; set;} = null;
}