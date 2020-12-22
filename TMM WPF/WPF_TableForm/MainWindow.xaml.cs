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
    /// 
    public class ExceptionStopCalculation : Exception
    {};
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
            coef_omega = 10;
            labelCoefTime.Content = "Масштабний коефіцієнт часу: " + coef_omega.ToString();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += OnTimer;
            timer.Interval = TimeSpan.FromSeconds(MechanismAnalys.Omega/(coef_omega*MechanismAnalys.QuantIteration));
            timer.Start();
            InitialMechanismRendering();
            MechanismAnalys.PlanPositionParameters[] l = new MechanismAnalys.PlanPositionParameters[MechanismAnalys.QuantIteration];
            for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
            {
                App.MechanismResult[n].CalculationPlanPosition(ref l[n], n);
            }
            GeometryGroup g =new GeometryGroup();
            DrawTraectory(ref l, ref g, MechanismAnalys.NumberPoints.B);
            PathPlanePosition.Data = g;
            DrawTraectory(ref l, ref g, MechanismAnalys.NumberPoints.C);
            PathPlanePosition.Data = g;
            DrawTraectory(ref l, ref g, MechanismAnalys.NumberPoints.E);
            PathPlanePosition.Data = g;
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
            score = (y_score > x_score)?x_score:y_score;
            double [] y_c_values = new double[MechanismAnalys.QuantIteration];
            
            X_center = (int)((MechanismAnalys.L_AB+MechanismAnalys.L_BE) * score) + 20;//(int)Math.Round((canvas.Width - 20) / 2);
            Y_center = (int)((MechanismAnalys.DirectionLink4 == MechanismAnalys.DirectionRotation.AgainClockWise) ? (canvas.Height - MechanismAnalys.L_CD * score-20)  : (MechanismAnalys.L_CD+MechanismAnalys.L_BE*((MechanismAnalys.DirectionLink4 == MechanismAnalys.DirectionRotation.OnClockWise)?-1:1)) * score + (canvas.Height - (MechanismAnalys.L_CD+MechanismAnalys.L_BE) * score) / 2);//(int)Math.Round((canvas.Height - 20) / 2);


        }
        private void OnTimer(object obj, EventArgs e)
        {
            //MechanismAnalys m = App.MechanismResult[n];
            h:
            if (n < MechanismAnalys.QuantIteration)
            {
                MechanismAnalys.PlanPositionParameters l = new MechanismAnalys.PlanPositionParameters();
                App.MechanismResult[n].CalculationPlanPosition(ref l, n);
                DrawPlanPosition(ref l);
                
                
                
                VisibleParameters(ref App.MechanismResult[n],ref l);
                n++;
            }
            else
            {
                n = 0;
                goto h;
            };
           
        }
        
        public int n;
        int X_center, Y_center;
        public double score;
        public System.Windows.Threading.DispatcherTimer timer;
        private int coef_omega;



        private void VisibleParameters(ref MechanismAnalys mechanism, ref MechanismAnalys.PlanPositionParameters plan)
        {
           
            this.LabelNumberPosition.Content = "Положення " + Convert.ToString(n);
            this.LabelOmega.Content = "Кутова швидкість  " + Convert.ToString(MechanismAnalys.Omega * MechanismAnalys.OmegaDirection)+ " рад/с";
            this.LabelV_B.Content = "Швидкість точки В: " + Convert.ToString(Math.Round(mechanism.v_Bn,4)) + " м/с";
            this.LabelV_C.Content = "Швидкість точки C: " + Convert.ToString(Math.Round(mechanism.v_Cn, 4))+ " м/с";
            this.LabelV_S2.Content = "Швидкість точки S2: " + Convert.ToString(Math.Round(mechanism.v_S2n, 4))+ " м/с";
            this.LabelV_S3.Content = "Швидкість точки S3: " + Convert.ToString(Math.Round(mechanism.v_S3n, 4))+ " м/с";
            this.LabelV_S4.Content = "Швидкість точки S4: " + Convert.ToString(Math.Round(mechanism.v_S4n, 4))+ " м/с";
            this.labelFi2n.Content = "Кут ланки 2: " + Convert.ToString(Math.Round(mechanism.fi_2n, 4)) + " рад";
            this.labelFi3n.Content = "Кут ланки 3: " + Convert.ToString(Math.Round(mechanism.fi_3n, 4)) + " рад";
            this.labelFi4n.Content = "Кут ланки 4: " + Convert.ToString(Math.Round(mechanism.fi_4n, 4)) + " рад";
            if (checkBoxVisibleCoordinats.IsChecked.Value)
            {
                visible_coordinates(ref plan);
            }
        }
        private void visible_coordinates(ref MechanismAnalys.PlanPositionParameters mechanism)
        {
            this.LabelA.Content = "A(" + Convert.ToString(Math.Round(MechanismAnalys.X_A, 4)) + " ; " + Convert.ToString(Math.Round(MechanismAnalys.Y_A, 4)) + ")";
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
            this.LabelS4.Margin = new Thickness(X_center + mechanism.X_S4n * score + 5, Y_center - mechanism.Y_S4n * score + 4, 0, 0);
        }
        
        private void DrawPlanPosition( ref MechanismAnalys.PlanPositionParameters mechanism)
        {
            this.A.Margin = new Thickness(X_center + MechanismAnalys.X_A * score-5, Y_center - MechanismAnalys.Y_A * score-5, 0, 0);
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
            this.LineCD.Y2 = Y_center - MechanismAnalys.Y_D * score;
             
            
            if (MechanismAnalys.IsAdditionalPoint)
            {
                this.LineBE.X1 = X_center + mechanism.X_Bn * score;
                this.LineBE.Y1 = Y_center - mechanism.Y_Bn * score;
                this.LineBE.X2 = X_center + mechanism.X_En * score;
                this.LineBE.Y2 = Y_center - mechanism.Y_En * score;
                this.E.Margin = new Thickness(X_center + mechanism.X_En * score - 5, Y_center - mechanism.Y_En * score - 5, 0, 0);
            }
            
        }
        

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Splot splot = new Splot();
            splot.ShowDialog();
            timer.Start();
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
            Point end = new Point(plan.X_Bn * score + Xcenter, Ycenter - plan.Y_Bn * score);
            //res.Children.Add(new LineGeometry(new Point(Xcenter, Ycenter), new Point(plan.X_Bn * Score + Xcenter, Ycenter - plan.Y_Bn * Score)));
            res.Children.Add(new LineGeometry(start,end));

            this.PathPlanePosition.Data = res;
        }
        //public static double Score;
        public static int Xcenter, Ycenter;

        private void checkBoxVisibleCoordinats_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void checkBoxVisibleCoordinats_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxVisibleCoordinats.IsChecked.Value)
            {
                LabelA.Visibility = System.Windows.Visibility.Visible;
                LabelB.Visibility = System.Windows.Visibility.Visible;
                LabelC.Visibility = System.Windows.Visibility.Visible;
                LabelD.Visibility = System.Windows.Visibility.Visible;
                //LabelE.Visibility = System.Windows.Visibility.Visible;
                LabelS2.Visibility = System.Windows.Visibility.Visible;
                LabelS3.Visibility = System.Windows.Visibility.Visible;
                LabelS4.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                LabelA.Content = " ";
                LabelB.Margin = new Thickness(-100, -100, 0, 0);
                LabelC.Margin = new Thickness(-100, -100, 0, 0);
                LabelD.Margin = new Thickness(-100, -100, 0, 0);
                //abelE.Margin = new Thickness(-100, -100, 0, 0);
                LabelS2.Margin = new Thickness(-100, -100, 0, 0);
                LabelS3.Margin = new Thickness(-100, -100, 0, 0);
                LabelS4.Margin = new Thickness(-100, -100, 0, 0);
            }
        }
        public void DrawTraectory(ref MechanismAnalys.PlanPositionParameters[] mechnism, ref GeometryGroup g, MechanismAnalys.NumberPoints point)
        {
            
            Point start;
            if (point == MechanismAnalys.NumberPoints.C)
            {
                Point end = new Point(X_center + mechnism[0].X_Cn * score, Y_center - mechnism[0].Y_Cn * score);
                for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
                {

                    start = end;
                    end = new Point(X_center + mechnism[n].X_Cn * score, Y_center - mechnism[n].Y_Cn * score);
                    LineGeometry l = new LineGeometry(start, end);
                    g.Children.Add(l);
                };
                start = end;
                end = new Point(X_center + mechnism[0].X_Cn * score, Y_center - mechnism[0].Y_Cn * score);
                LineGeometry lk = new LineGeometry(start, end);
                g.Children.Add(lk);
            }
            else if (point == MechanismAnalys.NumberPoints.B)
            {
                Point end = new Point(X_center + mechnism[0].X_Bn * score, Y_center - mechnism[0].Y_Bn * score);
                for (int n = 1; n < MechanismAnalys.QuantIteration; n++)
                {
                    start = end;
                    end = new Point(X_center + mechnism[n].X_Bn * score, Y_center - mechnism[n].Y_Bn * score);
                    LineGeometry l = new LineGeometry(start, end);
                    g.Children.Add(l);
                };
                start = end;
                end = new Point(X_center + mechnism[0].X_Bn * score, Y_center - mechnism[0].Y_Bn * score);
                LineGeometry lk = new LineGeometry(start, end);
                g.Children.Add(lk);
            }
            else if (point == MechanismAnalys.NumberPoints.E)
            {
                Point end = new Point(X_center + mechnism[0].X_En * score, Y_center - mechnism[0].Y_En * score);
                for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
                {

                    start = end;
                    end = new Point(X_center + mechnism[n].X_En * score, Y_center - mechnism[n].Y_En * score);
                    LineGeometry l = new LineGeometry(start, end);
                    g.Children.Add(l);
                };
                start = end;
                end = new Point(X_center + mechnism[0].X_En * score, Y_center - mechnism[0].Y_En * score);
                LineGeometry lk = new LineGeometry(start, end);
                g.Children.Add(lk);
            }           
        }              

        private void canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            Point point = e.GetPosition(this.canvas);
            labelCoordinatsMouse.Content = "(" + Math.Round((point.X - X_center) / score, 4) + ";" + Math.Round((X_center - point.Y) / score, 4) + ")";
        }
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