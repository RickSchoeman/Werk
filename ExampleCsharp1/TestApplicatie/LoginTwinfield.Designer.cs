namespace TestApplicatie
{
    partial class LoginTwinfield
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerUrl = new System.Windows.Forms.TextBox();
            this.Gebruiker = new System.Windows.Forms.TextBox();
            this.Wachtwoord = new System.Windows.Forms.TextBox();
            this.Organisatie = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log in op administratiesysteem:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gebruiker:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wachtwoord:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Organisatie:";
            // 
            // ServerUrl
            // 
            this.ServerUrl.Location = new System.Drawing.Point(179, 42);
            this.ServerUrl.Name = "ServerUrl";
            this.ServerUrl.Size = new System.Drawing.Size(100, 20);
            this.ServerUrl.TabIndex = 5;
            this.ServerUrl.Text = "https://login.twinfield.com";
            // 
            // Gebruiker
            // 
            this.Gebruiker.Location = new System.Drawing.Point(179, 64);
            this.Gebruiker.Name = "Gebruiker";
            this.Gebruiker.Size = new System.Drawing.Size(100, 20);
            this.Gebruiker.TabIndex = 6;
            this.Gebruiker.Text = "API000110";
            // 
            // Wachtwoord
            // 
            this.Wachtwoord.Location = new System.Drawing.Point(179, 87);
            this.Wachtwoord.Name = "Wachtwoord";
            this.Wachtwoord.PasswordChar = '*';
            this.Wachtwoord.Size = new System.Drawing.Size(100, 20);
            this.Wachtwoord.TabIndex = 7;
            this.Wachtwoord.Text = "SforSoftware12";
            // 
            // Organisatie
            // 
            this.Organisatie.Location = new System.Drawing.Point(179, 109);
            this.Organisatie.Name = "Organisatie";
            this.Organisatie.Size = new System.Drawing.Size(100, 20);
            this.Organisatie.TabIndex = 8;
            this.Organisatie.Text = "TWINAPPS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginTwinfield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Organisatie);
            this.Controls.Add(this.Wachtwoord);
            this.Controls.Add(this.Gebruiker);
            this.Controls.Add(this.ServerUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginTwinfield";
            this.Text = "LoginTwinfield";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServerUrl;
        private System.Windows.Forms.TextBox Gebruiker;
        private System.Windows.Forms.TextBox Wachtwoord;
        private System.Windows.Forms.TextBox Organisatie;
        private System.Windows.Forms.Button button1;
    }
}