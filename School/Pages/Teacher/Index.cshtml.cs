using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace School.Pages.Teacher
{
    public class IndexModel : PageModel
    {

        public List<Teacher> listTeachers = new List<Teacher>();
        public void OnGet()
        {
            try
            {
                String connString = "Data Source=EDY88\\SQLEXPRESS02;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM teacher";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Teacher teacher = new Teacher();
                                teacher.TeacherId = "" + reader.GetInt32(0);
                                teacher.Name = reader.GetString(1);
                                teacher.Age = "" + reader.GetInt32(2);
                                teacher.Sex = reader.GetString(3);
                                teacher.Email = reader.GetString(4);
                                teacher.Discipline = reader.GetString(5);

                                listTeachers.Add(teacher);
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
    }

    public class Teacher
    {
        public string? TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public string? Discipline { get; set; }

    }

}
