using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace LootSystem
{
    public partial class LogIn : Form
    {
        public string GuildName;
        public string Password;
        public LootSystem lootsie;
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            GuildName = GuildNameTxt.Text;
            Password = PasswordTxt.Text;
            string connectionString = "database="+GuildName+";server=localhost;uid= postgres;pwd=" + Password;
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    lootsie = new LootSystem(connectionString);
                    lootsie.Show();

                    this.Hide();
                }
                catch (NpgsqlException ex)
                {
                    if (ex.Message == "28P01: password authentication failed for user \"postgres\"")
                    {
                        Debug.WriteLine(ex.Message);
                        MessageBox.Show("Check Your Password!!");
                    }
                    else if (ex.Message == "3D000: database \"" + GuildName + "\" does not exist")
                        Debug.WriteLine(ex.Message);               
                        
                }
                
            }
        }
    }
}
