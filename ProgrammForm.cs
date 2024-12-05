using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLInjection
{
    public partial class ProgrammForm : Form
    {
        public ProgrammForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void save_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=Users.db;Version=3;"))
            {
                string querry = "insert into Users (name, login, password) values ('" + name.Text + "', '" + login.Text + "', '" + password.Text + "')";
                conn.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(querry, conn);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=Users.db;Version=3;"))
                {
                    string querry = textBox1.Text;
                    conn.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(querry, conn);
                    sqlCommand.ExecuteNonQuery();
                    label4.Text = "Затронуто " + conn.Changes + " строк";
                }
            }
            catch(Exception ex)
            {
                label4.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }
    }
}
