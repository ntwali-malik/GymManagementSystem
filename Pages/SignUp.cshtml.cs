using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ProjectGym.Pages.Authentication
{
    public class SignUpModel : PageModel
    {

        public string conString = @"Data Source=MALEEK\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True;";
        public string message = "";
        SignUp signUp = new SignUp();
        public void OnPost()
        {
            SignUpSend();
        }

        public void SignUpSend()
        {
            try
            {
                //getting from form
                signUp.firstname = Request.Form["firstname"];
                signUp.lastname = Request.Form["lastname"];
                signUp.email = Request.Form["email"];
                signUp.pass = Request.Form["pass"];
                signUp.phone = Request.Form["phone"];
                signUp.role = Request.Form["role"];
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string qry = "INSERT INTO account (firstname,lastname,email,pass,phone,role) VALUES (@v_firstname,@v_lastname,@v_email,@v_pass,@v_phone,@v_role)";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@v_firstname", signUp.firstname);
                        cmd.Parameters.AddWithValue("@v_lastname", signUp.lastname);
                        cmd.Parameters.AddWithValue("@v_email", signUp.email);
                        cmd.Parameters.AddWithValue("@v_pass", Hash(signUp.pass));
                        cmd.Parameters.AddWithValue("@v_phone", signUp.phone);
                        cmd.Parameters.AddWithValue("@v_role", signUp.role);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Account Created";
                            Response.Redirect("/Login");
                        }
                        else
                        {
                            message = "Account Not Created";
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

        //Hashing codes
        private String Hash(string secretPassword)
        {
            byte[] buffer = Encoding.Default.GetBytes(secretPassword);
            HashAlgorithm hashAlgorithm = MD5CryptoServiceProvider.Create();
            byte[] hashBuffer = hashAlgorithm.ComputeHash(buffer);
            string hashedPwd = BitConverter.ToString(hashBuffer);
            return hashedPwd.Replace("*", "");
        }

    }
    public class SignUp
    {
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string? pass { get; set; }
        public string? phone { get; set; }
        public string? role { get; set; }
    }
}
