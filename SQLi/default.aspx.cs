using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLi
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             *  CREATE TABLE users
                (
	                [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                    [username] VARCHAR(50) NOT NULL, 
                    [password] VARCHAR(50) NOT NULL, 
                    [role] VARCHAR(50) NOT NULL
                ) 
             * 
             */
        }

        protected void login(object sender, EventArgs e)
        {
            string username = usernameInput.Value;
            
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            string queryString = "SELECT * FROM users WHERE username= @Name;";

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add(new SqlParameter("Name", username));

                    SqlDataReader reader = command.ExecuteReader();

                    string data = "";

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string uname = reader.GetString(1);
                        string pword = reader.GetString(2);
                        string role = reader.GetString(3);

                        string formatedData = String.Format("ID: {0}\n" +
                            "Username: {1}\n" +
                            "Password: {2}\n" +
                            "Role: {3}\n", id, uname, pword, role);

                        data += formatedData;

                    }

                    if (data == "")
                        displayLabel.Text = "No User found!";
                    else
                        displayLabel.Text = data;

                    connection.Close();
                }
            } catch
            {
                displayLabel.Text = "There was an error! Please try agian...";
            }

        }
    }
}