using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Laboratorio_13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrio la conexion con el servidor SQL Server y se selecciono la base de datos");

            SqlCommand query = new SqlCommand("SELECT ProductName FROM [dbo].[Products]", conexion);
            SqlDataReader lector = query.ExecuteReader();

            while (lector.Read())
            {
                listBox1.Items.Add(lector["ProductName"].ToString());
            }

            lector.Close();
            conexion.Close();
            MessageBox.Show("Se cerro la conexion");

            

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
