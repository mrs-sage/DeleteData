namespace DeleteDataBases
{
    partial class FormDeleteSQLDataBases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeleteSQLDataBases));
            this.checkedListDataBases = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.optContendo = new System.Windows.Forms.RadioButton();
            this.optComeca = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLastElimination = new System.Windows.Forms.Label();
            this.picUnCheckAll = new System.Windows.Forms.PictureBox();
            this.picCheckAll = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnCheckAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckAll)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListDataBases
            // 
            this.checkedListDataBases.CheckOnClick = true;
            this.checkedListDataBases.FormattingEnabled = true;
            this.checkedListDataBases.Location = new System.Drawing.Point(12, 37);
            this.checkedListDataBases.Name = "checkedListDataBases";
            this.checkedListDataBases.Size = new System.Drawing.Size(181, 409);
            this.checkedListDataBases.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.optContendo);
            this.panel1.Controls.Add(this.optComeca);
            this.panel1.Location = new System.Drawing.Point(209, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 163);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filtro de Base Dados";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(117, 90);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(80, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtrar base de dados";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(9, 127);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Eliminar Base Dados selecionadas";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // optContendo
            // 
            this.optContendo.AutoSize = true;
            this.optContendo.Location = new System.Drawing.Point(9, 58);
            this.optContendo.Name = "optContendo";
            this.optContendo.Size = new System.Drawing.Size(129, 17);
            this.optContendo.TabIndex = 1;
            this.optContendo.Text = "Base dados contendo";
            this.optContendo.UseVisualStyleBackColor = true;
            // 
            // optComeca
            // 
            this.optComeca.AutoSize = true;
            this.optComeca.Checked = true;
            this.optComeca.Location = new System.Drawing.Point(9, 35);
            this.optComeca.Name = "optComeca";
            this.optComeca.Size = new System.Drawing.Size(140, 17);
            this.optComeca.TabIndex = 0;
            this.optComeca.TabStop = true;
            this.optComeca.Text = "Base dados começa por";
            this.optComeca.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Base de dados";
            // 
            // lblLastElimination
            // 
            this.lblLastElimination.AutoSize = true;
            this.lblLastElimination.Location = new System.Drawing.Point(215, 37);
            this.lblLastElimination.Name = "lblLastElimination";
            this.lblLastElimination.Size = new System.Drawing.Size(92, 13);
            this.lblLastElimination.TabIndex = 90;
            this.lblLastElimination.Text = "Última eliminação:";
            // 
            // picUnCheckAll
            // 
            this.picUnCheckAll.Image = global::DeleteDataBases.Properties.Resources._unchecked;
            this.picUnCheckAll.InitialImage = null;
            this.picUnCheckAll.Location = new System.Drawing.Point(171, 12);
            this.picUnCheckAll.Name = "picUnCheckAll";
            this.picUnCheckAll.Size = new System.Drawing.Size(22, 22);
            this.picUnCheckAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUnCheckAll.TabIndex = 89;
            this.picUnCheckAll.TabStop = false;
            this.picUnCheckAll.Click += new System.EventHandler(this.picUnCheckAll_Click);
            // 
            // picCheckAll
            // 
            this.picCheckAll.Image = global::DeleteDataBases.Properties.Resources._checked;
            this.picCheckAll.InitialImage = null;
            this.picCheckAll.Location = new System.Drawing.Point(148, 12);
            this.picCheckAll.Name = "picCheckAll";
            this.picCheckAll.Size = new System.Drawing.Size(22, 22);
            this.picCheckAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCheckAll.TabIndex = 88;
            this.picCheckAll.TabStop = false;
            this.picCheckAll.Click += new System.EventHandler(this.picCheckAll_Click);
            // 
            // FormDeleteSQLDataBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(441, 457);
            this.Controls.Add(this.lblLastElimination);
            this.Controls.Add(this.picUnCheckAll);
            this.Controls.Add(this.picCheckAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkedListDataBases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeleteSQLDataBases";
            this.Text = "Eliminar base de dados SQL";
            this.Load += new System.EventHandler(this.FormDeleteSQLDataBases_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnCheckAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListDataBases;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optContendo;
        private System.Windows.Forms.RadioButton optComeca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox picUnCheckAll;
        private System.Windows.Forms.PictureBox picCheckAll;
        private System.Windows.Forms.Label lblLastElimination;
    }
}