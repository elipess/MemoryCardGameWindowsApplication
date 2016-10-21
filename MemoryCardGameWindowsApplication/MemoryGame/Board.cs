using System;

namespace MemoryGame
{
    public class Board
    {
        public const int k_MinBoardDim = 4;
        public const int k_MaxBoardDim = 6;

        private readonly int m_BoardHeight;
        private readonly int m_BoardWidth;

        private int m_RevealedPairs = 0;
        private Square[,] m_BoardMatrix;
        private bool m_Finished = false;
        private string[,] asArray;

        #region Accessors

        public int MinBoardDim
        {
            get
            {
                return k_MinBoardDim;
            }
        }

        public int MaxBoardDim
        {
            get
            {
                return k_MaxBoardDim;
            }
        }

        public int BoardHeight
        {
            get
            {
                return m_BoardHeight;
            }
        }

        public int BoardWidth
        {
            get
            {
                return m_BoardWidth;
            }
        }

        public bool Finished
        {
            get
            {
                return m_Finished;
            }

            set
            {
                m_Finished = value;
            }
        }

        internal Square[,] BoardMatrix
        {
            get
            {
                return m_BoardMatrix;
            }

            set
            {
                m_BoardMatrix = value;
            }
        }

        public int RevealedPairs
        {
            get
            {
                return m_RevealedPairs;
            }

            set
            {
                m_RevealedPairs = value;
            }
        }
        #endregion

        public Board(int i_Height, int i_Width)
        {
            m_BoardMatrix = new Square[i_Height, i_Width];
            m_BoardHeight = i_Height;
            m_BoardWidth = i_Width;
        }

        public static string GetNextBoardSize(string text)
        {
            string res;
            int row = text.ToCharArray()[0] - '0';
            int col = text.ToCharArray()[2] - '0';

            if (col < k_MaxBoardDim)
            {
                col++;
            }
            else
            {
                col = k_MinBoardDim;
                if (row < k_MaxBoardDim)
                {
                    row++;
                }
                else
                {
                    row = k_MinBoardDim;
                }
            }

            res = row.ToString() + "x" + col.ToString();

            if ((row * col) % 2 == 1)
            {
                res = GetNextBoardSize(res);
            }

            return res;
        }

        public int? GetContent(Square i_Sqr)
        {
            return BoardMatrix[i_Sqr.Row, i_Sqr.Col].Content;
        }

        public void PairRevealed(Square i_FirstSqr, Square i_SecondSqr)
        {
            Reveal(i_FirstSqr);
            Reveal(i_SecondSqr);
            RevealedPairs++;
            int numOfPairs = m_BoardHeight * m_BoardWidth / 2;
            if (RevealedPairs == numOfPairs)
            {
                Finished = true;
            }
        }

        internal void randomizeBoard()
        {
            Random random = new Random();
            int numOfPairs = m_BoardHeight * m_BoardWidth / 2;
            bool[,] isSetted = new bool[m_BoardHeight, m_BoardWidth];

            for (int i = 0; i < numOfPairs; i++)
            {
                int content = i;
                for (int j = 0; j < 2; j++)
                {
                    while (true)
                    {
                        int sqrHeight = random.Next(m_BoardHeight);
                        int sqrWidth = random.Next(m_BoardWidth);
                        if (isSetted[sqrHeight, sqrWidth])
                        {
                            continue;
                        }
                        else
                        {
                            m_BoardMatrix[sqrHeight, sqrWidth].Content = content;
                            isSetted[sqrHeight, sqrWidth] = true;
                            break;
                        }
                    }
                }
            }

            asArray = toArray();
        }

        internal bool Compare(Square i_FirstSqr, Square i_SecondSqr)
        {
            return i_FirstSqr.Content == i_SecondSqr.Content;
        }

        internal void Reveal(Square i_Sqr)
        {
            BoardMatrix[i_Sqr.Row, i_Sqr.Col].Revealed = true;
        }

        internal void UnReveal(Square i_FirstSqr, Square i_SecondSqr)
        {
            BoardMatrix[i_FirstSqr.Row, i_FirstSqr.Col].Revealed = false;
            BoardMatrix[i_SecondSqr.Row, i_SecondSqr.Col].Revealed = false;
        }

        public string[,] toArray()
        {
            string[,] res = new string[BoardHeight, BoardWidth];
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    res[i, j] = BoardMatrix[i, j].Content.ToString();
                }
            }

            return res;
        }
    }
}
