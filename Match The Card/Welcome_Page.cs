using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_The_Card
{
    public enum GameLevel
    {
        Beginner,
        Challenger,
        Expert
    }
    public partial class Welcome_Page : Form
    {
        GameLevel selectedLevel;
        int NumberOfCards = 0;
        int NumberOfPlayers = 0;
        public Welcome_Page()
        {
            InitializeComponent();
            Players_Panel.Visible = false;
            Level_Panel.Visible = false;
            Start.Enabled = false;
        }
        private void BtnCards_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == btn50Cards)
            {
                btn50Cards.Enabled = false;
                btn100Cards.Enabled = true;
                NumberOfCards = 50;
            }
            else if (btn == btn100Cards)
            {
                btn100Cards.Enabled = false;
                btn50Cards.Enabled = true;
                NumberOfCards = 100;
            }
            Players_Panel.Visible = true;
        }
        private void Rd_btnPlayers_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton == OnePlayer)
            {
                lbl_Player1.Visible = true;    //1player
                lbl_Player2.Visible = false;
                lbl_Player3.Visible = false;
                txt_Player1.Visible = true;    //1player
                txt_Player2.Visible = false;
                txt_Player3.Visible = false;
                NumberOfPlayers = 1;
            }
            else if (radioButton == TwoPlayers)
            {
                lbl_Player1.Visible = true;    //player1
                lbl_Player2.Visible = true;    //player2
                lbl_Player3.Visible = false;
                txt_Player1.Visible = true;    //player1
                txt_Player2.Visible = true;    //player2
                txt_Player3.Visible = false;
                NumberOfPlayers = 2;
            }
            else if (radioButton == ThreePlayers)
            {
                lbl_Player1.Visible = true;    //player1
                lbl_Player2.Visible = true;    //player2
                lbl_Player3.Visible = true;    //player3
                txt_Player1.Visible = true;    //player1
                txt_Player2.Visible = true;    //player2
                txt_Player3.Visible = true;    //player3
                NumberOfPlayers = 3;
            }
            Level_Panel.Visible = true;
        }
        private void Btn_Levels_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == btn_Beginner)
            {
                btn_Beginner.Enabled = false;
                btn_Challenger.Enabled = true;
                btn_Expert.Enabled = true;
                selectedLevel = GameLevel.Beginner;
            }
            else if (btn == btn_Challenger)
            {
                btn_Beginner.Enabled = true;
                btn_Challenger.Enabled = false;
                btn_Expert.Enabled = true;
                selectedLevel = GameLevel.Challenger;
            }
            else if (btn == btn_Expert)
            {
                btn_Beginner.Enabled = true;
                btn_Challenger.Enabled = true;
                btn_Expert.Enabled = false;
                selectedLevel = GameLevel.Expert;
            }
            Start.Enabled = true;
        }
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.SteelBlue;
        }
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.DeepSkyBlue;
        }
        private void Welcome_Page_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if(NumberOfCards==50)
            {
                _50Cards _50Cards = new _50Cards();
                _50Cards.Show();
                this.Hide();
            }
            else if(NumberOfCards==100)
            {
                _100Cards _100Cards = new _100Cards(NumberOfPlayers, selectedLevel);
                //_100Cards.GameLevel = selectedLevel;
                _100Cards.Show();
                this.Hide();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to close app?", "Tic Tac Toe Game"
                 , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
