namespace JACKBLACK
{
    partial class Form_Conectare
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
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butonConectare = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelConectare = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butonConectare
            // 
            this.butonConectare.Location = new System.Drawing.Point(12, 33);
            this.butonConectare.Name = "butonConectare";
            this.butonConectare.Size = new System.Drawing.Size(196, 83);
            this.butonConectare.TabIndex = 0;
            this.butonConectare.Text = "CONECTARE SERVER";
            this.butonConectare.UseVisualStyleBackColor = true;
            this.butonConectare.Click += new System.EventHandler(this.butonConectare_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.Location = new System.Drawing.Point(534, 33);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 38);
            this.textBoxIP.TabIndex = 1;
            // 
            // labelConectare
            // 
            this.labelConectare.AutoSize = true;
            this.labelConectare.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConectare.Location = new System.Drawing.Point(238, 33);
            this.labelConectare.Name = "labelConectare";
            this.labelConectare.Size = new System.Drawing.Size(237, 32);
            this.labelConectare.TabIndex = 2;
            this.labelConectare.Text = "Introdu adresa IP:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 81);
            this.button1.TabIndex = 3;
            this.button1.Text = "IESIRE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Conectare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelConectare);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.butonConectare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Conectare";
            this.Text = "Form_Conectare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butonConectare;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelConectare;
        private System.Windows.Forms.Button button1;
    }
}