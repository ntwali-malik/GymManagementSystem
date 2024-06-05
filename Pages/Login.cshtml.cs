using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ProjectGym.Pages
{
    public class LoginModel : PageModel
    {
        private readonly string _connectionString = @"Data Source=MALEEK\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True;";

        [BindProperty]
        public MyData User { get; set; }

        public string ErrorMessage { get; private set; }

        public IActionResult OnPost()
        {
            // This method handles the HTTP POST request when the login form is submitted

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Prepare SQL command to select user based on email and password
                var sql = "SELECT * FROM account WHERE email = @Email AND pass = @Password";
                using (var command = new SqlCommand(sql, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Email", User.email);
                    command.Parameters.AddWithValue("@Password", Hash(User.pass));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Authentication successful
                            var roleFromDb = reader["role"].ToString();

                            // Determine user's role and redirect accordingly
                            switch (roleFromDb)
                            {
                                case "Admin":
                                    return RedirectToPage("/Admin"); // Redirect to admin page
                                case "Trainer":
                                    return RedirectToPage("/Trainner"); // Redirect to trainer page
                                case "Trainee":
                                    return RedirectToPage("/Member"); // Redirect to trainee page
                                default:
                                    // Unknown role, handle as needed
                                    ErrorMessage = "Unknown user role.";
                                    return Page();
                            }
                        }
                    }
                }
            }

            // Authentication failed
            ErrorMessage = "Invalid email or password.";
            return Page();
        }
        private String Hash(string secretPassword)
        {
            byte[] buffer = Encoding.Default.GetBytes(secretPassword);
            HashAlgorithm hashAlgorithm = MD5CryptoServiceProvider.Create();
            byte[] hashBuffer = hashAlgorithm.ComputeHash(buffer);
            string hashedPwd = BitConverter.ToString(hashBuffer);
            return hashedPwd.Replace("*", "");
        }
    }

    public class MyData
    {
        public string email { get; set; }
        public string pass { get; set; }
    }

}
