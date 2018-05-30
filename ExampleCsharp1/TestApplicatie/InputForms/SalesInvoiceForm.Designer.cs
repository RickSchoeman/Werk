namespace TestApplicatie.InputForms
{
    partial class SalesInvoiceForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.customerBox = new System.Windows.Forms.ComboBox();
            this.currencyBox = new System.Windows.Forms.ComboBox();
            this.articleBox = new System.Windows.Forms.ComboBox();
            this.subarticleBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.vatBox = new System.Windows.Forms.ComboBox();
            this.unitsBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.annuleren = new System.Windows.Forms.Button();
            this.toevoegen = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoicetype:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Currency:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Article:*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Subarticle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Units:*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Quantity:*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Vatcode:*";
            // 
            // customerBox
            // 
            this.customerBox.FormattingEnabled = true;
            this.customerBox.Location = new System.Drawing.Point(143, 32);
            this.customerBox.Name = "customerBox";
            this.customerBox.Size = new System.Drawing.Size(237, 21);
            this.customerBox.TabIndex = 9;
            // 
            // currencyBox
            // 
            this.currencyBox.FormattingEnabled = true;
            this.currencyBox.Location = new System.Drawing.Point(143, 54);
            this.currencyBox.Name = "currencyBox";
            this.currencyBox.Size = new System.Drawing.Size(237, 21);
            this.currencyBox.TabIndex = 10;
            // 
            // articleBox
            // 
            this.articleBox.FormattingEnabled = true;
            this.articleBox.Location = new System.Drawing.Point(143, 76);
            this.articleBox.Name = "articleBox";
            this.articleBox.Size = new System.Drawing.Size(237, 21);
            this.articleBox.TabIndex = 11;
            this.articleBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // subarticleBox
            // 
            this.subarticleBox.FormattingEnabled = true;
            this.subarticleBox.Location = new System.Drawing.Point(143, 98);
            this.subarticleBox.Name = "subarticleBox";
            this.subarticleBox.Size = new System.Drawing.Size(237, 21);
            this.subarticleBox.TabIndex = 12;
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(143, 10);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(237, 21);
            this.typeBox.TabIndex = 13;
            // 
            // vatBox
            // 
            this.vatBox.FormattingEnabled = true;
            this.vatBox.Location = new System.Drawing.Point(143, 187);
            this.vatBox.Name = "vatBox";
            this.vatBox.Size = new System.Drawing.Size(237, 21);
            this.vatBox.TabIndex = 14;
            // 
            // unitsBox
            // 
            this.unitsBox.Location = new System.Drawing.Point(143, 120);
            this.unitsBox.Name = "unitsBox";
            this.unitsBox.Size = new System.Drawing.Size(237, 20);
            this.unitsBox.TabIndex = 15;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(143, 142);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(237, 20);
            this.descriptionBox.TabIndex = 16;
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(143, 164);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(237, 20);
            this.quantityBox.TabIndex = 17;
            // 
            // annuleren
            // 
            this.annuleren.Location = new System.Drawing.Point(12, 349);
            this.annuleren.Name = "annuleren";
            this.annuleren.Size = new System.Drawing.Size(75, 23);
            this.annuleren.TabIndex = 18;
            this.annuleren.Text = "Annuleren";
            this.annuleren.UseVisualStyleBackColor = true;
            this.annuleren.Click += new System.EventHandler(this.annuleren_Click);
            // 
            // toevoegen
            // 
            this.toevoegen.Location = new System.Drawing.Point(305, 349);
            this.toevoegen.Name = "toevoegen";
            this.toevoegen.Size = new System.Drawing.Size(75, 23);
            this.toevoegen.TabIndex = 19;
            this.toevoegen.Text = "Toevoegen";
            this.toevoegen.UseVisualStyleBackColor = true;
            this.toevoegen.Click += new System.EventHandler(this.toevoegen_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "*Verplichte velden";
            // 
            // SalesInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 384);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toevoegen);
            this.Controls.Add(this.annuleren);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.unitsBox);
            this.Controls.Add(this.vatBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.subarticleBox);
            this.Controls.Add(this.articleBox);
            this.Controls.Add(this.currencyBox);
            this.Controls.Add(this.customerBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SalesInvoiceForm";
            this.Text = "SalesInvoiceForm";
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox customerBox;
        private System.Windows.Forms.ComboBox currencyBox;
        private System.Windows.Forms.ComboBox articleBox;
        private System.Windows.Forms.ComboBox subarticleBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.ComboBox vatBox;
        private System.Windows.Forms.TextBox unitsBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Button annuleren;
        private System.Windows.Forms.Button toevoegen;
        private System.Windows.Forms.Label label10;
    }
}