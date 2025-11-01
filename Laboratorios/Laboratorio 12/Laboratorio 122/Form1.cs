namespace Laboratorio_122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculoPromedio();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculoPromedio()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, ingrese todas las notas.", "Los datos estan incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                float nota1 = float.Parse(textBox1.Text);
                float nota2 = float.Parse(textBox2.Text);
                float nota3 = float.Parse(textBox3.Text);

                if (nota1 < 0 || nota1 > 100 || nota2 < 0 || nota2 > 100 || nota3 < 0 || nota3 > 100)
                {
                    MessageBox.Show("Las notas deben estar entre 0 y 100.", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float promedio = (nota1 + nota2 + nota3) / 3;
                textBox4.Text = promedio.ToString("F2");

                MostrarNota(promedio);


            }
            catch { }
        }

        private void MostrarNota(float promedio)
        {
            string calificacion = "";

            if (promedio >= 91) { calificacion = "Excelente A"; }
            else if (promedio >= 81) { calificacion = "Notable B"; }
            else if (promedio >= 71) { calificacion = "Bueno C"; }
            else if (promedio >= 61) { calificacion = "Suficiente D"; }
            else { calificacion = "Insuficiente F"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
