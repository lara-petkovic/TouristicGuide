using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TouristicGuide.Pages.Guides
{
    public class CreateModel : PageModel
    {
        public GuideInfo GuideInfo = new GuideInfo();
        public String ErrorMessage = "";
        public void OnGet()
        {

        }

       public void OnPost()
       {
            GuideInfo.Username = Request.Form["username"];
            GuideInfo.FirstName = Request.Form["firstName"];
            GuideInfo.LastName = Request.Form["lastName"];

            if (GuideInfo.Username.Length == 0 || GuideInfo.FirstName.Length == 0 || GuideInfo.LastName.Length == 0)
            {
                ErrorMessage = "First three fields are required!";
                return;
            }

            GuideInfo.Email = Request.Form["email"];
            GuideInfo.Birthday = Convert.ToDateTime(Request.Form["birthday"]);
            GuideInfo.Phone = Request.Form["phone"];
            GuideInfo.Languages = Request.Form["languages"];



            try
            {
                String connectionString = "Data Source=LARA\\TESTSERVER;Initial Catalog=guideDatabase;Integrated Security=True";
                using(SqlConnection connection =  new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO guides" +
                                 "(Username, FirstName, LastName, Email, Birthday, Phone, Languages) VALUES" +
                                 "(@username, @firstName, @lastName, @email, @birthday, @phone, @languages);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", GuideInfo.Username);
                        command.Parameters.AddWithValue("@firstName", GuideInfo.FirstName);
                        command.Parameters.AddWithValue("@lastName", GuideInfo.LastName);
                        command.Parameters.AddWithValue("@birthday", GuideInfo.Birthday);
                        command.Parameters.AddWithValue("@email", GuideInfo.Email);
                        command.Parameters.AddWithValue("@phone", GuideInfo.Phone);
                        command.Parameters.AddWithValue("@languages", GuideInfo.Languages);

                        command.ExecuteNonQuery();
                    }
                }
                Response.Redirect("/Guides/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return;
            }

       }
    }
}
