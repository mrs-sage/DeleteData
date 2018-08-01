namespace DeleteDataBases
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblLastLocalDelete = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.optCreateDate = new System.Windows.Forms.RadioButton();
            this.optModificationDate = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericWeeks = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFolderPath = new System.Windows.Forms.TextBox();
            this.BtnOpenFolder = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLastElimination = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxSQLInstance = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSQLError = new System.Windows.Forms.Button();
            this.btnLocalError = new System.Windows.Forms.Button();
            this.btnSQLHistory = new System.Windows.Forms.Button();
            this.btnLocalHistory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeeks)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-5, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 278);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.lblLastLocalDelete);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.optCreateDate);
            this.tabPage1.Controls.Add(this.optModificationDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.numericWeeks);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtFolderPath);
            this.tabPage1.Controls.Add(this.BtnOpenFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "          Ficheiros Locais          ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(34, 139);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 23);
            this.btnDelete.TabIndex = 92;
            this.btnDelete.Text = "Eliminar dados locais";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblLastLocalDelete
            // 
            this.lblLastLocalDelete.AutoSize = true;
            this.lblLastLocalDelete.Location = new System.Drawing.Point(360, 144);
            this.lblLastLocalDelete.Name = "lblLastLocalDelete";
            this.lblLastLocalDelete.Size = new System.Drawing.Size(95, 13);
            this.lblLastLocalDelete.TabIndex = 91;
            this.lblLastLocalDelete.Text = "Última eliminação: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(345, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 90;
            this.label6.Text = "Informação:";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Elimina pastas e ficheiros por";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optCreateDate
            // 
            this.optCreateDate.AutoSize = true;
            this.optCreateDate.Checked = true;
            this.optCreateDate.Location = new System.Drawing.Point(187, 103);
            this.optCreateDate.Name = "optCreateDate";
            this.optCreateDate.Size = new System.Drawing.Size(102, 17);
            this.optCreateDate.TabIndex = 88;
            this.optCreateDate.TabStop = true;
            this.optCreateDate.Text = "Data de Criação";
            this.optCreateDate.UseVisualStyleBackColor = true;
            // 
            // optModificationDate
            // 
            this.optModificationDate.AutoSize = true;
            this.optModificationDate.Location = new System.Drawing.Point(307, 103);
            this.optModificationDate.Name = "optModificationDate";
            this.optModificationDate.Size = new System.Drawing.Size(124, 17);
            this.optModificationDate.TabIndex = 87;
            this.optModificationDate.Text = "Data de Modificação";
            this.optModificationDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Elimina cada x semana";
            // 
            // numericWeeks
            // 
            this.numericWeeks.Location = new System.Drawing.Point(187, 68);
            this.numericWeeks.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeeks.Name = "numericWeeks";
            this.numericWeeks.Size = new System.Drawing.Size(42, 20);
            this.numericWeeks.TabIndex = 85;
            this.numericWeeks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeeks.ValueChanged += new System.EventHandler(this.numericWeeks_ValueChanged);
            this.numericWeeks.Validating += new System.ComponentModel.CancelEventHandler(this.numericWeeks_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Definições:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Pasta base de dados análise";
            // 
            // TxtFolderPath
            // 
            this.TxtFolderPath.Enabled = false;
            this.TxtFolderPath.Location = new System.Drawing.Point(207, 41);
            this.TxtFolderPath.Name = "TxtFolderPath";
            this.TxtFolderPath.Size = new System.Drawing.Size(302, 20);
            this.TxtFolderPath.TabIndex = 82;
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.Image = global::DeleteDataBases.Properties.Resources.folder;
            this.BtnOpenFolder.Location = new System.Drawing.Point(187, 40);
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.Size = new System.Drawing.Size(22, 22);
            this.BtnOpenFolder.TabIndex = 81;
            this.BtnOpenFolder.UseVisualStyleBackColor = true;
            this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.lblLastElimination);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.listBoxSQLInstance);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "          SQL DataBases          ";
            // 
            // lblLastElimination
            // 
            this.lblLastElimination.AutoSize = true;
            this.lblLastElimination.Location = new System.Drawing.Point(270, 141);
            this.lblLastElimination.Name = "lblLastElimination";
            this.lblLastElimination.Size = new System.Drawing.Size(92, 13);
            this.lblLastElimination.TabIndex = 91;
            this.lblLastElimination.Text = "Última eliminação:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selecione a instância:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Apresentar base de dados na Instância";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxSQLInstance
            // 
            this.listBoxSQLInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listBoxSQLInstance.FormattingEnabled = true;
            this.listBoxSQLInstance.Location = new System.Drawing.Point(15, 36);
            this.listBoxSQLInstance.Name = "listBoxSQLInstance";
            this.listBoxSQLInstance.Size = new System.Drawing.Size(235, 121);
            this.listBoxSQLInstance.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.txtLog);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnSQLError);
            this.tabPage3.Controls.Add(this.btnLocalError);
            this.tabPage3.Controls.Add(this.btnSQLHistory);
            this.tabPage3.Controls.Add(this.btnLocalHistory);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "          Logs          ";
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(187, 15);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(323, 120);
            this.txtLog.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(184, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Os log são eliminados automaticamente após um mês!";
            // 
            // btnSQLError
            // 
            this.btnSQLError.Location = new System.Drawing.Point(28, 128);
            this.btnSQLError.Name = "btnSQLError";
            this.btnSQLError.Size = new System.Drawing.Size(140, 23);
            this.btnSQLError.TabIndex = 96;
            this.btnSQLError.Text = "Erros Críticos SQL";
            this.btnSQLError.UseVisualStyleBackColor = true;
            this.btnSQLError.Click += new System.EventHandler(this.btnSQLError_Click);
            // 
            // btnLocalError
            // 
            this.btnLocalError.Location = new System.Drawing.Point(28, 44);
            this.btnLocalError.Name = "btnLocalError";
            this.btnLocalError.Size = new System.Drawing.Size(140, 23);
            this.btnLocalError.TabIndex = 95;
            this.btnLocalError.Text = "Erros Críticos Pasta Local";
            this.btnLocalError.UseVisualStyleBackColor = true;
            this.btnLocalError.Click += new System.EventHandler(this.btnLocalError_Click);
            // 
            // btnSQLHistory
            // 
            this.btnSQLHistory.Location = new System.Drawing.Point(28, 99);
            this.btnSQLHistory.Name = "btnSQLHistory";
            this.btnSQLHistory.Size = new System.Drawing.Size(140, 23);
            this.btnSQLHistory.TabIndex = 94;
            this.btnSQLHistory.Text = "Histórico SQL";
            this.btnSQLHistory.UseVisualStyleBackColor = true;
            this.btnSQLHistory.Click += new System.EventHandler(this.btnSQLHistory_Click);
            // 
            // btnLocalHistory
            // 
            this.btnLocalHistory.Location = new System.Drawing.Point(28, 15);
            this.btnLocalHistory.Name = "btnLocalHistory";
            this.btnLocalHistory.Size = new System.Drawing.Size(140, 23);
            this.btnLocalHistory.TabIndex = 93;
            this.btnLocalHistory.Text = "Histórico Pasta Local";
            this.btnLocalHistory.UseVisualStyleBackColor = true;
            this.btnLocalHistory.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(-11, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1041, 609);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 191);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Eliminar base de dados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeeks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxSQLInstance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFolderPath;
        private System.Windows.Forms.Button BtnOpenFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericWeeks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblLastLocalDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton optCreateDate;
        private System.Windows.Forms.RadioButton optModificationDate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSQLError;
        private System.Windows.Forms.Button btnLocalError;
        private System.Windows.Forms.Button btnSQLHistory;
        private System.Windows.Forms.Button btnLocalHistory;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLastElimination;
    }
}

