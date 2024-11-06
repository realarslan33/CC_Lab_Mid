using System.Text;
using System.Text.RegularExpressions;

namespace Lab_Mid__QuestionNo3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = "Haris";
            string lastName = "Shah";

            if (firstName.Length < 1 || lastName.Length < 1)
            {
                MessageBox.Show("Please enter your first and last name.");
                return;
            }

            // Create a StringBuilder to build the password
            StringBuilder password = new StringBuilder();

            // Add initials of first and last name
            password.Append(firstName[0]);
            password.Append(lastName[0]);

            // Generate random uppercase alphabet
            Random random = new Random();
            password.Append((char)random.Next('A', 'Z' + 1));

            // Generate 4 random numbers
            for (int i = 0; i < 4; i++)
            {
                password.Append((char)random.Next('0', '9' + 1));
            }

            // Generate 2 special characters
            string specialCharacters = "!@#$%^&*()_-+=<>?";
            for (int i = 0; i < 2; i++)
            {
                password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
            }

            // Shuffle the password characters for better security
            password = ShuffleString(password);

            // Limit the password to a maximum length of 16
            if (password.Length > 16)
            {
                password.Length = 16;
            }

            // Display the generated password
            label1.Text = password.ToString();
        }
        private StringBuilder ShuffleString(StringBuilder str)
        {
            Random random = new Random();
            int n = str.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                char value = str[k];
                str[k] = str[n];
                str[n] = value;
            }
            return str;
        }

    }
}