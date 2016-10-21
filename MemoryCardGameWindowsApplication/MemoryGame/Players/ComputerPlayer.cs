using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class ComputerPlayer : Player
    {
        private Board m_Board;

        public ComputerPlayer(SettingsHolder i_Settings) : base(i_Settings.Names[GameLogic.k_SecondPlayer])
        {
            m_Board = new Board(i_Settings.Rows, i_Settings.Cols);
        }

        public void GetMove(out Square o_Sqr1, out Square o_Sqr2)
        {
            do
            {
                getSqr(out o_Sqr1);
                getSqr(out o_Sqr2);
            }
            while (o_Sqr1.PositionEquals(o_Sqr2));
        }

        private Square getSqr(out Square o_Sqr1)
        {
            Random random = new Random();
            while (true)
            {
                int row = random.Next(m_Board.BoardHeight);
                int col = random.Next(m_Board.BoardWidth);

                if (m_Board.BoardMatrix[row, col].Revealed)
                {
                    continue;
                }
                else
                {
                    o_Sqr1 = new Square(row, col);
                    break;
                }
            }

            return o_Sqr1;
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }
    }
}