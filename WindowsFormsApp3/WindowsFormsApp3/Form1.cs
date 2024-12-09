using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        // Bağlantı dizesi
        private string connectionString = "Server=127.0.0.1;Database=petrol;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {

            // ListBox'ı temizle
            workers.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NAME , SURNAME , WAGE  FROM workers";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // name ve surname değerlerini birleştirip ListBox'a ekle
                        string fullName = $"{reader["NAME"]} {reader["SURNAME"]}";
                        workers.Items.Add(fullName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
