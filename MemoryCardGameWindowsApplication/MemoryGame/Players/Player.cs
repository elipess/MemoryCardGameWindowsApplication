using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public delegate void ScoreChanged(Player i_Sender, int i_NewScore);

    public class Player
    {
        public event ScoreChanged scoreChanged;

        private string m_Name;
        private int m_Score = 0;

        public Player(string i_Name)
        {
            m_Name = i_Name;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
                if (scoreChanged != null)
                {
                    scoreChanged.Invoke(this, m_Score);
                }
            }
        }
    }
}
