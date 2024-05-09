using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace School.Pages.Teacher
{
    public class CreateModel : PageModel
    {
        public Teacher teacher = new Teacher();
        public String error = "";
        public String success = "";
        public void OnGet()
        {
        }

        public void onPost()
        {
            teacher.Name = Request.Form["name"];
            teacher.Age = Request.Form["age"];
            teacher.Sex = Request.Form["age"];
            teacher.Email = Request.Form["email"];
            teacher.Discipline = Request.Form["discipline"];

            if (teacher.Name.Length == 0 || teacher.Age.Length == 0 ||
                teacher.Sex.Length == 0 || teacher.Email.Length == 0 ||
                teacher.Discipline.Length == 0)
            {
                error = "All field are required!";
                return;
            }

            teacher.Name = ""; teacher.Age = ""; teacher.Sex = "";
            teacher.Email = ""; teacher.Discipline = "";

            success = "New Teacher Added Successfully!";
        }
    }
}
