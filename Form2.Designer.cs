namespace JACKBLACK
{
    partial class Form2
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
            this.label_scor = new System.Windows.Forms.Label();
            this.buton_stand = new System.Windows.Forms.Button();
            this.buton_hit = new System.Windows.Forms.Button();
            this.buton_resetare = new System.Windows.Forms.Button();
            this.buton_carti = new System.Windows.Forms.Button();
            this.label_rezultat = new System.Windows.Forms.Label();
            this.buton_hit2 = new System.Windows.Forms.Button();
            this.buton_stand2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_scor
            // 
            this.label_scor.AutoSize = true;
            this.label_scor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_scor.Location = new System.Drawing.Point(27, 24);
            this.label_scor.Name = "label_scor";
            this.label_scor.Size = new System.Drawing.Size(258, 32);
            this.label_scor.TabIndex = 0;
            this.label_scor.Text = "SCOR JUCATOR1:";
            // 
            // buton_stand
            // 
            this.buton_stand.Location = new System.Drawing.Point(305, 636);
            this.buton_stand.Name = "buton_stand";
            this.buton_stand.Size = new System.Drawing.Size(99, 49);
            this.buton_stand.TabIndex = 2;
            this.buton_stand.Text = "TRAGE ";
            this.buton_stand.UseVisualStyleBackColor = true;
            this.buton_stand.Click += new System.EventHandler(this.button1_Click);
            // 
            // buton_hit
            // 
            this.buton_hit.Location = new System.Drawing.Point(93, 636);
            this.buton_hit.Name = "buton_hit";
            this.buton_hit.Size = new System.Drawing.Size(126, 49);
            this.buton_hit.TabIndex = 3;
            this.buton_hit.Text = "RĂMÂI";
            this.buton_hit.UseVisualStyleBackColor = true;
            this.buton_hit.Click += new System.EventHandler(this.button2_Click);
            // 
            // buton_resetare
            // 
            this.buton_resetare.Location = new System.Drawing.Point(1200, 27);
            this.buton_resetare.Name = "buton_resetare";
            this.buton_resetare.Size = new System.Drawing.Size(151, 64);
            this.buton_resetare.TabIndex = 4;
            this.buton_resetare.Text = "JOC NOU";
            this.buton_resetare.UseVisualStyleBackColor = true;
            this.buton_resetare.Click += new System.EventHandler(this.buton_JocNou_Click);
            // 
            // buton_carti
            // 
            this.buton_carti.Location = new System.Drawing.Point(973, 27);
            this.buton_carti.Name = "buton_carti";
            this.buton_carti.Size = new System.Drawing.Size(151, 64);
            this.buton_carti.TabIndex = 5;
            this.buton_carti.Text = "IESIRE";
            this.buton_carti.UseVisualStyleBackColor = true;
            this.buton_carti.Click += new System.EventHandler(this.button4_Click);
            // 
            // label_rezultat
            // 
            this.label_rezultat.AutoSize = true;
            this.label_rezultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rezultat.Location = new System.Drawing.Point(27, 59);
            this.label_rezultat.Name = "label_rezultat";
            this.label_rezultat.Size = new System.Drawing.Size(167, 32);
            this.label_rezultat.TabIndex = 6;
            this.label_rezultat.Text = "REZULTAT:";
            // 
            // buton_hit2
            // 
            this.buton_hit2.Location = new System.Drawing.Point(1008, 636);
            this.buton_hit2.Name = "buton_hit2";
            this.buton_hit2.Size = new System.Drawing.Size(126, 49);
            this.buton_hit2.TabIndex = 8;
            this.buton_hit2.Text = "RAMAI";
            this.buton_hit2.UseVisualStyleBackColor = true;
            this.buton_hit2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buton_stand2
            // 
            this.buton_stand2.Location = new System.Drawing.Point(1307, 636);
            this.buton_stand2.Name = "buton_stand2";
            this.buton_stand2.Size = new System.Drawing.Size(126, 49);
            this.buton_stand2.TabIndex = 9;
            this.buton_stand2.Text = "TRAGE";
            this.buton_stand2.UseVisualStyleBackColor = true;
            this.buton_stand2.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::JACKBLACK.Properties.Resources.Screenshot_2026_01_08_1757533;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1678, 731);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1571, 736);
            this.Controls.Add(this.buton_stand2);
            this.Controls.Add(this.buton_hit2);
            this.Controls.Add(this.label_rezultat);
            this.Controls.Add(this.buton_carti);
            this.Controls.Add(this.buton_resetare);
            this.Controls.Add(this.buton_hit);
            this.Controls.Add(this.buton_stand);
            this.Controls.Add(this.label_scor);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_scor;
        private System.Windows.Forms.Button buton_stand;
        private System.Windows.Forms.Button buton_hit;
        private System.Windows.Forms.Button buton_resetare;
        private System.Windows.Forms.Button buton_carti;
        private System.Windows.Forms.Label label_rezultat;
        private System.Windows.Forms.Button buton_hit2;
        private System.Windows.Forms.Button buton_stand2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}