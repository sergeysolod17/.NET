namespace WPF_TableForm
{
    partial class FormTable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSplot = new System.Windows.Forms.Button();
            this.ColumnNumberPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAngleLink2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOmega2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOmega3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOmega4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityS2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityS3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVelocityS4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMomentInertia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumberPosition,
            this.ColumnAngleLink2,
            this.ColumnVelocityB,
            this.ColumnVelocityC,
            this.ColumnVelocityE,
            this.ColumnOmega2,
            this.ColumnOmega3,
            this.ColumnOmega4,
            this.ColumnVelocityS2,
            this.ColumnVelocityS3,
            this.ColumnVelocityS4,
            this.ColumnMomentInertia,
            this.ColumnMoment});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(994, 473);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonSplot
            // 
            this.buttonSplot.Location = new System.Drawing.Point(931, 491);
            this.buttonSplot.Name = "buttonSplot";
            this.buttonSplot.Size = new System.Drawing.Size(75, 23);
            this.buttonSplot.TabIndex = 1;
            this.buttonSplot.Text = "Графік";
            this.buttonSplot.UseVisualStyleBackColor = true;
            this.buttonSplot.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColumnNumberPosition
            // 
            this.ColumnNumberPosition.HeaderText = "Номер положення";
            this.ColumnNumberPosition.Name = "ColumnNumberPosition";
            this.ColumnNumberPosition.ReadOnly = true;
            this.ColumnNumberPosition.Width = 50;
            // 
            // ColumnAngleLink2
            // 
            this.ColumnAngleLink2.HeaderText = "Кут повороту кривошипа";
            this.ColumnAngleLink2.Name = "ColumnAngleLink2";
            this.ColumnAngleLink2.ReadOnly = true;
            this.ColumnAngleLink2.Width = 70;
            // 
            // ColumnVelocityB
            // 
            this.ColumnVelocityB.HeaderText = "Швидкість точки В";
            this.ColumnVelocityB.Name = "ColumnVelocityB";
            this.ColumnVelocityB.ReadOnly = true;
            this.ColumnVelocityB.Width = 65;
            // 
            // ColumnVelocityC
            // 
            this.ColumnVelocityC.HeaderText = "Швидкість точки С";
            this.ColumnVelocityC.Name = "ColumnVelocityC";
            this.ColumnVelocityC.ReadOnly = true;
            // 
            // ColumnVelocityE
            // 
            this.ColumnVelocityE.HeaderText = "Швидкість точки Е";
            this.ColumnVelocityE.Name = "ColumnVelocityE";
            this.ColumnVelocityE.ReadOnly = true;
            // 
            // ColumnOmega2
            // 
            this.ColumnOmega2.HeaderText = "Кутова швидкість ланки 2";
            this.ColumnOmega2.Name = "ColumnOmega2";
            this.ColumnOmega2.ReadOnly = true;
            // 
            // ColumnOmega3
            // 
            this.ColumnOmega3.HeaderText = "Кутова швидкість ланки 3";
            this.ColumnOmega3.Name = "ColumnOmega3";
            this.ColumnOmega3.ReadOnly = true;
            // 
            // ColumnOmega4
            // 
            this.ColumnOmega4.HeaderText = "Кутова швидкість ланки 4";
            this.ColumnOmega4.Name = "ColumnOmega4";
            this.ColumnOmega4.ReadOnly = true;
            // 
            // ColumnVelocityS2
            // 
            this.ColumnVelocityS2.HeaderText = "Швидкість центра мас ланки 2";
            this.ColumnVelocityS2.Name = "ColumnVelocityS2";
            this.ColumnVelocityS2.ReadOnly = true;
            // 
            // ColumnVelocityS3
            // 
            this.ColumnVelocityS3.HeaderText = "Швидкість центра мас ланки 3";
            this.ColumnVelocityS3.Name = "ColumnVelocityS3";
            this.ColumnVelocityS3.ReadOnly = true;
            // 
            // ColumnVelocityS4
            // 
            this.ColumnVelocityS4.HeaderText = "Швидкість центра мас ланки 4";
            this.ColumnVelocityS4.Name = "ColumnVelocityS4";
            this.ColumnVelocityS4.ReadOnly = true;
            // 
            // ColumnMomentInertia
            // 
            this.ColumnMomentInertia.HeaderText = "Зведений момент інерції";
            this.ColumnMomentInertia.Name = "ColumnMomentInertia";
            // 
            // ColumnMoment
            // 
            this.ColumnMoment.HeaderText = "Зведений момент";
            this.ColumnMoment.Name = "ColumnMoment";
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 526);
            this.Controls.Add(this.buttonSplot);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormTable";
            this.Text = "Результати розрахунків - ТММ Аналіз";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSplot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAngleLink2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOmega2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOmega3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOmega4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityS2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityS3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVelocityS4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMomentInertia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoment;
    }
}