using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public struct Square
    {
        private readonly int mr_Row;
        private readonly int mr_Col;
        private int? m_Content;
        private bool m_Revealed;
        
        public Square(int i_Row, int i_Col)
        {
            mr_Col = i_Col;
            mr_Row = i_Row;
            m_Content = null;
            m_Revealed = false;
        }

        public static Square Parse(string name)
        {
            char[] inChar = name.ToCharArray();
            int row = inChar[0] - '0';
            int col = inChar[2] - '0';

            return new Square(row - 1, col - 1);
        }

        public bool PositionEquals(Square i_Sqr)
        {
            return i_Sqr.Col == this.Col && i_Sqr.Row == this.Row;
        }

        public override string ToString()
        {
            return string.Format("Row: " + Row.ToString() + " Col: " + Col.ToString() + " Content: " + Content.ToString());
        }

        #region Accessors
        public int Row
        {
            get
            {
                return mr_Row;
            }
        }

        public int Col
        {
            get
            {
                return mr_Col;
            }
        }

        public int? Content
        {
            get
            {
                return m_Content;
            }

            set
            {
                m_Content = value;
            }
        }

        public bool Revealed
        {
            get
            {
                return m_Revealed;
            }

            set
            {
                m_Revealed = value;
            }
        }
        #endregion
    }
}