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
        //enum NumberSplot {int SpeedPointB};
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawSplot(2, ref DrawingMechanism.array_mechanism, DrawingMechanism.QuantPosition);
        }
        
        public void DrawSplot(int NumberSplot, ref MechanismAnalys [] array, int QuantPosition)
        {double max_value = 0;
        double [] values = new double [QuantPosition];
            switch (NumberSplot)
        {
            case 2:
                for (int n = 0; n < QuantPosition; n++)
                    {
                        values[n] = array[n].v_Cn;
                        if (Math.Abs(values[n]) > max_value)
                            { max_value = Math.Abs(values[n]); }
                    };
                DrawSplotByPoints(QuantPosition, ref values, max_value);
                break;
                
         };
        }
        public void DrawSplotByPoints(int QuantPosition, ref double [] array, double max_value)
        {

            //string points = "M 0,0";
            GeometryGroup g = new GeometryGroup();
            double score = (canvasSplot.Height - 20)/max_value;
            double step_x = (canvasSplot.Width - 20)/QuantPosition;
            int y_axis = 390;
            PathGeometry path_ = new PathGeometry();
            Point point_start = new Point(0, y_axis - Math.Round(array[0] * score));
            Point point_end = new Point(0, 0);

            for (int n = 0; n < QuantPosition; n++)
            {
                //points += " L " + Convert.ToString(Math.Round((n + 1) * step_x)) + ","+Convert.ToString(Math.Round(array[n] * score));

                point_start.X = Math.Round((n + 1) * step_x);
                point_start.Y = y_axis - Math.Round(array[n] * score);
                LineGeometry l = new LineGeometry(point_end, point_start); 
                point_end = point_start;
                //l.EndPoint = new Point(Math.Round((n + 1) * step_x), array[n] * score);
                g.Children.Add(l);
            };
            
            this.GeometrySplot.Data = g;

            //path_.Figures.Add(new PathFigure(
            //this.GeometrySplot.Data = new PathGeometry(new Path;
            
        }
    }
}
