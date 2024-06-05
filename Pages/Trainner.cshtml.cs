using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ProjectGym.Pages
{
    public class TrainnerModel : PageModel
    {
        public string conString = @"Data Source=MALEEK\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True;";
        public List<Message> msgList = new List<Message>();
        public string message = "";

        public void DisplayBlogs()
        {
            try
            {
                // connection
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string qry = "SELECT id, name, email, subject,message FROM contact";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Message msg = new Message();
                                msg.id = Int32.Parse(reader["id"].ToString());
                                msg.name = reader["name"].ToString();
                                msg.email = reader["email"].ToString();
                                msg.subject = reader["subject"].ToString();
                                msg.message = reader["message"].ToString();
                                msgList.Add(msg);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
        public void OnGet()
        {
            DisplayBlogs();
        }
    }

    public class Message
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
    }
}
