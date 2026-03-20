namespace JACKBLACK
{
    partial class Form1
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
        public Form2 f2;
        public Form_Conectare f_conectare;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buton_Start = new System.Windows.Forms.Button();
            this.buton_iesire = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.butonJoin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buton_Start
            // 
            this.buton_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buton_Start.Location = new System.Drawing.Point(69, 389);
            this.buton_Start.Name = "buton_Start";
            this.buton_Start.Size = new System.Drawing.Size(183, 73);
            this.buton_Start.TabIndex = 0;
            this.buton_Start.Text = "START SERVER";
            this.buton_Start.UseVisualStyleBackColor = true;
            this.buton_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // buton_iesire
            // 
            this.buton_iesire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buton_iesire.BackColor = System.Drawing.Color.White;
            this.buton_iesire.Location = new System.Drawing.Point(584, 389);
            this.buton_iesire.Name = "buton_iesire";
            this.buton_iesire.Size = new System.Drawing.Size(159, 73);
            this.buton_iesire.TabIndex = 1;
            this.buton_iesire.Text = "EXIT";
            this.buton_iesire.UseVisualStyleBackColor = false;
            this.buton_iesire.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(275, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(271, 50);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "BLACKJACK";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(63, 317);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 32);
            this.labelStatus.TabIndex = 3;
            // 
            // butonJoin
            // 
            this.butonJoin.Location = new System.Drawing.Point(343, 389);
            this.butonJoin.Name = "butonJoin";
            this.butonJoin.Size = new System.Drawing.Size(161, 73);
            this.butonJoin.TabIndex = 4;
            this.butonJoin.Text = "CONECTARE";
            this.butonJoin.UseVisualStyleBackColor = true;
            this.butonJoin.Click += new System.EventHandler(this.butonJoin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JACKBLACK.Properties.Resources.Screenshot_2026_01_08_1757533;
            this.pictureBox1.Location = new System.Drawing.Point(1, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(833, 560);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 553);
            this.Controls.Add(this.butonJoin);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buton_iesire);
            this.Controls.Add(this.buton_Start);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buton_Start;
        private System.Windows.Forms.Button buton_iesire;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button butonJoin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

