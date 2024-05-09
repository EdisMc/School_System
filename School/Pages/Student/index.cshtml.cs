using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace School.Pages.Student
{
    public class indexModel : PageModel
    {
        public List<Student> listStudents = new List<Student>();
        public void OnGet()
        {
            try
            {
                String connString = "Data Source=EDY88\\SQLEXPRESS02;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM student";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student();
                                student.StudentId = "" + reader.GetInt32(0);
                                student.Name = reader.GetString(1);
                                student.Age = "" + reader.GetInt32(2);
                                student.Sex = reader.GetString(3);
                                student.Email = reader.GetString(4);
                                student.Grade = reader.GetString(5);

                                listStudents.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());

            }
        }

        public class Student
        {
            public string? StudentId { get; set; }
            public string? Name { get; set; }
            public string? Age { get; set; }
            public string? Sex { get; set; }
            public string? Email { get; set; }
            public string? Grade { get; set; }

        }
    }

}
