namespace MemoryGame
{
    internal partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.labelFirstPlayer = new System.Windows.Forms.Label();
            this.labelSecondPlayer = new System.Windows.Forms.Label();
            this.groupBoxPlayersStats = new System.Windows.Forms.GroupBox();
            this.groupBoxPlayersStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(12, 16);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentPlayer.TabIndex = 1;
            this.labelCurrentPlayer.Text = "lable2";
            // 
            // labelFirstPlayer
            // 
            this.labelFirstPlayer.AutoSize = true;
            this.labelFirstPlayer.Location = new System.Drawing.Point(12, 43);
            this.labelFirstPlayer.Name = "labelFirstPlayer";
            this.labelFirstPlayer.Size = new System.Drawing.Size(35, 13);
            this.labelFirstPlayer.TabIndex = 2;
            this.labelFirstPlayer.Text = "label3";
            // 
            // labelSecondPlayer
            // 
            this.labelSecondPlayer.AutoSize = true;
            this.labelSecondPlayer.Location = new System.Drawing.Point(12, 66);
            this.labelSecondPlayer.Name = "labelSecondPlayer";
            this.labelSecondPlayer.Size = new System.Drawing.Size(35, 13);
            this.labelSecondPlayer.TabIndex = 3;
            this.labelSecondPlayer.Text = "label4";
            // 
            // groupBoxPlayersStats
            // 
            this.groupBoxPlayersStats.AutoSize = true;
            this.groupBoxPlayersStats.Controls.Add(this.labelSecondPlayer);
            this.groupBoxPlayersStats.Controls.Add(this.labelFirstPlayer);
            this.groupBoxPlayersStats.Controls.Add(this.labelCurrentPlayer);
            this.groupBoxPlayersStats.Location = new System.Drawing.Point(38, 379);
            this.groupBoxPlayersStats.Name = "groupBoxPlayersStats";
            this.groupBoxPlayersStats.Size = new System.Drawing.Size(178, 95);
            this.groupBoxPlayersStats.TabIndex = 4;
            this.groupBoxPlayersStats.TabStop = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(684, 487);
            this.Controls.Add(this.groupBoxPlayersStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Memory Game!";
            this.groupBoxPlayersStats.ResumeLayout(false);
            this.groupBoxPlayersStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCurrentPlayer;
        private System.Windows.Forms.Label labelFirstPlayer;
        private System.Windows.Forms.Label labelSecondPlayer;
        private System.Windows.Forms.GroupBox groupBoxPlayersStats;
    }
}