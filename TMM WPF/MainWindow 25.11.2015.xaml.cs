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
using TMM_WPF;
using WPF_TableForm;

namespace TMM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
            
        }
        private void buttonMotion_Click(object sender, RoutedEventArgs e)
        {
            if ((timer != null) && (timer.IsEnabled))
            { timer.Stop(); buttonMotion.Content = "Старт"; return; }
            StartAnimation();     
        }
        public void StartAnimation()
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += OnTimer;
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();
            InitialMechanismRendering();
        }

        private void InitialMechanismRendering()
        {
            /*double p = (MechanismAnalys.L_AB+MechanismAnalys.L_AD+MechanismAnalys.L_BC+MechanismAnalys.L_CD+((MechanismAnalys.L_BE != null)?MechanismAnalys.L_BE:0))/2;
            double s_aed = Math.Sqrt(p*(p-MechanismAnalys.L_AD)*(p-MechanismAnalys.L_AB-(((MechanismAnalys.L_BE != null)&&(MechanismAnalys.PointBeginBE==MechanismAnalys.NumberPoints.C))?MechanismAnalys.L_BE:0))*(p-MechanismAnalys.L_CD));
            double max_y = 2*s_aed/MechanismAnalys.L_AD;*/
            double max_x = MechanismAnalys.L_AB + MechanismAnalys.L_AD + MechanismAnalys.L_AD;
            

            double x_score = (canvas.Width - 20) / max_x; 
            double max_y_ = 2 * ((MechanismAnalys.L_AB > MechanismAnalys.L_CD) ? MechanismAnalys.L_AB : MechanismAnalys.L_CD);
            double y_score = (canvas.Height - 20) / max_y_;
            Score = (y_score > x_score)?y_score:x_score;
        }
        private void OnTimer(object obj, EventArgs e)
        {
            //MechanismAnalys m = App.MechanismResult[n];
            h:
            if (n < MechanismAnalys.QuantIteration)
            {
                GeometryGroup g = new GeometryGroup();
                Render(ref App.MechanismResult[n], n);
                this.PathPlanePosition.Data = g;
                n++;
            }
            else
            {
                n = 0;
                goto h;
            };
           
        }
        
        public int n;
        //int X_center, Y_center;
        public int score;
        public System.Windows.Threading.DispatcherTimer timer;
        
       
        /*
        
        private void VisibleParameters()
        {
           
            this.LabelNumberPosition.Content = "Положення " + Convert.ToString(DrawingMechanism.NumberPosition);
            this.LabelOmega.Content = "Кутова швидкість  " + Convert.ToString(MechanismAnalys.Omega * MechanismAnalys.OmegaDirection)+ " рад/с";
            this.LabelV_B.Content = "Швидкість точки В: " + Convert.ToString(Math.Round(MechanismAnalys.v_B,4)) + " м/с";
            this.LabelV_C.Content = "Швидкість точки C: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_Cn, 4))+ " м/с";
            this.LabelV_S2.Content = "Швидкість точки S2: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S2n, 4))+ " м/с";
            this.LabelV_S3.Content = "Швидкість точки S3: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S3n, 4))+ " м/с";
            this.LabelV_S4.Content = "Швидкість точки S4: " + Convert.ToString(Math.Round(DrawingMechanism.mechanism.v_S4n, 4))+ " м/с";
        }
        */
        
        

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Splot splot = new Splot();
            splot.Show();
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            n++;
            GeometryGroup g = new GeometryGroup();
            Render(ref App.MechanismResult[n], n);
            this.PathPlanePosition.Data = g;
        }

        private void checkBoxIsVisibleVectorVelocity_Checked(object sender, RoutedEventArgs e)
        {
            //DrawingMechanism.IsVisibleVectorVelocity = checkBoxIsVisibleVectorVelocity.IsChecked.Value;
        }

        public void Render(ref MechanismAnalys mechanism, int n)
        {
            MechanismAnalys.PlanPositionParameters plan = new MechanismAnalys.PlanPositionParameters();
            mechanism.CalculationPlanPosition(ref plan, n);
            GeometryGroup res = new GeometryGroup();
            Point start = new Point(Xcenter, Ycenter);
            Point end = new Point(plan.X_Bn * Score + Xcenter, Ycenter - plan.Y_Bn * Score);
            //res.Children.Add(new LineGeometry(new Point(Xcenter, Ycenter), new Point(plan.X_Bn * Score + Xcenter, Ycenter - plan.Y_Bn * Score)));
            res.Children.Add(new LineGeometry(start,end));

            this.PathPlanePosition.Data = res;
        }
        public static double Score;
        public static int Xcenter, Ycenter;
    }

 

    class MechanismRender
    {
        public static void Render(ref MechanismAnalys mechanism, int n, ref GeometryGroup res)
        {
            MechanismAnalys.PlanPositionParameters plan = new MechanismAnalys.PlanPositionParameters();
            mechanism.CalculationPlanPosition(ref plan, n);            
            res.Children.Add(new LineGeometry(new Point(Xcenter,Ycenter), new Point(plan.X_Bn*Score+Xcenter,Ycenter - plan.Y_Bn*Score)));


            
        }
        public static double Score;
        public static int Xcenter, Ycenter;
    
    }
}

/*   class DrawingMechanism
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
        public static int QuantPosition { get { return MechanismAnalys.QuantIteration; } set { MechanismAnalys.InitParameter(value); } }
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

        
    }*/