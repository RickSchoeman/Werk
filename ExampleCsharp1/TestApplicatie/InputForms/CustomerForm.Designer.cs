namespace TestApplicatie.InputForms
{
    partial class CustomerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toevoegen = new System.Windows.Forms.Button();
            this.annuleren = new System.Windows.Forms.Button();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.countryBox = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.zipBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bankNameBox = new System.Windows.Forms.TextBox();
            this.accountholderBox = new System.Windows.Forms.TextBox();
            this.accountnumberBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Country:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Zipcode:";
            // 
            // toevoegen
            // 
            this.toevoegen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.toevoegen.Location = new System.Drawing.Point(12, 349);
            this.toevoegen.Name = "toevoegen";
            this.toevoegen.Size = new System.Drawing.Size(75, 23);
            this.toevoegen.TabIndex = 6;
            this.toevoegen.Text = "Toevoegen";
            this.toevoegen.UseVisualStyleBackColor = true;
            this.toevoegen.Click += new System.EventHandler(this.toevoegen_Click);
            // 
            // annuleren
            // 
            this.annuleren.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annuleren.Location = new System.Drawing.Point(303, 349);
            this.annuleren.Name = "annuleren";
            this.annuleren.Size = new System.Drawing.Size(75, 23);
            this.annuleren.TabIndex = 7;
            this.annuleren.Text = "Annuleren";
            this.annuleren.UseVisualStyleBackColor = true;
            this.annuleren.Click += new System.EventHandler(this.annuleren_Click);
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(143, 10);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(121, 20);
            this.codeBox.TabIndex = 8;
            // 
            // countryBox
            // 
            this.countryBox.FormattingEnabled = true;
            this.countryBox.Location = new System.Drawing.Point(143, 118);
            this.countryBox.Name = "countryBox";
            this.countryBox.Size = new System.Drawing.Size(121, 21);
            this.countryBox.TabIndex = 9;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(143, 38);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(121, 20);
            this.nameBox.TabIndex = 10;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(143, 66);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(121, 20);
            this.addressBox.TabIndex = 11;
            // 
            // cityBox
            // 
            this.cityBox.Location = new System.Drawing.Point(143, 92);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(121, 20);
            this.cityBox.TabIndex = 12;
            // 
            // zipBox
            // 
            this.zipBox.Location = new System.Drawing.Point(143, 144);
            this.zipBox.Name = "zipBox";
            this.zipBox.Size = new System.Drawing.Size(121, 20);
            this.zipBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Bankname:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Accountholder:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Accountnumber:";
            // 
            // bankNameBox
            // 
            this.bankNameBox.Location = new System.Drawing.Point(143, 167);
            this.bankNameBox.Name = "bankNameBox";
            this.bankNameBox.Size = new System.Drawing.Size(121, 20);
            this.bankNameBox.TabIndex = 17;
            // 
            // accountholderBox
            // 
            this.accountholderBox.Location = new System.Drawing.Point(143, 191);
            this.accountholderBox.Name = "accountholderBox";
            this.accountholderBox.Size = new System.Drawing.Size(121, 20);
            this.accountholderBox.TabIndex = 18;
            // 
            // accountnumberBox
            // 
            this.accountnumberBox.Location = new System.Drawing.Point(143, 217);
            this.accountnumberBox.Name = "accountnumberBox";
            this.accountnumberBox.Size = new System.Drawing.Size(121, 20);
            this.accountnumberBox.TabIndex = 19;
            // 
            // CustomerForm
            // 
            this.ClientSize = new System.Drawing.Size(390, 384);
            this.Controls.Add(this.accountnumberBox);
            this.Controls.Add(this.accountholderBox);
            this.Controls.Add(this.bankNameBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.zipBox);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.countryBox);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.annuleren);
            this.Controls.Add(this.toevoegen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CustomerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button toevoegen;
        private System.Windows.Forms.Button annuleren;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.ComboBox countryBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.TextBox zipBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox bankNameBox;
        private System.Windows.Forms.TextBox accountholderBox;
        private System.Windows.Forms.TextBox accountnumberBox;
    }
}