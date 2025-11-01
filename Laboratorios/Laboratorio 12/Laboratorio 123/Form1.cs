namespace Laboratorio_123
{
    public partial class Form1 : Form
    {
        private float ladoA, ladoB, ladoC, semiperimetro;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcularSemiperimetro();
        }

        private void CalcularSemiperimetro()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, ingrese los tres lados del triángulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ladoA = float.Parse(textBox1.Text);
                ladoB = float.Parse(textBox2.Text);
                ladoC = float.Parse(textBox3.Text);

                if (ladoA <= 0 || ladoB <= 0 || ladoC <= 0)
                {
                    MessageBox.Show("Los lados del triángulo deben ser números positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ladoA + ladoB <= ladoC || ladoA + ladoC <= ladoB || ladoB + ladoC <= ladoA)
                {
                    MessageBox.Show("Los lados ingresados no forman un triángulo válido\n" + "La suma de dos lados debe ser mayor que el tercero.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                semiperimetro = (ladoA + ladoB + ladoC) / 2;
                textBox4.Text = semiperimetro.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Entrada inválida. Por favor, ingrese números válidos para los lados del triángulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox4.Clear();
            textBox5.Clear();

            textBox1.Focus();

            ladoA = ladoB = ladoC = semiperimetro = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalcularArea();
        }

        private void CalcularArea()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, ingrese los tres lados del triángulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ladoA = float.Parse(textBox1.Text);
                ladoB = float.Parse(textBox2.Text);
                ladoC = float.Parse(textBox3.Text);

                if (ladoA + ladoB <= ladoC || ladoA + ladoC <= ladoB || ladoB + ladoC <= ladoA)
                {
                    MessageBox.Show("Los lados ingresados no forman un triángulo válido.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double area = Math.Sqrt(semiperimetro * (semiperimetro - ladoA) * (semiperimetro - ladoB) * (semiperimetro - ladoC));
                textBox5.Text = area.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show($"Error al calcular el área", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
