namespace TestApplicatie
{
    partial class Twinfield
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.DataComboBox = new System.Windows.Forms.ComboBox();
            this.dataInladen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.functie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.functieUitvoeren = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.resultBar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataVeld = new System.Windows.Forms.ComboBox();
            this.createNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.infoButton = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Button();
            this.XmlCheckBox = new System.Windows.Forms.CheckBox();
            this.JsonCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wissel administratie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Locatie van data:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 83);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(79, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Middleware";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 107);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Administratie";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data";
            // 
            // DataComboBox
            // 
            this.DataComboBox.FormattingEnabled = true;
            this.DataComboBox.Location = new System.Drawing.Point(401, 82);
            this.DataComboBox.Name = "DataComboBox";
            this.DataComboBox.Size = new System.Drawing.Size(121, 21);
            this.DataComboBox.TabIndex = 7;
            this.DataComboBox.SelectedIndexChanged += new System.EventHandler(this.data_SelectedIndexChanged);
            // 
            // dataInladen
            // 
            this.dataInladen.Location = new System.Drawing.Point(401, 110);
            this.dataInladen.Name = "dataInladen";
            this.dataInladen.Size = new System.Drawing.Size(121, 23);
            this.dataInladen.TabIndex = 8;
            this.dataInladen.Text = "Data inladen";
            this.dataInladen.UseVisualStyleBackColor = true;
            this.dataInladen.Click += new System.EventHandler(this.dataInladen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Functie";
            // 
            // functie
            // 
            this.functie.FormattingEnabled = true;
            this.functie.Location = new System.Drawing.Point(12, 215);
            this.functie.Name = "functie";
            this.functie.Size = new System.Drawing.Size(121, 21);
            this.functie.TabIndex = 10;
            this.functie.SelectedIndexChanged += new System.EventHandler(this.functie_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Eindlocatie data";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(140, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // functieUitvoeren
            // 
            this.functieUitvoeren.Location = new System.Drawing.Point(12, 243);
            this.functieUitvoeren.Name = "functieUitvoeren";
            this.functieUitvoeren.Size = new System.Drawing.Size(121, 23);
            this.functieUitvoeren.TabIndex = 13;
            this.functieUitvoeren.Text = "Functie uitvoeren";
            this.functieUitvoeren.UseVisualStyleBackColor = true;
            this.functieUitvoeren.Click += new System.EventHandler(this.functieUitvoeren_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 272);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(613, 97);
            this.LogBox.TabIndex = 14;
            this.LogBox.Text = "";
            // 
            // resultBar
            // 
            this.resultBar.Location = new System.Drawing.Point(140, 245);
            this.resultBar.Name = "resultBar";
            this.resultBar.ReadOnly = true;
            this.resultBar.Size = new System.Drawing.Size(485, 20);
            this.resultBar.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selecteer dataveld";
            // 
            // dataVeld
            // 
            this.dataVeld.FormattingEnabled = true;
            this.dataVeld.Location = new System.Drawing.Point(401, 173);
            this.dataVeld.Name = "dataVeld";
            this.dataVeld.Size = new System.Drawing.Size(121, 21);
            this.dataVeld.TabIndex = 17;
            // 
            // createNew
            // 
            this.createNew.Location = new System.Drawing.Point(401, 198);
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(121, 24);
            this.createNew.TabIndex = 18;
            this.createNew.Text = "Maak nieuw veld aan*";
            this.createNew.UseVisualStyleBackColor = true;
            this.createNew.Click += new System.EventHandler(this.createNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "*Alleen voor middleware";
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(512, 375);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(113, 23);
            this.infoButton.TabIndex = 20;
            this.infoButton.Text = "Meer info";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.info_Click);
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(12, 375);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(113, 23);
            this.results.TabIndex = 21;
            this.results.Text = "Open resultaten";
            this.results.UseVisualStyleBackColor = true;
            this.results.Click += new System.EventHandler(this.results_Click);
            // 
            // XmlCheckBox
            // 
            this.XmlCheckBox.AutoSize = true;
            this.XmlCheckBox.Location = new System.Drawing.Point(140, 217);
            this.XmlCheckBox.Name = "XmlCheckBox";
            this.XmlCheckBox.Size = new System.Drawing.Size(81, 17);
            this.XmlCheckBox.TabIndex = 22;
            this.XmlCheckBox.Text = "Export XML";
            this.XmlCheckBox.UseVisualStyleBackColor = true;
            this.XmlCheckBox.Visible = false;
            // 
            // JsonCheckBox
            // 
            this.JsonCheckBox.AutoSize = true;
            this.JsonCheckBox.Location = new System.Drawing.Point(227, 217);
            this.JsonCheckBox.Name = "JsonCheckBox";
            this.JsonCheckBox.Size = new System.Drawing.Size(87, 17);
            this.JsonCheckBox.TabIndex = 23;
            this.JsonCheckBox.Text = "Export JSON";
            this.JsonCheckBox.UseVisualStyleBackColor = true;
            this.JsonCheckBox.Visible = false;
            // 
            // Twinfield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 403);
            this.Controls.Add(this.JsonCheckBox);
            this.Controls.Add(this.XmlCheckBox);
            this.Controls.Add(this.results);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.createNew);
            this.Controls.Add(this.dataVeld);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resultBar);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.functieUitvoeren);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.functie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataInladen);
            this.Controls.Add(this.DataComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Twinfield";
            this.Text = "Twinfield";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DataComboBox;
        private System.Windows.Forms.Button dataInladen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox functie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button functieUitvoeren;
        public System.Windows.Forms.RichTextBox LogBox;
        public System.Windows.Forms.TextBox resultBar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox dataVeld;
        private System.Windows.Forms.Button createNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button results;
        public System.Windows.Forms.CheckBox XmlCheckBox;
        public System.Windows.Forms.CheckBox JsonCheckBox;
    }
}