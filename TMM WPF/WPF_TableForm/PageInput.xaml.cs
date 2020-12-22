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
using TMM_Analys;
using WPF_TableForm;
using System.Threading;

namespace TMM_WPF
{
    /// <summary>
    /// Interaction logic for PageInput.xaml
    /// </summary>
    public partial class PageInput : Page
    {
        public PageInput()
        {
            InitializeComponent();
        }
        //public TableForm table_form;
        private void buttonCalculation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InputParameters();
                App.Calculation();
                ShowTableWindow();
            }
            catch (ExceptionStopCalculation)
            {}
        }
        private void InputParameters()
        {
            try
            {
                MechanismAnalys.L_AB = Convert.ToDouble(textBoxL_AB.Text);
                MechanismAnalys.L_BC = Convert.ToDouble(textBoxL_BC.Text);
                MechanismAnalys.L_CD = Convert.ToDouble(textBoxL_CD.Text);
                MechanismAnalys.L_AD = Convert.ToDouble(textBoxL_AD.Text);
                MechanismAnalys.L_AS2 = Convert.ToDouble(textBoxL_AS2.Text);
                MechanismAnalys.L_BS3 = Convert.ToDouble(textBoxL_BS3.Text);
                MechanismAnalys.L_DS4 = Convert.ToDouble(textBoxL_DS4.Text);
                MechanismAnalys.Omega = Convert.ToDouble(textBoxOmega.Text);
                if (checkBoxIsCalculationE.IsChecked.Value)
                {
                    MechanismAnalys.L_BE = Convert.ToDouble(textBoxBE.Text);
                    MechanismAnalys.PointBeginBE = MechanismAnalys.NumberPoints.B;
                }
            }
            catch (MechanismAnalys.ExceptionIllegaValue e)
            { 
                MessageBox.Show("Недопустиме значення наступного параметра: " + e.NameParameter);
                throw new ExceptionStopCalculation();                
            }

            //test
            MechanismAnalys.g = 9.8;
            MechanismAnalys.M2 = 1.4;
            MechanismAnalys.M3 = 5.76;
            MechanismAnalys.M4 = 4.8;


            if (checkBoxOmegaDirect.IsChecked.Value)
                { MechanismAnalys.OmegaDirection = -1; }
            else MechanismAnalys.OmegaDirection = 1;
            MechanismAnalys.Epsilon = Convert.ToDouble(textBoxEpsilon.Text);
            if (checkBoxEpsilonDirect.IsChecked.Value)
                { MechanismAnalys.EpsilonDirection = -1; }
            else MechanismAnalys.EpsilonDirection = 1;
            MechanismAnalys.QuantIteration = Convert.ToInt32(textBoxQuantsPosition.Text);

            MechanismAnalys.DirectionLink4 = (checkBoxLink4Direction.IsChecked.Value)?MechanismAnalys.DirectionRotation.AgainClockWise:MechanismAnalys.DirectionRotation.OnClockWise;
            MechanismAnalys.CalculationMode = MechanismAnalys.CalculationModes.CalcVelocities;
            MechanismAnalys.IsInitialise = false;
        }
        private void ShowTableWindow()
        {
            FormTable table_form = new FormTable();
            table_form.OutPutRezultPlanPosition();
            table_form.ShowDialog();
            
        }

        private void buttonAnimation_Click(object sender, RoutedEventArgs e)
        {
            InputParameters();
            
            App.Calculation();
            MainWindow2 main_window = new MainWindow2();
            main_window.StartAnimation();
            main_window.ShowDialog();
        }

        private void checkBoxIsCalculationE_Click(object sender, RoutedEventArgs e)
        {
            labelBE.IsEnabled = textBoxBE.IsEnabled = checkBoxIsCalculationE.IsChecked.Value;
        }
        
       
    }
}
