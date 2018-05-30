namespace TestApplicatie.InputForms
{
    partial class ArticleForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.toevoegen = new System.Windows.Forms.Button();
            this.annuleren = new System.Windows.Forms.Button();
            this.vatBox = new System.Windows.Forms.ComboBox();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.unitBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.supplierBox = new System.Windows.Forms.ComboBox();
            this.maskBox = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ledgerBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.centerBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vat code:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sales price:*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Units:*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Supplier code:*";
            // 
            // toevoegen
            // 
            this.toevoegen.Location = new System.Drawing.Point(300, 261);
            this.toevoegen.Name = "toevoegen";
            this.toevoegen.Size = new System.Drawing.Size(75, 23);
            this.toevoegen.TabIndex = 7;
            this.toevoegen.Text = "Toevoegen";
            this.toevoegen.UseVisualStyleBackColor = true;
            this.toevoegen.Click += new System.EventHandler(this.toevoegen_Click);
            // 
            // annuleren
            // 
            this.annuleren.Location = new System.Drawing.Point(12, 261);
            this.annuleren.Name = "annuleren";
            this.annuleren.Size = new System.Drawing.Size(75, 23);
            this.annuleren.TabIndex = 8;
            this.annuleren.Text = "Annuleren";
            this.annuleren.UseVisualStyleBackColor = true;
            this.annuleren.Click += new System.EventHandler(this.annuleren_Click);
            // 
            // vatBox
            // 
            this.vatBox.FormattingEnabled = true;
            this.vatBox.Location = new System.Drawing.Point(138, 62);
            this.vatBox.Name = "vatBox";
            this.vatBox.Size = new System.Drawing.Size(237, 21);
            this.vatBox.TabIndex = 9;
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(138, 10);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(237, 20);
            this.codeBox.TabIndex = 10;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(138, 36);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(237, 20);
            this.nameBox.TabIndex = 11;
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(138, 88);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(237, 20);
            this.priceBox.TabIndex = 12;
            // 
            // unitBox
            // 
            this.unitBox.Location = new System.Drawing.Point(138, 115);
            this.unitBox.Name = "unitBox";
            this.unitBox.Size = new System.Drawing.Size(237, 20);
            this.unitBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "*Verplichte velden";
            // 
            // supplierBox
            // 
            this.supplierBox.FormattingEnabled = true;
            this.supplierBox.Location = new System.Drawing.Point(138, 141);
            this.supplierBox.Name = "supplierBox";
            this.supplierBox.Size = new System.Drawing.Size(237, 21);
            this.supplierBox.TabIndex = 17;
            // 
            // maskBox
            // 
            this.maskBox.AutoSize = true;
            this.maskBox.Location = new System.Drawing.Point(13, 199);
            this.maskBox.Name = "maskBox";
            this.maskBox.Size = new System.Drawing.Size(0, 13);
            this.maskBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "General ledger:*";
            // 
            // ledgerBox
            // 
            this.ledgerBox.FormattingEnabled = true;
            this.ledgerBox.Location = new System.Drawing.Point(138, 166);
            this.ledgerBox.Name = "ledgerBox";
            this.ledgerBox.Size = new System.Drawing.Size(237, 21);
            this.ledgerBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Cost center:*";
            // 
            // centerBox
            // 
            this.centerBox.FormattingEnabled = true;
            this.centerBox.Location = new System.Drawing.Point(138, 193);
            this.centerBox.Name = "centerBox";
            this.centerBox.Size = new System.Drawing.Size(237, 21);
            this.centerBox.TabIndex = 22;
            // 
            // ArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 296);
            this.Controls.Add(this.centerBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ledgerBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskBox);
            this.Controls.Add(this.supplierBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.unitBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.vatBox);
            this.Controls.Add(this.annuleren);
            this.Controls.Add(this.toevoegen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ArticleForm";
            this.Text = "ArticleForm";
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
        private System.Windows.Forms.Button toevoegen;
        private System.Windows.Forms.Button annuleren;
        private System.Windows.Forms.ComboBox vatBox;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.TextBox unitBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox supplierBox;
        private System.Windows.Forms.Label maskBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ledgerBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox centerBox;
    }
}