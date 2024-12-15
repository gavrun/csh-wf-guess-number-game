namespace csh_wf_guess_number_game
{
    partial class ModeForm
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
            this.buttonMainMode = new System.Windows.Forms.Button();
            this.buttonProMode = new System.Windows.Forms.Button();
            this.buttonMultiMode = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMainMode
            // 
            this.buttonMainMode.Location = new System.Drawing.Point(50, 279);
            this.buttonMainMode.Name = "buttonMainMode";
            this.buttonMainMode.Size = new System.Drawing.Size(75, 23);
            this.buttonMainMode.TabIndex = 0;
            this.buttonMainMode.Text = "Main Mode";
            this.buttonMainMode.UseVisualStyleBackColor = true;
            this.buttonMainMode.Click += new System.EventHandler(this.buttonMainMode_Click);
            // 
            // buttonProMode
            // 
            this.buttonProMode.Location = new System.Drawing.Point(200, 279);
            this.buttonProMode.Name = "buttonProMode";
            this.buttonProMode.Size = new System.Drawing.Size(75, 23);
            this.buttonProMode.TabIndex = 1;
            this.buttonProMode.Text = "Pro Mode";
            this.buttonProMode.UseVisualStyleBackColor = true;
            this.buttonProMode.Click += new System.EventHandler(this.buttonProMode_Click);
            // 
            // buttonMultiMode
            // 
            this.buttonMultiMode.Location = new System.Drawing.Point(347, 279);
            this.buttonMultiMode.Name = "buttonMultiMode";
            this.buttonMultiMode.Size = new System.Drawing.Size(75, 23);
            this.buttonMultiMode.TabIndex = 2;
            this.buttonMultiMode.Text = "Multi Mode";
            this.buttonMultiMode.UseVisualStyleBackColor = true;
            this.buttonMultiMode.Click += new System.EventHandler(this.buttonMultiMode_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::csh_wf_guess_number_game.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(39, 130);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::csh_wf_guess_number_game.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(187, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::csh_wf_guess_number_game.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(334, 130);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(200, 398);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(187, 51);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter your name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(required for ProMode)";
            // 
            // ModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonMultiMode);
            this.Controls.Add(this.buttonProMode);
            this.Controls.Add(this.buttonMainMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModeForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMainMode;
        private System.Windows.Forms.Button buttonProMode;
        private System.Windows.Forms.Button buttonMultiMode;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}