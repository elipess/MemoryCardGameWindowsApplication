using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    internal class FormUserInterface
    {
        public static Color k_FirstPlayerColor = System.Drawing.Color.LightBlue;
        public static Color k_SecondPlayerColor = System.Drawing.Color.Coral;

        private FormSettings m_FormSettings = new FormSettings();
        private SettingsHolder m_Settings;
        private GameLogic m_GameLogic;
        private FormGame m_Game;

        public FormUserInterface()
        {
            try
            {
                m_Settings = m_FormSettings.GetSettings();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void Run()
        {
            try
            {
                DialogResult result = DialogResult.Retry;

                while (result == DialogResult.Retry)
                {
                    m_GameLogic = new GameLogic(m_Settings);
                    result = m_FormSettings.DialogResult;
                }

                m_Game = new FormGame(m_GameLogic);
                m_Game.Disposed += game_new_Game;
                m_Game.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message.ToString());
            }    
        }

        private void game_new_Game(object sender, EventArgs e)
        {
            this.Run();
        }   
    }
}
