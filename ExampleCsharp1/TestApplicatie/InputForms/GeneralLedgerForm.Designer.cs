namespace TestApplicatie.InputForms
{
    partial class GeneralLedgerForm
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
            this.annuleren = new System.Windows.Forms.Button();
            this.toevoegen = new System.Windows.Forms.Button();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.vatBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code:**";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vatcode:*";
            // 
            // annuleren
            // 
            this.annuleren.Location = new System.Drawing.Point(12, 177);
            this.annuleren.Name = "annuleren";
            this.annuleren.Size = new System.Drawing.Size(75, 23);
            this.annuleren.TabIndex = 3;
            this.annuleren.Text = "Annuleren";
            this.annuleren.UseVisualStyleBackColor = true;
            this.annuleren.Click += new System.EventHandler(this.annuleren_Click);
            // 
            // toevoegen
            // 
            this.toevoegen.Location = new System.Drawing.Point(305, 177);
            this.toevoegen.Name = "toevoegen";
            this.toevoegen.Size = new System.Drawing.Size(75, 23);
            this.toevoegen.TabIndex = 4;
            this.toevoegen.Text = "Toevoegen";
            this.toevoegen.UseVisualStyleBackColor = true;
            this.toevoegen.Click += new System.EventHandler(this.toevoegen_Click);
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(161, 10);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(219, 20);
            this.codeBox.TabIndex = 5;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(161, 32);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(219, 20);
            this.nameBox.TabIndex = 6;
            // 
            // vatBox
            // 
            this.vatBox.FormattingEnabled = true;
            this.vatBox.Location = new System.Drawing.Point(161, 56);
            this.vatBox.Name = "vatBox";
            this.vatBox.Size = new System.Drawing.Size(219, 21);
            this.vatBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "*Verplichte velden";
            // 
            // maskBox
            // 
            this.maskBox.AutoSize = true;
            this.maskBox.Location = new System.Drawing.Point(13, 112);
            this.maskBox.Name = "maskBox";
            this.maskBox.Size = new System.Drawing.Size(0, 13);
            this.maskBox.TabIndex = 11;
            // 
            // GeneralLedgerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 212);
            this.Controls.Add(this.maskBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vatBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.toevoegen);
            this.Controls.Add(this.annuleren);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GeneralLedgerForm";
            this.Text = "GeneralLedgerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button annuleren;
        private System.Windows.Forms.Button toevoegen;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ComboBox vatBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label maskBox;
    }
}