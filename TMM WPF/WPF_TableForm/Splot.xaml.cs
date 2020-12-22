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
using System.Windows.Shapes;
using TMM_Analys;
using WPF_TableForm;

namespace TMM_WPF
{
    /// <summary>
    /// Interaction logic for Splot.xaml
    /// </summary>
    public partial class Splot : Window
    {
        public Splot()
        {
            InitializeComponent();
        }
        public enum NumberSplot:byte 
        {
            SpeedPointB = 1,
            SpeedPointC = 2,
            AngleSpeed2 = 3,
            AngleSpeed3 = 4,
            AngleSpeed4 = 5,
            Moment = 6,
            MomentInertia  = 7,
            DiagramEnergyMasa = 8
        };
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    DrawSplot(NumberSplot.SpeedPointB, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 1:
                    DrawSplot(NumberSplot.SpeedPointC, ref App.MechanismResult , TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 2:
                    DrawSplot(NumberSplot.AngleSpeed2, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 3:
                    DrawSplot(NumberSplot.AngleSpeed3, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 4:
                    DrawSplot(NumberSplot.AngleSpeed4, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 5:
                    DrawSplot(NumberSplot.Moment, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 6:
                    DrawSplot(NumberSplot.MomentInertia, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
                case 7:
                    DrawSplot(NumberSplot.DiagramEnergyMasa, ref App.MechanismResult, TMM_Analys.MechanismAnalys.QuantIteration);
                    break;
            }
        }
        
        public void DrawSplot(NumberSplot numberSplot, ref MechanismAnalys [] array, int QuantPosition)
        {        
        double [] values = new double [QuantPosition];
        switch (numberSplot)
        {
            case NumberSplot.SpeedPointC:
                for (int n = 0; n < QuantPosition; n++)
                    {
                        values[n] = array[n].v_Cn;                        
                    };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.SpeedPointB:
                for (int n = 0; n < QuantPosition; n++)
                    {
                        values[n] = array[n].v_Bn;
                    };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.AngleSpeed2:
                for (int n = 0; n < QuantPosition; n++)
                {
                    values[n] = array[n].omega_2n;                    
                };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.AngleSpeed3:
                for (int n = 0; n < QuantPosition; n++)
                {
                    values[n] = array[n].omega_3n;                    
                };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.AngleSpeed4:
                for (int n = 0; n < QuantPosition; n++)
                {
                    values[n] = array[n].omega_4n;
                };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.Moment:
                for (int n = 0; n < QuantPosition; n++)
                {
                    values[n] = array[n].Moment;
                };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.MomentInertia:
                for (int n = 0; n < QuantPosition; n++)
                {
                    values[n] = array[n].MomentInertia;
                };
                DrawSplotByPoints(QuantPosition, ref values);
                break;
            case NumberSplot.DiagramEnergyMasa:
                double[] values_inertia = new double[QuantPosition];
                double[] values_moment = new double[QuantPosition];
                for (int n = 0; n < QuantPosition; n++)
                {
                    values_inertia[n] = array[n].MomentInertia;
                    values_moment[n] = array[n].Moment;
                };
                DrawDiagramEnergyMasaByPoints(QuantPosition, ref values_moment, ref values_inertia);
                break;
         };
        }
        public void DrawDiagramEnergyMasaByPoints(int QuantPosition, ref double[] array_moment, ref double[] array_inertia)
        {
            double max_value_inertia = array_inertia.Max();
            double min_value_inertia = array_inertia.Min();
            double max_value_moment = array_moment.Max();
            double min_value_moment = array_moment.Min();
            double score_inertia = (max_value_inertia != min_value_inertia) ? canvasSplot.Height / (max_value_inertia - min_value_inertia) : canvasSplot.Height / max_value_inertia;
            double score_moment = (max_value_moment != min_value_moment) ? canvasSplot.Height / Math.Abs(max_value_moment - min_value_moment) : canvasSplot.Height / max_value_moment;
            double score = (score_inertia > score_moment) ? score_moment : score_inertia;
            double max_value = (score_inertia > score_moment) ? max_value_moment : max_value_inertia;
            int y_axis = Convert.ToInt32(Math.Round(max_value * score));
            double step_x = 1;// (canvasSplot.Width - 20) / (Math.Abs(max_value_inertia - min_value_inertia) * score);
            GeometryGroup g = new GeometryGroup();
            int x_center = (int)(-Math.Round(min_value_inertia));
            Point point_end = new Point(array_inertia[0]*score*step_x,  y_axis - Math.Round(array_moment[0] * score));
            Point point_start = new Point(0, 0);
            g.Children.Add(new LineGeometry(new Point(0, max_value * score), new Point(step_x * max_value_inertia*score, max_value * score)));
            for (int n = 1; n < QuantPosition; n++)
            {
                point_start.X = Math.Round(array_inertia[n]*score*step_x)+x_center;
                point_start.Y = y_axis - Math.Round(array_moment[n] * score);
                LineGeometry l = new LineGeometry(point_start, point_end);
                point_end = point_start;
                g.Children.Add(l);
            };
            this.GeometrySplot.Data = g;
        }
        public void DrawSplotByPoints(int QuantPosition, ref double [] array)
        {
            double max_value = array.Max();
            double min_value = array.Min();
            GeometryGroup g = new GeometryGroup();
            double score = (max_value!=min_value)?canvasSplot.Height / (max_value - min_value):canvasSplot.Height / max_value;
            double step_x = (canvasSplot.Width - 20)/QuantPosition;
            int y_axis = Convert.ToInt32(Math.Round(max_value*score));
            PathGeometry path_ = new PathGeometry();
            Point point_end = new Point(0, y_axis - Math.Round(array[0] * score));
            Point point_start = new Point(0, 0);
            g.Children.Add(new LineGeometry(new Point(0, max_value * score), new Point(step_x * QuantPosition, max_value * score)));
            for (int n = 0; n < QuantPosition; n++)
            {              
                point_start.X = Math.Round((n + 1) * step_x);
                point_start.Y = y_axis - Math.Round(array[n] * score);
                LineGeometry l = new LineGeometry(point_start,point_end); 
                point_end = point_start;
                g.Children.Add(l);
            };
            this.GeometrySplot.Data = g;
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
