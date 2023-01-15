using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using Npgsql;
using System.Security.Claims;

namespace LootSystem
{
    public partial class Form1 : Form
    {
        public bool correctInfo;
        public NpgsqlCommand addPlayer;
        public NpgsqlCommand rollTier;
        public NpgsqlCommand updatePlayer;
        public NpgsqlCommand setAttendance;
        public NpgsqlCommand loadPlayers;
        public NpgsqlCommand selectSlots;
        public NpgsqlConnection con;
        NpgsqlDataReader dr;

        public Form1()
        {
            Cursor cur = new Cursor(Properties.Resources.Swordcursor2.Handle);
            this.Cursor = cur;            
            con = new NpgsqlConnection(@"Host = localhost; Database = LootSystem; Username = postgres;Password = Anders9898;Persist Security Info=True");
            InitializeComponent();
            con.Open();
            NpgsqlCommand LoadCharacters = new NpgsqlCommand("Select character From public.\"PlayersData\" ORDER BY \"character\" ASC ", con);
            dr = LoadCharacters.ExecuteReader();
            PlayerListText.Items.Clear();
            while (dr.Read())
            {
                PlayerListText.Items.Add(dr.GetValue(0));
                PlayerListText2.Items.Add(dr.GetValue(0));
                PlayerAttendanceList.Items.Add(dr.GetValue(0));
            }
            con.Close();
            LoadPlayers();
        }

        private void AddPlayerButtonClick_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CharacterText.Text) || String.IsNullOrEmpty(TierText.Text)
                || String.IsNullOrEmpty(ClassText.Text) || String.IsNullOrEmpty(RoleText.Text) || String.IsNullOrEmpty(TypeText.Text))
            {
                correctInfo = false;
            }
            else
            {
                correctInfo = true;
            }
            if (correctInfo)
            {
                con.Open();
                addPlayer = new NpgsqlCommand("INSERT INTO public.\"PlayersData\" VALUES(@Character,@Hands,@Chest,@Shoudlers, @Head,@Legs,@TierScore,@Class,@Role,@Type)", con);
                addPlayer.Parameters.AddWithValue("@Character", CharacterText.Text);
    
                addPlayer.Parameters.AddWithValue("@Hands", HandsBox.Checked);
                addPlayer.Parameters.AddWithValue("@Chest", ChestBox.Checked);
                addPlayer.Parameters.AddWithValue("@Shoudlers", ShoudlersBox.Checked);
                addPlayer.Parameters.AddWithValue("@Head", HeadBox.Checked);
                addPlayer.Parameters.AddWithValue("@Legs", LegsBox.Checked);
                addPlayer.Parameters.AddWithValue("@TierScore", int.Parse(TierText.Text));
                addPlayer.Parameters.AddWithValue("@Class", ClassText.Text);
                addPlayer.Parameters.AddWithValue("@Role", RoleText.Text);
                addPlayer.Parameters.AddWithValue("@Type", TypeText.Text);
                addPlayer.ExecuteNonQuery();
                addPlayer = new NpgsqlCommand("INSERT INTO public.\"PlayersILVL\" VALUES('" + CharacterText.Text + "') ", con);
                addPlayer.ExecuteNonQuery();
                con.Close();
                ClearTextBoxes();
            }

        }
        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SlotText.Text) || String.IsNullOrEmpty(Class1Text.Text) || String.IsNullOrEmpty(Class2Text.Text)
                || String.IsNullOrEmpty(Class3Text.Text))
            {
                correctInfo = false;
            }
            else
            {
                correctInfo = true;
            }
            if (correctInfo)
            {
                con.Open();
                updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET lootscore =  tierscore WHERE character = character ", con);
                updatePlayer.ExecuteNonQuery();                
                updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersILVL\" SET ilvldifference =  "+ ilvlText.Text +" - "+ SlotText.Text + "ilvl WHERE character = character AND "+ SlotText.Text + "ilvl IS NOT NULL", con);
                updatePlayer.ExecuteNonQuery();
                updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersILVL\" SET ilvldifference =  null  WHERE character IN (SELECT character FROM  public.\"PlayersData\" WHERE "+ SlotText.Text + " =FALSE )" , con);
                updatePlayer.ExecuteNonQuery();
                rollTier = new NpgsqlCommand("SELECT  DISTINCT public.\"PlayersData\".character, " + SlotText.Text + ", lootscore, attendance , ilvldifference ," + SlotText.Text + "ilvl FROM public.\"PlayersData\"  INNER JOIN public.\"PlayersILVL\" ON public.\"PlayersData\".character IN( SELECT character FROM public.\"PlayersData\" WHERE class = @Class1 OR class = @Class2 OR class = @Class3 OR class = @Class4 ) AND public.\"PlayersData\".character= public.\"PlayersILVL\".character  ORDER BY " + SlotText.Text + " ASC , lootscore DESC, attendance DESC, ilvldifference DESC ", con);

                rollTier.Parameters.AddWithValue("@Class1", Class1Text.Text);
                rollTier.Parameters.AddWithValue("@Class2", Class2Text.Text);
                rollTier.Parameters.AddWithValue("@Class3", Class3Text.Text);
                rollTier.Parameters.AddWithValue("@Class4", Class4Text.Text);
                
                dr = rollTier.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    RollGrid.DataSource = dt;
                }
                con.Close();
                ClearTextBoxes();
            }
        }

        private void UpdatePlayerButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PlayerListText.Text) || String.IsNullOrEmpty(UpdateText.Text) || String.IsNullOrEmpty(NewValueText.Text)
                )
            {
                correctInfo = false;
            }
            else
            {
                correctInfo = true;
            }
            if (correctInfo)
            {
                con.Open();               
                if(UpdateText.Text == "Hands")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET hands = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "Chest")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET chest = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "Shoulders")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET shoulders = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "Head")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET head = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "Legs")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET legs = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "TierScore")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET tierscore = " + NewValueText.Text + " WHERE character = @Character", con);
                else if (UpdateText.Text == "Attendance")
                    updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET attendance = " + NewValueText.Text + " WHERE character = @Character", con);

                updatePlayer.Parameters.AddWithValue("@Character", PlayerListText.Text);
                updatePlayer.ExecuteNonQuery();
                con.Close();
                ClearTextBoxes();
            }
        }
        public void LoadPlayers()
        {
            con.Open();
            updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET lootscore = tierscore WHERE character = character ", con);
            updatePlayer.ExecuteNonQuery();
            loadPlayers = new NpgsqlCommand("SELECT * FROM public.\"PlayersData\" ORDER BY character ASC", con);
            dr = loadPlayers.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                PlayersListGrid.DataSource = dt;
            }
            con.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            PlayerListText.Items.Clear();
            PlayerListText2.Items.Clear();
            PlayerAttendanceList.Items.Clear();
            LoadPlayers();
            ClearTextBoxes();
            con.Open();
            updatePlayer = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET lootscore =  tierscore WHERE character = character ", con);
            updatePlayer.ExecuteNonQuery();
            NpgsqlCommand LoadCharacters = new NpgsqlCommand("Select character From public.\"PlayersData\" ORDER BY \"character\" ASC ", con);
            dr = LoadCharacters.ExecuteReader();
            PlayerListText.Items.Clear();
            while (dr.Read())
            {
                PlayerListText.Items.Add(dr.GetValue(0));
                PlayerListText2.Items.Add(dr.GetValue(0));
                PlayerAttendanceList.Items.Add(dr.GetValue(0));
            }
            con.Close();
        }

        private void UpdatePlayerILVLButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PlayerListText2.Text) || String.IsNullOrEmpty(SlotUpdateText.Text) || String.IsNullOrEmpty(NewIlvlText.Text)
               )
            {
                correctInfo = false;
            }
            else
            {
                correctInfo = true;
            }
            if (correctInfo)
            {
                con.Open();

                if (SlotUpdateText.Text == "Hands")
                    updatePlayer = new NpgsqlCommand("UPDATE \"PlayersILVL\" SET handsilvl = " + NewIlvlText.Text + " WHERE \"character\" = @Character", con);
                else if (SlotUpdateText.Text == "Chest")
                    updatePlayer = new NpgsqlCommand("UPDATE \"PlayersILVL\" SET chestilvl = " + NewIlvlText.Text + " WHERE character = @Character", con);
                else if (SlotUpdateText.Text == "Shoulders")
                    updatePlayer = new NpgsqlCommand("UPDATE \"PlayersILVL\" SET shouldersilvl = " + NewIlvlText.Text + " WHERE character = @Character", con);
                else if (SlotUpdateText.Text == "Head")
                    updatePlayer = new NpgsqlCommand("UPDATE \"PlayersILVL\" SET headilvl = " + NewIlvlText.Text + " WHERE character = @Character", con);
                else if (SlotUpdateText.Text == "Legs")
                    updatePlayer = new NpgsqlCommand("UPDATE \"PlayersILVL\" SET legsilvl = " + NewIlvlText.Text + " WHERE character = @Character", con);                
                updatePlayer.Parameters.AddWithValue("@Character", PlayerListText2.Text);

                updatePlayer.ExecuteNonQuery();

                con.Close();
                ClearTextBoxes();
            }
        }

        private void PlayerListText2_ValueMemberChanged(object sender, EventArgs e)
        {
            SlotUpdateText.Items.Clear();
            con.Open();
            selectSlots = new NpgsqlCommand("Select hands, chest,shoulders,head,legs FROM public.\"PlayersData\" WHERE public.\"PlayersData\".character = '" + PlayerListText2.Text + "'", con);
           
            dr = selectSlots.ExecuteReader();
 
            while (dr.Read())
            {
                for (int i =0; i < 5; i++)
                {
                    if ((bool)dr[i] == true)
                    {
                        string slotName = dr.GetName(i);
                        slotName = slotName.First().ToString().ToUpper() + slotName.Substring(1);
                        SlotUpdateText.Items.Add(slotName);
                    }
                  
                }
            }
            con.Close();
        }

        private void ClearAttendanceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< PlayerAttendanceList.Items.Count; i++)
            {
                PlayerAttendanceList.SetItemChecked(i, false);
            }
        }

        private void SetAttendanceButton_Click(object sender, EventArgs e)
        {
            foreach (object o in PlayerAttendanceList.CheckedItems) 
            {
                con.Open();
                setAttendance = new NpgsqlCommand("UPDATE public.\"PlayersData\" SET attendance = attendance + 1 WHERE character = '"+ o.ToString()+"'", con);
                setAttendance.ExecuteNonQuery();
                con.Close() ;
                
            }
            for (int i = 0; i < PlayerAttendanceList.Items.Count; i++)
            {
                PlayerAttendanceList.SetItemChecked(i, false);
            }
        }
    }
}

