namespace Login_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
            if (username == "Admin" && pass == "1234")
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Warning", MessageBoxButtons.OKCancel);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}