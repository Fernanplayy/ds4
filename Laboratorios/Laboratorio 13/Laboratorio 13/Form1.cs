using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            conexion.Close();
            MessageBox.Show("Se cerro la conexion");
        }
    }
}
