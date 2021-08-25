
namespace FP_DanielAizenband_Client
{
    partial class GameForm
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
            this.StartGame_button = new System.Windows.Forms.Button();
            this.Recordings_button = new System.Windows.Forms.Button();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.LogOut_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGame_button
            // 
            this.StartGame_button.BackColor = System.Drawing.Color.Black;
            this.StartGame_button.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame_button.ForeColor = System.Drawing.Color.Fuchsia;
            this.StartGame_button.Location = new System.Drawing.Point(140, 179);
            this.StartGame_button.Margin = new System.Windows.Forms.Padding(0);
            this.StartGame_button.Name = "StartGame_button";
            this.StartGame_button.Size = new System.Drawing.Size(234, 80);
            this.StartGame_button.TabIndex = 0;
            this.StartGame_button.Text = "Start new game";
            this.StartGame_button.UseVisualStyleBackColor = false;
            this.StartGame_button.Click += new System.EventHandler(this.StartGame_button_Click);
            // 
            // Recordings_button
            // 
            this.Recordings_button.BackColor = System.Drawing.Color.Black;
            this.Recordings_button.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recordings_button.ForeColor = System.Drawing.Color.Fuchsia;
            this.Recordings_button.Location = new System.Drawing.Point(423, 179);
            this.Recordings_button.Margin = new System.Windows.Forms.Padding(0);
            this.Recordings_button.Name = "Recordings_button";
            this.Recordings_button.Size = new System.Drawing.Size(244, 80);
            this.Recordings_button.TabIndex = 1;
            this.Recordings_button.Text = "Show available recordings";
            this.Recordings_button.UseVisualStyleBackColor = false;
            this.Recordings_button.Click += new System.EventHandler(this.Recordings_button_Click);
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerLabel.Location = new System.Drawing.Point(305, 61);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(103, 42);
            this.PlayerLabel.TabIndex = 2;
            this.PlayerLabel.Text = "Hello";
            // 
            // LogOut_button
            // 
            this.LogOut_button.BackColor = System.Drawing.Color.Black;
            this.LogOut_button.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_button.ForeColor = System.Drawing.Color.Fuchsia;
            this.LogOut_button.Location = new System.Drawing.Point(312, 348);
            this.LogOut_button.Name = "LogOut_button";
            this.LogOut_button.Size = new System.Drawing.Size(157, 54);
            this.LogOut_button.TabIndex = 3;
            this.LogOut_button.Text = "Log Out";
            this.LogOut_button.UseVisualStyleBackColor = false;
            this.LogOut_button.Click += new System.EventHandler(this.LogOut_button_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::FP_DanielAizenband_Client.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(849, 484);
            this.Controls.Add(this.LogOut_button);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.Recordings_button);
            this.Controls.Add(this.StartGame_button);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGame_button;
        private System.Windows.Forms.Button Recordings_button;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.Button LogOut_button;
    }
}