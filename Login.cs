using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace SQLInjection
{
    public partial class Login : Form
    {
        bool hideForm = false;
        public Login()
        {
            InitializeComponent();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=Users.db;Version=3;"))
                {
                    string querry = "create table Users(name varchar(50), login varchar(30), password varchar(30))";
                    conn.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(querry, conn);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {

            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=Users.db;Version=3;"))
                {
                    string querry = "Select * from Users";
                    conn.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(querry, conn);
                    var reply = sqlCommand.ExecuteReader();
                    if (!reply.Read())
                    {
                        ProgrammForm form = new ProgrammForm();
                        hideForm = true;
                        form.Show();
                    }
                    conn.Close();
                }
            }
            catch( Exception ex) { }
        }

        private void enterToSystemButton_Click(object sender, EventArgs e)
        {
            if (hideForm)
                Hide();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=Users.db;Version=3;"))
            {
                string querry = "select * from Users where login = '" + loginTextBox.Text + "' and password = '" + passwordTextBox.Text + "'";
                conn.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(querry, conn);
                SQLiteDataReader reply = sqlCommand.ExecuteReader();
                if (reply.Read())
                {
                    ProgrammForm form = new ProgrammForm();
                    this.Hide();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь ненайден");
                }
                conn.Close();
            }
                
        }
    }
}
