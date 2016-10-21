using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace MemoryGame
{
    internal partial class FormGame : Form
    {
        private const int k_MilisecondsToSleep = 1000;
        private const int k_PicturesSize = 80;
        private const int k_LeftBorderMargin = 40;
        private const int k_TopBorderMargin = 80;
        private const int k_Spacer = 10;
        private const int k_PaddingSize = 3;
        private const string k_CurrentPlayerString = "Current Player: {0}";
        private const string k_PlayerAndScoreString = "{0}: {1} Pair(s)";
        private const string k_GameOverString = "Game Over";
        private const string k_ExitMsg = "GoodBye!";

        private readonly string r_FirstPlayerPlaying;
        private readonly string r_SecondPlayerPlaying;

        private readonly int r_FirstPlayer;
        private readonly int r_SecondPlayer;

        private GameLogic m_GameLogic;
        private PictureBox[] m_pictureCards;
        private PictureBox[] m_pictureCardsClone;
        private GroupBox m_CardsGroupBox = new GroupBox();
        private Button[,] m_Btns;
        private PictureBox m_PenddingImage1;
        private PictureBox m_PenddingImage2;
        private Button m_PenddingBtn1;
        private Button m_PenddingBtn2;
        private Square m_RevealedSqr1;
        private Square m_RevealedSqr2;
        private bool m_IsFirstCard = true;
        private bool m_IsGameOver = false;

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }

            set
            {
                m_IsGameOver = value;
                if (value == true)
                {
                    MessageBox.Show(k_ExitMsg);
                    Close();
                }
            }
        }

        internal FormGame(GameLogic i_GameLogic)
        {
            InitializeComponent();
            m_GameLogic = i_GameLogic;
            r_FirstPlayer = i_GameLogic.FirstPlayer;
            r_SecondPlayer = i_GameLogic.SecondPlayer;
            r_FirstPlayerPlaying = string.Format(k_CurrentPlayerString, m_GameLogic.Players[r_FirstPlayer].Name);
            r_SecondPlayerPlaying = string.Format(k_CurrentPlayerString, m_GameLogic.Players[r_SecondPlayer].Name);
        }

        private void initPicturesCardsArray()
        {
            m_pictureCards = new PictureBox[m_GameLogic.Settings.Cols * m_GameLogic.Settings.Rows / 2];
            m_pictureCardsClone = new PictureBox[m_pictureCards.Length];
            loadCards();
        }

        private void loadCards()
        {
            for (int i = 0; i < m_pictureCards.Length; i++)
            {
                m_pictureCards[i] = new PictureBox();
                m_pictureCards[i].Size = new Size(k_PicturesSize, k_PicturesSize);
                m_pictureCards[i].Load("http://lorempixel.com/74/74/");
              
                m_pictureCards[i].Visible = false;
                m_CardsGroupBox.Controls.Add(m_pictureCards[i]);

                m_pictureCardsClone[i] = new PictureBox();
                m_pictureCardsClone[i].Size = new Size(k_PicturesSize, k_PicturesSize);
                m_pictureCardsClone[i].Image = (Image)m_pictureCards[i].Image.Clone();
                m_pictureCardsClone[i].Visible = false;
                m_CardsGroupBox.Controls.Add(m_pictureCardsClone[i]);
            }
        }

        internal void Run()
        {
            initPicturesCardsArray();
            initUIBoard();
            printPlayers();
            registerEvents();
            ShowDialog();
        }

        private void registerEvents()
        {
            m_GameLogic.TurnMovedToNextPlayer += new EventHandler(m_GameLogic_switchedTurn);
            m_GameLogic.GameOver += GameLogic_GameOver;

            /// score changing
            m_GameLogic.Players[r_FirstPlayer].scoreChanged += Player_scoreChanged;
            m_GameLogic.Players[r_SecondPlayer].scoreChanged += Player_scoreChanged;
        }

        public void Player_scoreChanged(Player i_Sender, int i_NewScore)
        {
            Label label = getPlayerLblByName(i_Sender.Name);
            label.Text = string.Format(k_PlayerAndScoreString, i_Sender.Name.ToString(), i_NewScore.ToString());
        }

        private Label getPlayerLblByName(string i_Name)
        {
            Label res;

            if (labelFirstPlayer.Text.Contains(i_Name))
            {
                res = labelFirstPlayer;
            }
            else
            {
                res = labelSecondPlayer;
            }

            return res;
        }

        protected void GameLogic_GameOver(Player i_Winner)
        {
            string text;
            if(i_Winner != null)
            {
                if (i_Winner.Name != "Computer")
                {
                    text = string.Format(
@"Game is over!
{0} has won with {1} pairs! Well Done!
Would you like another round?",
i_Winner.Name,
i_Winner.Score);
                }
                else 
                {
                    text = string.Format(
@"Game is over!
{0} has won with {1} pairs! Better luck next time!
Would you like another round?",
i_Winner.Name,
i_Winner.Score);
                }
            }
            else
            {
                text = string.Format(
@"Game is over!
It's a tie !
Would you like another round?");
            }

            string caption = "Game Over";
            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
          
            DialogResult result = MessageBox.Show(text, caption, buttons);
            switch (result)
            {
                case DialogResult.Yes:
                    Close();
                    Dispose();
                    break;
                default:
                    IsGameOver = true;
                    break;
            }
        }

        private void printPlayers()
        {
            groupBoxPlayersStats.Top = this.m_CardsGroupBox.Top + this.m_CardsGroupBox.Height + k_Spacer;
            groupBoxPlayersStats.Left = k_Spacer;
            labelCurrentPlayer.Text = string.Format(k_CurrentPlayerString, m_GameLogic.Players[m_GameLogic.CurrentPlayer].Name.ToString());
            labelFirstPlayer.Text = string.Format(k_PlayerAndScoreString, m_GameLogic.Players[r_FirstPlayer].Name.ToString(), m_GameLogic.Players[r_FirstPlayer].Score.ToString());
            labelCurrentPlayer.BackColor = labelFirstPlayer.BackColor = FormUserInterface.k_FirstPlayerColor;

            labelSecondPlayer.Text = string.Format(k_PlayerAndScoreString, m_GameLogic.Players[r_SecondPlayer].Name.ToString(), m_GameLogic.Players[r_SecondPlayer].Score.ToString());
            labelSecondPlayer.BackColor = FormUserInterface.k_SecondPlayerColor;
        }

        private void initUIBoard()
        {
            int rows = m_GameLogic.Settings.Rows;
            int cols = m_GameLogic.Settings.Cols;

            m_CardsGroupBox.Left = k_Spacer;
            m_CardsGroupBox.Top = k_Spacer;
            m_CardsGroupBox.AutoSize = true;
            this.Controls.Add(m_CardsGroupBox);
            createButtons(rows, cols);
        }

        private void createButtons(int i_Rows, int i_Cols)
        {
            m_Btns = new Button[i_Rows, i_Cols];
            for (int row = 1; row <= i_Rows; row++)
            {
                for (int col = 1; col <= i_Cols; col++)
                {
                    m_Btns[row - 1, col - 1] = new Button();
                    Button card = m_Btns[row - 1, col - 1];
                    card.Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                    card.Location = new Point(m_CardsGroupBox.DisplayRectangle.Left + ((col - 1) * (k_PicturesSize + k_Spacer)), m_CardsGroupBox.DisplayRectangle.Top + ((row - 1) * (k_PicturesSize + k_Spacer)));
                    card.Size = new System.Drawing.Size(k_PicturesSize, k_PicturesSize);
                    card.Text = string.Empty;
                    card.Name = string.Format("{0}x{1}", row, col);
                    card.TabStop = false;
                    card.Click += CardClick;
                    m_CardsGroupBox.Controls.Add(card);
                }
            }
        }

        private void CardClick(object sender, EventArgs e)
        {
            if (m_IsFirstCard)
            {
                m_PenddingBtn1 = sender as Button;
                m_RevealedSqr1 = Square.Parse(m_PenddingBtn1.Name);
                m_PenddingImage1 = m_pictureCards[(int)m_GameLogic.Board.GetContent(m_RevealedSqr1)];
                replaceBtnWithImage(m_PenddingBtn1, m_PenddingImage1);
                Update();
                m_IsFirstCard = false;
            }
            else
            {
                m_PenddingBtn2 = sender as Button;
                m_RevealedSqr2 = Square.Parse(m_PenddingBtn2.Name);
                m_PenddingImage2 = m_pictureCardsClone[(int)m_GameLogic.Board.GetContent(m_RevealedSqr2)];
                replaceBtnWithImage(m_PenddingBtn2, m_PenddingImage2);
                Update();
                Rest();

                if (!m_GameLogic.PlayerMove(m_RevealedSqr1, m_RevealedSqr2) && !IsGameOver) 
                {
                    reshowBtns();
                    Update();
                }

                m_IsFirstCard = true;
                bool computerMove = !IsGameOver && isComputersMove();

                while (computerMove)
                {
                    m_GameLogic.getComputerMove(out m_RevealedSqr1, out m_RevealedSqr2);
                    setPendingBtnsAndImages(m_RevealedSqr1, m_RevealedSqr2);

                    replaceBtnWithImage(m_PenddingBtn1, m_PenddingImage1);
                    replaceBtnWithImage(m_PenddingBtn2, m_PenddingImage2);

                    Update();
                    Rest();

                    if (!m_GameLogic.PlayerMove(m_RevealedSqr1, m_RevealedSqr2)) 
                    {
                        reshowBtns();
                        Update();
                        computerMove = false;
                    }
                    else
                    {
                        computerMove = !IsGameOver && isComputersMove();
                    }
                }
            }
        }

        private void setPendingBtnsAndImages(Square o_Sqr1, Square o_Sqr2)
        {
            m_PenddingBtn1 = m_Btns[o_Sqr1.Row, o_Sqr1.Col];
            m_PenddingBtn2 = m_Btns[o_Sqr2.Row, o_Sqr2.Col];
            m_PenddingImage1 = m_pictureCards[(int)m_GameLogic.Board.GetContent(o_Sqr1)];
            m_PenddingImage2 = m_pictureCardsClone[(int)m_GameLogic.Board.GetContent(o_Sqr2)];
        }

        private void replaceBtnWithImage(Button i_Btn, PictureBox i_Image)
        {
            hideBtn(i_Btn);
            showImage(i_Image, i_Btn.Location);
        }

        private bool isComputersMove()
        {
            return m_GameLogic.Players[m_GameLogic.CurrentPlayer] is ComputerPlayer;
        }

        private void showImage(PictureBox i_Picture, Point i_Location)
        {
            i_Picture.Location = i_Location;
            i_Picture.Padding = new Padding(k_PaddingSize);
            i_Picture.BackColor = labelCurrentPlayer.BackColor;
            i_Picture.Show();
        }

        private void hideBtn(Button i_Btn)
        {
            i_Btn.Visible = false;
            i_Btn.Enabled = false;
        }

        private void reshowBtns()
        {
            m_PenddingImage1.Visible = false;
            m_PenddingBtn1.Visible = true;
            m_PenddingBtn1.Enabled = true;

            m_PenddingImage2.Visible = false;
            m_PenddingBtn2.Visible = true;
            m_PenddingBtn2.Enabled = true;
        }
           
        private void m_GameLogic_switchedTurn(object sender, EventArgs e)
        {
            if (labelCurrentPlayer.Text == r_FirstPlayerPlaying)
            {
                labelCurrentPlayer.Text = r_SecondPlayerPlaying;
                labelCurrentPlayer.BackColor = labelSecondPlayer.BackColor;
            }
            else
            {
                labelCurrentPlayer.Text = r_FirstPlayerPlaying;
                labelCurrentPlayer.BackColor = labelFirstPlayer.BackColor;
            }   
        }

        public static void Rest()
        {
            Thread.Sleep(k_MilisecondsToSleep);
        }
    }
}