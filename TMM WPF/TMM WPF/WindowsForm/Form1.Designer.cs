namespace TMM_MetodCoorditatesPlaniv
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxL_AB = new System.Windows.Forms.TextBox();
            this.textBoxL_BC = new System.Windows.Forms.TextBox();
            this.textBoxL_CD = new System.Windows.Forms.TextBox();
            this.textBoxL_AD = new System.Windows.Forms.TextBox();
            this.textBoxOmega = new System.Windows.Forms.TextBox();
            this.textBoxCS_4 = new System.Windows.Forms.TextBox();
            this.textBoxBS_3 = new System.Windows.Forms.TextBox();
            this.textBoxAS_2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEpsilon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxQuantIteration = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBoxPlan = new System.Windows.Forms.PictureBox();
            this.checkBoxOmegaDirect = new System.Windows.Forms.CheckBox();
            this.checkBoxEpsilonDirect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Розрахунок ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Довжина ланки  АВ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Довжина ланки  ВС:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Довжина ланки  CD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Відстань AD: ";
            // 
            // textBoxL_AB
            // 
            this.textBoxL_AB.Location = new System.Drawing.Point(130, 13);
            this.textBoxL_AB.Name = "textBoxL_AB";
            this.textBoxL_AB.Size = new System.Drawing.Size(100, 20);
            this.textBoxL_AB.TabIndex = 5;
            this.textBoxL_AB.Text = "0,14";
            // 
            // textBoxL_BC
            // 
            this.textBoxL_BC.Location = new System.Drawing.Point(130, 37);
            this.textBoxL_BC.Name = "textBoxL_BC";
            this.textBoxL_BC.Size = new System.Drawing.Size(100, 20);
            this.textBoxL_BC.TabIndex = 6;
            this.textBoxL_BC.Text = "0,4";
            // 
            // textBoxL_CD
            // 
            this.textBoxL_CD.Location = new System.Drawing.Point(130, 63);
            this.textBoxL_CD.Name = "textBoxL_CD";
            this.textBoxL_CD.Size = new System.Drawing.Size(100, 20);
            this.textBoxL_CD.TabIndex = 7;
            this.textBoxL_CD.Text = "0,32";
            // 
            // textBoxL_AD
            // 
            this.textBoxL_AD.Location = new System.Drawing.Point(130, 87);
            this.textBoxL_AD.Name = "textBoxL_AD";
            this.textBoxL_AD.Size = new System.Drawing.Size(100, 20);
            this.textBoxL_AD.TabIndex = 8;
            this.textBoxL_AD.Text = "0,4";
            // 
            // textBoxOmega
            // 
            this.textBoxOmega.Location = new System.Drawing.Point(186, 139);
            this.textBoxOmega.Name = "textBoxOmega";
            this.textBoxOmega.Size = new System.Drawing.Size(100, 20);
            this.textBoxOmega.TabIndex = 16;
            this.textBoxOmega.Text = "41";
            // 
            // textBoxCS_4
            // 
            this.textBoxCS_4.Location = new System.Drawing.Point(368, 63);
            this.textBoxCS_4.Name = "textBoxCS_4";
            this.textBoxCS_4.Size = new System.Drawing.Size(100, 20);
            this.textBoxCS_4.TabIndex = 15;
            this.textBoxCS_4.Text = "0,16";
            // 
            // textBoxBS_3
            // 
            this.textBoxBS_3.Location = new System.Drawing.Point(368, 37);
            this.textBoxBS_3.Name = "textBoxBS_3";
            this.textBoxBS_3.Size = new System.Drawing.Size(100, 20);
            this.textBoxBS_3.TabIndex = 14;
            this.textBoxBS_3.Text = "0,16";
            // 
            // textBoxAS_2
            // 
            this.textBoxAS_2.Location = new System.Drawing.Point(368, 13);
            this.textBoxAS_2.Name = "textBoxAS_2";
            this.textBoxAS_2.Size = new System.Drawing.Size(100, 20);
            this.textBoxAS_2.TabIndex = 13;
            this.textBoxAS_2.Text = "0,07";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Кутова швидкість ланки AВ: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Відстань СS_4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Відстань ВS_3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Відстань АS_2:";
            // 
            // textBoxEpsilon
            // 
            this.textBoxEpsilon.Location = new System.Drawing.Point(186, 174);
            this.textBoxEpsilon.Name = "textBoxEpsilon";
            this.textBoxEpsilon.Size = new System.Drawing.Size(100, 20);
            this.textBoxEpsilon.TabIndex = 18;
            this.textBoxEpsilon.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Кутова прискорення ланки AВ: ";
            // 
            // textBoxQuantIteration
            // 
            this.textBoxQuantIteration.Location = new System.Drawing.Point(186, 234);
            this.textBoxQuantIteration.Name = "textBoxQuantIteration";
            this.textBoxQuantIteration.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantIteration.TabIndex = 20;
            this.textBoxQuantIteration.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Кількість положень механізму: ";
            // 
            // pictureBoxPlan
            // 
            this.pictureBoxPlan.Location = new System.Drawing.Point(489, 13);
            this.pictureBoxPlan.Name = "pictureBoxPlan";
            this.pictureBoxPlan.Size = new System.Drawing.Size(373, 358);
            this.pictureBoxPlan.TabIndex = 21;
            this.pictureBoxPlan.TabStop = false;
            this.pictureBoxPlan.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPlan_Paint);
            // 
            // checkBoxOmegaDirect
            // 
            this.checkBoxOmegaDirect.AutoSize = true;
            this.checkBoxOmegaDirect.Location = new System.Drawing.Point(303, 141);
            this.checkBoxOmegaDirect.Name = "checkBoxOmegaDirect";
            this.checkBoxOmegaDirect.Size = new System.Drawing.Size(132, 17);
            this.checkBoxOmegaDirect.TabIndex = 22;
            this.checkBoxOmegaDirect.Text = "Проти годин. стрілки";
            this.checkBoxOmegaDirect.UseVisualStyleBackColor = true;
            // 
            // checkBoxEpsilonDirect
            // 
            this.checkBoxEpsilonDirect.AutoSize = true;
            this.checkBoxEpsilonDirect.Location = new System.Drawing.Point(303, 176);
            this.checkBoxEpsilonDirect.Name = "checkBoxEpsilonDirect";
            this.checkBoxEpsilonDirect.Size = new System.Drawing.Size(132, 17);
            this.checkBoxEpsilonDirect.TabIndex = 23;
            this.checkBoxEpsilonDirect.Text = "Проти годин. стрілки";
            this.checkBoxEpsilonDirect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 418);
            this.Controls.Add(this.checkBoxEpsilonDirect);
            this.Controls.Add(this.checkBoxOmegaDirect);
            this.Controls.Add(this.pictureBoxPlan);
            this.Controls.Add(this.textBoxQuantIteration);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxEpsilon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxOmega);
            this.Controls.Add(this.textBoxCS_4);
            this.Controls.Add(this.textBoxBS_3);
            this.Controls.Add(this.textBoxAS_2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxL_AD);
            this.Controls.Add(this.textBoxL_CD);
            this.Controls.Add(this.textBoxL_BC);
            this.Controls.Add(this.textBoxL_AB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxL_AB;
        private System.Windows.Forms.TextBox textBoxL_BC;
        private System.Windows.Forms.TextBox textBoxL_CD;
        private System.Windows.Forms.TextBox textBoxL_AD;
        private System.Windows.Forms.TextBox textBoxOmega;
        private System.Windows.Forms.TextBox textBoxCS_4;
        private System.Windows.Forms.TextBox textBoxBS_3;
        private System.Windows.Forms.TextBox textBoxAS_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEpsilon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxQuantIteration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBoxPlan;
        private System.Windows.Forms.CheckBox checkBoxOmegaDirect;
        private System.Windows.Forms.CheckBox checkBoxEpsilonDirect;
    }
}

