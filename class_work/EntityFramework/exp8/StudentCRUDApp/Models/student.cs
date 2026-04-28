using System.ComponentModel.DataAnnotations;

namespace StudentCRUDApp.Models
{
   public class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Course { get; set; } = string.Empty;
}
}