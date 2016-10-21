namespace MemoryGame
{
    internal partial class FormSettings
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
            this.SecondPlayerName = new System.Windows.Forms.TextBox();
            this.FirstPlayerName = new System.Windows.Forms.TextBox();
            this.btn_ComputerFirend = new System.Windows.Forms.Button();
            this.r_BoardSize = new System.Windows.Forms.TextBox();
            this.btn_BoardSize = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.r_FirstPlayerName = new System.Windows.Forms.TextBox();
            this.r_SecondPlayerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SecondPlayerName
            // 
            this.SecondPlayerName.Enabled = false;
            this.SecondPlayerName.Location = new System.Drawing.Point(207, 49);
            this.SecondPlayerName.Name = "SecondPlayerName";
            this.SecondPlayerName.Size = new System.Drawing.Size(133, 20);
            this.SecondPlayerName.TabIndex = 3;
            this.SecondPlayerName.Text = "Computer";
            // 
            // FirstPlayerName
            // 
            this.FirstPlayerName.Location = new System.Drawing.Point(207, 23);
            this.FirstPlayerName.Name = "FirstPlayerName";
            this.FirstPlayerName.Size = new System.Drawing.Size(133, 20);
            this.FirstPlayerName.TabIndex = 2;
            this.FirstPlayerName.Text = "My Name";
            // 
            // btn_ComputerFirend
            // 
            this.btn_ComputerFirend.Location = new System.Drawing.Point(357, 45);
            this.btn_ComputerFirend.Name = "btn_ComputerFirend";
            this.btn_ComputerFirend.Size = new System.Drawing.Size(110, 29);
            this.btn_ComputerFirend.TabIndex = 4;
            this.btn_ComputerFirend.Text = "Against a friend";
            this.btn_ComputerFirend.UseVisualStyleBackColor = true;
            this.btn_ComputerFirend.Click += new System.EventHandler(this.btn_ComputerFirend_WantFriendClick);
            // 
            // r_BoardSize
            // 
            this.r_BoardSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r_BoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.r_BoardSize.Location = new System.Drawing.Point(40, 121);
            this.r_BoardSize.Name = "r_BoardSize";
            this.r_BoardSize.ReadOnly = true;
            this.r_BoardSize.Size = new System.Drawing.Size(133, 19);
            this.r_BoardSize.TabIndex = 5;
            this.r_BoardSize.Text = "Boad size";
            // 
            // btn_BoardSize
            // 
            this.btn_BoardSize.Location = new System.Drawing.Point(40, 146);
            this.btn_BoardSize.Name = "btn_BoardSize";
            this.btn_BoardSize.Size = new System.Drawing.Size(179, 123);
            this.btn_BoardSize.TabIndex = 6;
            this.btn_BoardSize.Text = "4X4";
            this.btn_BoardSize.UseVisualStyleBackColor = true;
            this.btn_BoardSize.Click += new System.EventHandler(this.btn_BoardSize_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Start.Location = new System.Drawing.Point(357, 237);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(115, 31);
            this.btn_Start.TabIndex = 7;
            this.btn_Start.Text = "Start!";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // r_FirstPlayerName
            // 
            this.r_FirstPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r_FirstPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.r_FirstPlayerName.Location = new System.Drawing.Point(40, 21);
            this.r_FirstPlayerName.Name = "r_FirstPlayerName";
            this.r_FirstPlayerName.ReadOnly = true;
            this.r_FirstPlayerName.Size = new System.Drawing.Size(133, 19);
            this.r_FirstPlayerName.TabIndex = 8;
            this.r_FirstPlayerName.Text = "First player name:";
            // 
            // r_SecondPlayerName
            // 
            this.r_SecondPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r_SecondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.r_SecondPlayerName.Location = new System.Drawing.Point(40, 49);
            this.r_SecondPlayerName.Name = "r_SecondPlayerName";
            this.r_SecondPlayerName.ReadOnly = true;
            this.r_SecondPlayerName.Size = new System.Drawing.Size(161, 19);
            this.r_SecondPlayerName.TabIndex = 9;
            this.r_SecondPlayerName.Text = "Second player name:";
            // 
            // FormSettings
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 314);
            this.Controls.Add(this.r_SecondPlayerName);
            this.Controls.Add(this.r_FirstPlayerName);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_BoardSize);
            this.Controls.Add(this.r_BoardSize);
            this.Controls.Add(this.btn_ComputerFirend);
            this.Controls.Add(this.SecondPlayerName);
            this.Controls.Add(this.FirstPlayerName);
            this.Name = "FormSettings";
            this.Text = "The Memory Game!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SecondPlayerName;
        private System.Windows.Forms.TextBox FirstPlayerName;
        private System.Windows.Forms.Button btn_ComputerFirend;
        private System.Windows.Forms.TextBox r_BoardSize;
        private System.Windows.Forms.Button btn_BoardSize;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox r_FirstPlayerName;
        private System.Windows.Forms.TextBox r_SecondPlayerName;
    }
}