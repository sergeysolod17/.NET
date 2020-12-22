using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ForceAnalys;

namespace TMM_MetodCoorditatesPlaniv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //NumberPositionVisible = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Program.kinematik_analys = new KinematikAnalys();
            this.InitParameters();

            int nt = new int(); nt = 5;
            Program.ArrayKinematicAnalys[nt] = new KinematikAnalys();
            //Program.ArrayKinematicAnalys[nt].fi_2n = 1.8240645452102977727978723064367;
            KinematikAnalys.CalculationPlanPosition(ref Program.ArrayKinematicAnalys[nt], nt);
            KinematikAnalys.CalculationPlanVelocity(ref Program.ArrayKinematicAnalys[nt]); 

            for (int n = 0; n < KinematikAnalys.QuantIteration; n++)
            {
                Program.ArrayKinematicAnalys[n] = new KinematikAnalys();
                KinematikAnalys.CalculationPlanPosition(ref Program.ArrayKinematicAnalys[n],n);
                KinematikAnalys.CalculationPlanVelocity(ref Program.ArrayKinematicAnalys[n]); 
            };
            
            //FormTable FormTableResult = new FormTable(ref KinematikAnalys.PlanPosition, KinematikAnalys.QuantIteration);
            //NumberPositionVisible = 2;

            //ForceAnalys.ForceAnalys f = new ForceAnalys.ForceAnalys();
            //f.Test();
            //this.pictureBoxPlan_Paint(
            //FormTableResult.Show();         
        }
        
        
        /*private void CalculationPlanVelosity()
        {
            double v_B = Omega*l1;
            double alpha_2n = new double();
            double x_BVn = new double();
            double y_BVn =  new double();
            double x_CVn  = new double();
            double y_CVn  = new double();
            double v_Cn  = new double();
            double v_CBn  = new double();
            double alpha_3n  = new double();
            double alpha_4n  = new double();
            double omega_3n  = new double();
            double omega_4n  = new double();
            double x_S2Vn  = new double();
            double y_S2Vn  = new double();
            double x_S3Vn  = new double();
            double y_S3Vn  = new double();
            double x_S4Vn  = new double();
            double y_S4Vn  = new double();
            double v_S2n  = new double();
            double v_S3n  = new double();
            double v_S4n  = new double();
            double alpha_S2n  = new double();
            double alpha_S3n  = new double();
            double alpha_S4n  = new double();
            
            for (int n = 0; n < QuantIteration; n++)
            {
                alpha_2n = Fi_1n + OmegaDirect * Math.PI / 2;
                OperatorFunction.F2(X_P, Y_P, v_B, alpha_2n, ref x_BVn, ref y_BVn);
                OperatorFunction.F1(x_BVn, y_BVn, Fi_2n + Math.PI / 2, X_P, Y_P, Fi_3n + Math.PI / 2, ref x_CVn, ref y_CVn);
                OperatorFunction.F4(X_P, Y_P, x_CVn, y_CVn, ref v_Cn);
                OperatorFunction.F4(x_BVn, y_BVn, x_CVn, y_CVn, ref v_CBn);


            }
        }*/
        public void DrawPlanPosition(int number_position, ref Graphics g)
        {
            //Point center = new Point(pictureBoxPlan.Width / 2, pictureBoxPlan.Height / 2);
            //pictureBoxPlan.
        }     
        
        private void pictureBoxPlan_Paint(object sender, PaintEventArgs e)
        {
            /*if(NumberPositionVisible != -1)
            {
                Pen pen = new Pen(Color.Black,3);
            Point center = new Point(pictureBoxPlan.Width / 2, pictureBoxPlan.Height / 2);
            e.Graphics.DrawLine(pen, new Point((int)X_A, (int)Y_A), new Point((int)PlanPosition[NumberPositionVisible, 1], (int)PlanPosition[NumberPositionVisible, 2]));
            }*/
        }
        private void InitParameters()
        {
            KinematikAnalys.l2 = Convert.ToDouble(textBoxL_AB.Text);
            KinematikAnalys.l3 = Convert.ToDouble(textBoxL_BC.Text);
            KinematikAnalys.l4 = Convert.ToDouble(textBoxL_CD.Text);
            KinematikAnalys.l_AD = Convert.ToDouble(textBoxL_AD.Text);
            KinematikAnalys.l_AS_2 = Convert.ToDouble(textBoxAS_2.Text);
            KinematikAnalys.l_BS_3 = Convert.ToDouble(textBoxBS_3.Text);
            KinematikAnalys.l_DS_4 = Convert.ToDouble(textBoxCS_4.Text);
            KinematikAnalys.Omega = Convert.ToDouble(textBoxOmega.Text);
            KinematikAnalys.Epsilon = Convert.ToDouble(textBoxEpsilon.Text);
            if (checkBoxOmegaDirect.Checked) { KinematikAnalys.OmegaDirect = -1; } else KinematikAnalys.OmegaDirect = 1;
            if (checkBoxEpsilonDirect.Checked) { KinematikAnalys.EpsilonDirect = -1; } else KinematikAnalys.EpsilonDirect = 1;
            KinematikAnalys.InitParameter(Convert.ToInt32(textBoxQuantIteration.Text));
            Program.ArrayKinematicAnalys = new KinematikAnalys[KinematikAnalys.QuantIteration];
        }
    }
}
