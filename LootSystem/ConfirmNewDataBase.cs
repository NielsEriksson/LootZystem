using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace LootSystem
{
    public partial class ConfirmNewDataBase : Form
    {
        public string connectionString;
        public string connectionStringToMain;
        public string guildName;
        
        public ConfirmNewDataBase(string connectionStringToMain, string guildName, string Password)
        {
            InitializeComponent();            
            this.guildName = guildName;
            GuildNameTxt.Text = guildName;
            this.connectionStringToMain= connectionStringToMain;
            this.connectionString = "database=postgres;server=localhost;uid= postgres;pwd=" + Password;
        }

        private void CreateGuildBtn_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("CREATE DATABASE \""+ guildName+ "\" WITH OWNER = postgres  CONNECTION LIMIT = -1", con);
            cmd.ExecuteNonQuery();
            con.Close();
            NpgsqlConnection con2 = new NpgsqlConnection(connectionStringToMain);
            con2.Open();
            cmd = new NpgsqlCommand("CREATE TABLE  public.\"PlayersData\" (character TEXT PRIMARY KEY NOT NULL, hands BOOLEAN NOT NULL , chest BOOLEAN NOT NULL," +
                " shoulders BOOLEAN NOT NULL,head BOOLEAN NOT NULL,legs BOOLEAN NOT NULL," +
                "tierscore INTEGER NOT NULL, class TEXT NOT NULL, role TEXT NOT NULL, type TEXT NOT NULL," +
                "lootscore INTEGER DEFAULT 0, attendance INTEGER NOT NULL DEFAULT 0)",con2);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("CREATE TABLE  public.\"PlayersILVL\" (character TEXT PRIMARY KEY NOT NULL, chestilvl INTEGER , shouldersilvl INTEGER," +
               " headilvl INTEGER, legsilvl INTEGER, handsilvl INTEGER, ilvldifference INTEGER )",con2);
            cmd.ExecuteNonQuery();
             con2.Close();
            LootSystem lootsie = new LootSystem(connectionStringToMain);
            foreach (Form f in Application.OpenForms)
            {
                f.Hide();
            }
           
            lootsie.Show();
            

        }
    }
}
