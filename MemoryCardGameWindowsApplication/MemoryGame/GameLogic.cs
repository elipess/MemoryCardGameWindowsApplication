using System;

namespace MemoryGame
{
    public delegate void GameOverEventHandler(Player i_Winner);

    public class GameLogic
    {
        public event EventHandler TurnMovedToNextPlayer;

        public event GameOverEventHandler GameOver;

        public const int k_NumOfPlayers = 2;
        public const int k_FirstPlayer = 0;
        public const int k_SecondPlayer = 1;

        private int m_CurrentPlayer = 0;
        private SettingsHolder m_Settings;
        private Board m_Board;
        private Player[] m_Players = new Player[k_NumOfPlayers];

        public GameLogic(SettingsHolder i_Settings)
        {
            m_Settings = i_Settings;
            m_Board = new Board(m_Settings.Rows, m_Settings.Cols);

            initBoard();

            Players[k_FirstPlayer] = new Player(m_Settings.Names[k_FirstPlayer]);
          
            if (m_Settings.AgainstFriend)
            {
                Players[k_SecondPlayer] = new Player(m_Settings.Names[k_SecondPlayer]);
            }
            else
            {
                Players[k_SecondPlayer] = new ComputerPlayer(m_Settings);
            }
        }

        private void switchTurn()
        {
            m_CurrentPlayer = (m_CurrentPlayer + 1) % k_NumOfPlayers;
            TurnMovedToNextPlayer.Invoke(this, new EventArgs());
        }

        public bool PlayerMove(Square i_FirstSqr, Square i_SecondSqr)
        {
            bool IsPairEquals = m_Board.GetContent(i_FirstSqr) == m_Board.GetContent(i_SecondSqr);
            if (IsPairEquals)
            {
                m_Board.PairRevealed(i_FirstSqr, i_SecondSqr);
                Players[CurrentPlayer].Score++;
                if (!Settings.AgainstFriend)
                {
                    (m_Players[k_SecondPlayer] as ComputerPlayer).Board.PairRevealed(i_FirstSqr, i_SecondSqr);
                }

                if (Board.Finished)
                {
                    Player o_Winner = this.GetWinner();
                    GameOver.Invoke(o_Winner);
                }
            }
            else
            {
                switchTurn();
            }

            return IsPairEquals;
        }

        private Player GetWinner()
        {
            Player o_Winner; 

            if(m_Players[k_FirstPlayer].Score > m_Players[k_SecondPlayer].Score)
            {
                o_Winner = m_Players[k_FirstPlayer];
            }
            else if(m_Players[k_FirstPlayer].Score < m_Players[k_SecondPlayer].Score)
            {
                o_Winner = m_Players[k_SecondPlayer];
            }
            else 
            {
                o_Winner = null;
            }

            return o_Winner; 
        }
        
        private void initBoard()
        {
            Board.randomizeBoard();
        }        
 
        public void getComputerMove(out Square o_Sqr1, out Square o_Sqr2)
        {
            (Players[k_SecondPlayer] as ComputerPlayer).GetMove(out o_Sqr1, out o_Sqr2);
        }

        public SettingsHolder Settings
        {
            get
            {
                return m_Settings;
            }

            set
            {
                m_Settings = value;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public int CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Player[] Players
        {
            get
            {
                return m_Players;
            }

            set
            {
                m_Players = value;
            }
        }

        public int NumOfPlayers
        {
            get { return k_NumOfPlayers; }
        }

        public int FirstPlayer
        {
            get { return k_FirstPlayer; }
        }

        public int SecondPlayer
        {
            get { return k_SecondPlayer; }
        }
    }
}