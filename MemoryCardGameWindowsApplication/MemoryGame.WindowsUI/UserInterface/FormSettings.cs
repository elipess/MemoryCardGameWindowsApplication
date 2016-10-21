using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    internal partial class FormSettings : Form
    {
        private SettingsHolder m_Settings;

        public FormSettings()
        {
            m_Settings.Rows = Board.k_MinBoardDim;
            m_Settings.Cols = Board.k_MinBoardDim;
            InitializeComponent();
        }

        private void btn_BoardSize_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = Board.GetNextBoardSize(btn.Text);
            m_Settings.Rows = btn.Text.ToCharArray()[0] - '0';
            m_Settings.Cols = btn.Text.ToCharArray()[2] - '0';
        }

        private void btn_ComputerFirend_WantFriendClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.SecondPlayerName.Enabled = true;
            this.SecondPlayerName.Text = string.Empty;
            btn.Text = "Against Computer";
            btn.Click -= btn_ComputerFirend_WantFriendClick;
            btn.Click += btn_ComputerFriend_WantComputerClick;
            m_Settings.AgainstFriend = true;
        }

        private void btn_ComputerFriend_WantComputerClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.SecondPlayerName.Enabled = false;
            btn.Text = "Against a friend";
            this.SecondPlayerName.Text = "Computer";
            btn.Click += btn_ComputerFirend_WantFriendClick;
            btn.Click -= btn_ComputerFriend_WantComputerClick;
            m_Settings.AgainstFriend = false;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (FirstPlayerName.Text == string.Empty)
            {
                isValid = false;
                MessageBox.Show("You forgot to enter your name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (FirstPlayerName.Text == SecondPlayerName.Text)
            {
                isValid = false;
                MessageBox.Show("Names cannot be equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            m_Settings.Names = new string[GameLogic.k_NumOfPlayers];
            m_Settings.Names[GameLogic.k_FirstPlayer] = this.FirstPlayerName.Text;
            m_Settings.Names[GameLogic.k_SecondPlayer] = this.SecondPlayerName.Text;
            m_Settings.Rows = btn_BoardSize.Text[0] - '0';
            m_Settings.Cols = btn_BoardSize.Text[2] - '0';

            if (isValid)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            }
        }

        internal SettingsHolder GetSettings()
        {
            DialogResult result = ShowDialog();
            if (result == DialogResult.Cancel)
            {
                throw new ExitGameException("Exit");
            }
            else
            {
                return m_Settings;
            }
        }
    }
}
