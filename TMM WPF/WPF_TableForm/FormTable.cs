using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMM_WPF;
using TMM_Analys;

namespace WPF_TableForm
{
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TMM_WPF.Splot splot = new Splot();
            splot.Show();
            
        }
        public void OutPutRezultPlanPosition()
        {
            //textBox1.Lines = new string[(QuantIteration+1)];
            //textBox1.Lines[0] = "\tКут повороту 
            for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
            {
                dataGridView1.Rows.Add(n, Math.Round(App.MechanismResult[n].fi_2n, 6), Math.Round(MechanismAnalys.V_B, 6), Math.Round(App.MechanismResult[n].v_Cn, 6), Math.Round(App.MechanismResult[n].v_En, 6), Math.Round(MechanismAnalys.Omega, 6), Math.Round(App.MechanismResult[n].omega_3n, 6), Math.Round(App.MechanismResult[n].omega_4n, 6), Math.Round(App.MechanismResult[n].v_S2n, 6), Math.Round(App.MechanismResult[n].v_S3n, 6), Math.Round(App.MechanismResult[n].v_S4n, 6), Math.Round(App.MechanismResult[n].MomentInertia, 6), Math.Round(App.MechanismResult[n].Moment, 6));
                if (!MechanismAnalys.IsAdditionalPoint)
                    { dataGridView1.Columns[4].Visible = false; }
                //this.dataGridView1.Rows.Add(a[n, 0], "( " + a[n, 1] + " ; " + a[n, 2] + ")", a[n, 3], "( " + a[n, 4] + " ; " + a[n, 5] + ")", a[n, 7], "( " + a[n, 8] + " ; " + a[n, 9] + ")", "( " + a[n, 10] + " ; " + a[n, 11] + ")", "( " + a[n, 12] + " ; " + a[n, 13] + ")");
            }
        }
    }
}
