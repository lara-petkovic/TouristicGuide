using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace TouristicGuide.Pages.Guides
{
    public class IndexModel : PageModel
    {
        public List<GuideInfo> Guides = new List<GuideInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=LARA\\TESTSERVER;Initial Catalog=guideDatabase;Integrated Security=True";

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM guides";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                GuideInfo guideInfo = new GuideInfo();
                                guideInfo.Username = reader.GetString(0);
                                guideInfo.FirstName = reader.GetString(1);
                                guideInfo.LastName = reader.GetString(2);
                                guideInfo.Email = reader.GetString(3);
                                guideInfo.Birthday = reader.GetDateTime(4);
                                guideInfo.Phone = reader.GetString(5);
                                guideInfo.Languages = reader.GetString(6);

                                Guides.Add(guideInfo);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine("Exception: " + ex.ToString());
            }

        }
    }

    public class GuideInfo 
    {
        public String Username;
        public String FirstName;
        public String LastName;
        public String Email;
        public DateTime Birthday;
        public String Phone;
        public String Languages;
    }

}
