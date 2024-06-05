using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ProjectGym.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string conString = @"Data Source=MALEEK\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True;";
        public string message = "";
        Contact contact = new Contact();
        public void OnPost()
        {
            messageSend();
        }

        public void messageSend()
        {
            try
            {
                //getting from form
                contact.name = Request.Form["name"];
                contact.email = Request.Form["email"];
                contact.subject = Request.Form["subject"];
                contact.message = Request.Form["message"];
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string qry = "INSERT INTO contact (name,email,subject,message) VALUES (@v_name,@v_email,@v_subject,@v_message)";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@v_name", contact.name);
                        cmd.Parameters.AddWithValue("@v_email", contact.email);
                        cmd.Parameters.AddWithValue("@v_subject", contact.subject);
                        cmd.Parameters.AddWithValue("@v_message", contact.message);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Your Message Has been Sent";
                        }
                        else
                        {
                            message = "Your Message Has Not been Sent";
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
    }
    public class Contact
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
    }
}
