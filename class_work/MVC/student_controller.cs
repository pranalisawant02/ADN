
public class StudentController : Controller
{
    //Action method : is a method inside controller which handles user request and return response
    public ActionResult Index()
    {
        //Creating a list of students
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Pranali",course="MCA"},
            new Student { Id = 2, Name = "Sanika",course="MCA"},
            new Student { Id = 3, Name = "Prachi",course="MCA"}
        };

    }
}