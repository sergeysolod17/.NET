using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using TMM_Analys;
using System.ComponentModel;

namespace TMM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //aditional_thread = new Thread(DrawingMechanism.Calculation);
            additional_thread = new BackgroundWorker();
            additional_thread.DoWork += new DoWorkEventHandler(DrawingMechanism.Calculation);
            additional_thread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DrawPlanePosition);
        }
        private void buttonMotion_Click(object sender, RoutedEventArgs e)
        {
            StartAnimation();
            buttonMotion.Content = "Стоп";

            /*DoWorkEventArgs e2 = new DoWorkEventArgs(null);
            DrawingMechanism.Calculation(null, e2);
            this.PathPlanePosition.Data = ((DrawingMechanism)e2.Result).ResultGeometry;*/
            
        }
        public void StartAnimation()
        {
            
            if (timer == null)
            {                
                InitialParametersMechanism(); 
                DrawingMechanism.CalculationPlanPosition(); 
            };
            if ((timer != null) && (timer.IsEnabled))
            { timer.Stop(); buttonMotion.Content = "Старт"; return; }
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += OnTimer;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            
            
            //DrawingMechanism.mechanism = plan_position[NumberPosition];
            //additional_thread.RunWorkerAsync();
        }
        private void OnTimer(object obj, EventArgs e)
        {
            //additional_thread.RunWorkerAsync();
            DoWorkEventArgs e2 = new DoWorkEventArgs(null);
            DrawingMechanism.Calculation(null, e2);
            this.PathPlanePosition.Data = ((DrawingMechanism)e2.Result).ResultGeometry;
            VisibleParameters();

            /*DrawingMechanism.mechanism = plan_position[NumberPosition];
            additional_thread.RunWorkerAsync();*/
        }
        public delegate EventHandler eventhandler1();
        public int NumberView;
        int X_center, Y_center;
        public int score;
        //public int NumberPosition;
        //public MechanismAnalys mechanism;
        public System.Windows.Threading.DispatcherTimer timer;
        
        
        //public Thread aditional_thread;
        public BackgroundWorker additional_thread;
        private void DrawPlanPosition()
        {
            /*this.A.Margin = new Thickness(X_center + MechanismAnalys.X_A * score-5, Y_center - MechanismAnalys.Y_A * score-5, 0, 0);
            this.B.Margin = new Thickness(X_center + mechanism.X_Bn * score-5, Y_center - mechanism.Y_Bn * score-5, 0, 0);
            this.S2.Margin = new Thickness(X_center + mechanism.X_S2n * score - 3, Y_center - mechanism.Y_S2n * score - 3, 0, 0);
            this.C.Margin = new Thickness(X_center + mechanism.X_Cn * score-5, Y_center - mechanism.Y_Cn * score-5, 0, 0);
            this.S3.Margin = new Thickness(X_center + mechanism.X_S3n * score - 3, Y_center - mechanism.Y_S3n * score - 3, 0, 0);
            this.D.Margin = new Thickness(X_center + MechanismAnalys.X_D * score-5, Y_center - MechanismAnalys.Y_D * score-5, 0, 0);
            this.S4.Margin = new Thickness(X_center + mechanism.X_S4n * score - 3, Y_center - mechanism.Y_S4n * score - 3, 0, 0);
            this.LineAB.X1 = X_center + MechanismAnalys.X_A * score;
            this.LineAB.Y1 = Y_center - MechanismAnalys.Y_A * score;
            this.LineAB.X2 = X_center + mechanism.X_Bn * score;
            this.LineAB.Y2 = Y_center - mechanism.Y_Bn * score;
            this.LineBC.X1 = X_center + mechanism.X_Bn * score;
            this.LineBC.Y1 = Y_center - mechanism.Y_Bn * score;
            this.LineBC.X2 = X_center + mechanism.X_Cn * score;
            this.LineBC.Y2 = Y_center - mechanism.Y_Cn * score;
            this.LineCD.X1 = X_center + mechanism.X_Cn * score;
            this.LineCD.Y1 = Y_center - mechanism.Y_Cn * score;
            this.LineCD.X2 = X_center + MechanismAnalys.X_D * score;
            this.LineCD.Y2 = Y_center - MechanismAnalys.Y_D * score;*/
            
            //this.PathMechanism.Data.
        }
        public void DrawPlanePosition(object obj, RunWorkerCompletedEventArgs e)
        {
            DrawingMechanism d = (DrawingMechanism)e.Result;
            this.PathPlanePosition.Data = d.ResultGeometry;
        }
        private void VisibleParameters()
        {
            /*this.LabelA.Content = "A(" + Convert.ToString(Math.Round(MechanismAnalys.X_A, 4)) + " ; " + Convert.ToString(Math.Round(MechanismAnalys.Y_A, 4)) + ")";
            this.LabelA.Margin = new Thickness(X_center + MechanismAnalys.X_A * score + 5, Y_center - MechanismAnalys.Y_A * score + 4, 0, 0);
            this.LabelB.Content = "B(" + Convert.ToString(Math.Round(mechanism.X_Bn, 4)) + " ; " + Convert.ToString(Math.Round(mechanism.Y_Bn, 4)) + ")";
            this.LabelB.Margin = new Thickness(X_center + mechanism.X_Bn * score + 5, Y_center - mechanism.Y_Bn * score + 4, 0, 0);
            this.LabelS2.Content = "S2(" + Convert.ToString(Math.Round(mechanism.X_S2n, 4)) + " ; " + Convert.ToString(Math.Round(mechanism.Y_S2n, 4)) + ")";
            this.LabelS2.Margin = new Thickness(X_center + mechanism.X_S2n * score + 5, Y_center - mechanism.Y_S2n * score + 4, 0, 0);
            this.LabelC.Content = "C(" + Convert.ToString(Math.Round(mechanism.X_S2n, 4)) + " ; " + Convert.ToString(Math.Round(mechanism.Y_Cn, 4)) + ")";
            this.LabelC.Margin = new Thickness(X_center + mechanism.X_Cn * score + 5, Y_center - mechanism.Y_Cn * score + 4, 0, 0);
            this.LabelS3.Content = "S3(" + Convert.ToString(Math.Round(mechanism.X_S3n, 4)) + " ; " + Convert.ToString(Math.Round(mechanism.Y_S3n, 4)) + ")";
            this.LabelS3.Margin = new Thickness(X_center + mechanism.X_S3n * score + 5, Y_center - mechanism.Y_S3n * score + 4, 0, 0);
            this.LabelD.Content = "D(" + Convert.ToString(Math.Round(MechanismAnalys.X_D, 4)) + " ; " + Convert.ToString(Math.Round(MechanismAnalys.Y_D, 4)) + ")";
            this.LabelD.Margin = new Thickness(X_center + MechanismAnalys.X_D * score + 5, Y_center - MechanismAnalys.Y_D * score + 4, 0, 0);
            this.LabelS4.Content = "S4(" + Convert.ToString(Math.Round(mechanism.X_S4n, 4)) + " ; " + Convert.ToString(Math.Round(mechanism.Y_S4n, 4)) + ")";
            this.LabelS4.Margin = new Thickness(X_center + mechanism.X_S4n * score + 5, Y_center - mechanism.Y_S4n * score + 4, 0, 0);*/
            this.LabelNumberPosition.Content = "Положення " + Convert.ToString(DrawingMechanism.NumberPosition);
            this.LabelOmega.Content = "Кутова швидкість  " + Convert.ToString(MechanismAnalys.Omega * MechanismAnalys.OmegaDirection)+ " рад/с";
            this.LabelV_B.Content = "Швидкість точки В: " + Convert.ToString(Math.Round(MechanismAnalys.v_B,4)) + " м/с";
            this.LabelV_C.Content = "Швидкість точки C: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_Cn, 4))+ " м/с";
            this.LabelV_S2.Content = "Швидкість точки S2: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S2n, 4))+ " м/с";
            this.LabelV_S3.Content = "Швидкість точки S3: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S3n, 4))+ " м/с";
            this.LabelV_S4.Content = "Швидкість точки S4: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S4n, 4))+ " м/с";
        }
        private void InitialParametersMechanism()
        { 
            DrawingMechanism.mechanism = new MechanismAnalys();
            /*MechanismAnalys.X_A = 0;
            MechanismAnalys.Y_A = 0;
            MechanismAnalys.X_D = 0.4;
            MechanismAnalys.Y_D = 0;
            MechanismAnalys.l2 = 0.14;
            //MechanismAnalys.l2 = Convert.ToDouble(textBoxL_AB.Text);
            MechanismAnalys.l3 = 0.4;//Convert.ToDouble(textBoxL_BC.Text);
            MechanismAnalys.l4 = 0.32;//Convert.ToDouble(textBoxL_CD.Text);
            MechanismAnalys.l_AD = 0.4;//Convert.ToDouble(textBoxL_AD.Text);
            MechanismAnalys.l_AS_2 = 0.07;//Convert.ToDouble(textBoxAS_2.Text);
            MechanismAnalys.l_BS_3 = 0.16;//Convert.ToDouble(textBoxBS_3.Text);
            MechanismAnalys.l_DS_4 = 0.16;//Convert.ToDouble(textBoxCS_4.Text);
            MechanismAnalys.Omega = 41;//Convert.ToDouble(textBoxOmega.Text);
            MechanismAnalys.Epsilon = 0;//Convert.ToDouble(textBoxEpsilon.Text);*/
            //if (checkBoxOmegaDirect.Checked) { MechanismAnalys.OmegaDirect = -1; } else MechanismAnalys.OmegaDirect = 1;
            //if (checkBoxEpsilonDirect.Checked) { MechanismAnalys.EpsilonDirect = -1; } else MechanismAnalys.EpsilonDirect = 1;
            //MechanismAnalys.InitParameter(Convert.ToInt32(textBoxQuantIteration.Text));
           // Program.ArrayKinematicAnalys = new KinematikAnalys[KinematikAnalys.QuantIteration];
            //QuantPosition = 100;
            //
            DrawingMechanism.plan_position = new MechanismAnalys[DrawingMechanism.QuantPosition];
            DrawingMechanism.CalculationPlanPosition();
            //MechanismAnalys.CalculationPlanPosition(ref mechanism, 8);
            InitialViewParameters();
        }
        private void InitialViewParameters()
        {
            DrawingMechanism.Score = Convert.ToInt32(140 / MechanismAnalys.l2);
            DrawingMechanism.X_center = Convert.ToInt32(MechanismAnalys.l2 * DrawingMechanism.Score + 50);
            DrawingMechanism.Y_center = Convert.ToInt32(Math.Floor(canvas.Height * 0.68));
            DrawingMechanism.IsCyclingMotion = true;
        }
        

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Splot splot = new Splot();
            splot.Show();
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            DoWorkEventArgs e2 = new DoWorkEventArgs(null);
            DrawingMechanism.Calculation(null, e2);
            this.PathPlanePosition.Data = ((DrawingMechanism)e2.Result).ResultGeometry;
            VisibleParameters();
        }

        private void checkBoxIsVisibleVectorVelocity_Checked(object sender, RoutedEventArgs e)
        {
            DrawingMechanism.IsVisibleVectorVelocity = checkBoxIsVisibleVectorVelocity.IsChecked.Value;
        }
    }

    class DrawingMechanism
    {
        public LineGeometry lineAB, lineBC, lineCD;
        public EllipseGeometry ellipseA, ellipseB, ellipseC, ellipseD, ellipseS2, ellipseS3, ellipseS4;
        public LineGeometry alpha_4n, alpha_2n;
        public GeometryGroup ResultGeometry;
        public static int X_center, Y_center;
        public static Point A, B, C, D;
        private static Point alpha_2n_end, alpha_3n_end, alpha_4n_end;
        public static MechanismAnalys mechanism;
        public static double Score;
        public static MechanismAnalys[] array_mechanism;
        public static int NumberPosition;
        public static int QuantPosition { get { return MechanismAnalys.QuantIteration; } set { MechanismAnalys.QuantIteration = value; } }
        public static bool IsCyclingMotion;
        public static bool IsVisibleVectorVelocity;
        public static int LengthVectorVelocity;

        public static void Calculation(object obj, DoWorkEventArgs e)
        {
            if ((NumberPosition >= QuantPosition)&&IsCyclingMotion)
            { NumberPosition = 0; }
            else if (NumberPosition >= QuantPosition) { NumberPosition = QuantPosition-1; };

            DrawingMechanism res = new DrawingMechanism();
            res.ResultGeometry = new GeometryGroup();
            res.ResultGeometry.FillRule = FillRule.Nonzero;

            MechanismAnalys.PlanPositionParameters mechanism = new MechanismAnalys.PlanPositionParameters;
            

            DrawingMechanism.mechanism = plan_position[NumberPosition];
            A = new Point(X_center + MechanismAnalys.X_A * Score, Y_center - MechanismAnalys.Y_A * Score);
            B = new Point(X_center + mechanism.X_Bn * Score, Y_center - mechanism.Y_Bn * Score);
            C = new Point(X_center + mechanism.X_Cn * Score, Y_center - mechanism.Y_Cn * Score);
            D = new Point(X_center + MechanismAnalys.X_D * Score, Y_center - MechanismAnalys.Y_D * Score);
            res.lineAB = new LineGeometry( A,B);
            res.lineBC = new LineGeometry(B,C);
            res.lineCD = new LineGeometry(C, D);
            res.ellipseA = new EllipseGeometry(A, 3, 3);
            res.ellipseB = new EllipseGeometry(B, 3, 3);
            res.ellipseC = new EllipseGeometry(C, 3, 3);
            res.ellipseD = new EllipseGeometry(D, 3, 3);
            res.ellipseA = new EllipseGeometry(A, 3, 3);
            res.ellipseA = new EllipseGeometry(A, 3, 3);
            double endX = 0;
            double endY = 0;
            
            
            res.ResultGeometry.Children.Add(res.lineAB);
            res.ResultGeometry.Children.Add(res.lineBC);
            res.ResultGeometry.Children.Add(res.lineCD);
            res.ResultGeometry.Children.Add(res.ellipseA);
            res.ResultGeometry.Children.Add(res.ellipseB);
            res.ResultGeometry.Children.Add(res.ellipseC);
            res.ResultGeometry.Children.Add(res.ellipseD);
            if (IsVisibleVectorVelocity)
            {
                OperatorFunction.F2(B.X, B.Y, LengthVectorVelocity, mechanism.alpha_2n, ref endX, ref endY);
                res.alpha_2n = new LineGeometry(B, new Point(endX, endY));
                OperatorFunction.F2(C.X, C.Y, LengthVectorVelocity, mechanism.alpha_3n, ref endX, ref endY);
                res.alpha_4n = new LineGeometry(B, new Point(endX, endY));
                res.ResultGeometry.Children.Add(res.alpha_2n);
                res.ResultGeometry.Children.Add(res.alpha_4n);
            }
            e.Result = res;
            NumberPosition++;
        }
        public static void CalculationPlanPosition()
        {
            for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
            {
                plan_position[n] = new MechanismAnalys();
                MechanismAnalys.CalculationPlanPosition(ref plan_position[n], n);
                MechanismAnalys.CalculationPlanVelocity(ref plan_position[n]);
            };
        }
    }
}
