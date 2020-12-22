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
        public MainWindow main_window;
        private void buttonCalculation_Click(object sender, RoutedEventArgs e)
        {
            InputParameters();
            ShowMainWindow();
            main_window.StartAnimation();
        }
        private void InputParameters()
        {
            MechanismAnalys.L_AB = Convert.ToDouble(textBoxL_AB.Text);
            MechanismAnalys.L_BC = Convert.ToDouble(textBoxL_BC.Text);
            MechanismAnalys.L_CD = Convert.ToDouble(textBoxL_CD.Text);
            MechanismAnalys.L_AD = Convert.ToDouble(textBoxL_AD.Text);
            MechanismAnalys.L_AS2 = Convert.ToDouble(textBoxL_AS2.Text);
            MechanismAnalys.L_BS3 = Convert.ToDouble(textBoxL_BS3.Text);
            MechanismAnalys.L_DS4 = Convert.ToDouble(textBoxL_DS4.Text);
            MechanismAnalys.Omega = Convert.ToDouble(textBoxOmega.Text);
            if (checkBoxOmegaDirect.IsChecked.Value)
                { MechanismAnalys.OmegaDirection = -1; }
            else MechanismAnalys.OmegaDirection = 1;
            MechanismAnalys.Epsilon = Convert.ToDouble(textBoxEpsilon.Text);
            if (checkBoxEpsilonDirect.IsChecked.Value)
            { MechanismAnalys.EpsilonDirection = -1; }
            else MechanismAnalys.EpsilonDirection = 1;
            DrawingMechanism.QuantPosition = Convert.ToInt32(textBoxQuantsPosition.Text);
            //echanismAnalys.InitParameter(QuantPosition);
        }
        private void ShowMainWindow()
        {
            main_window = new MainWindow();
            main_window.Show();
        }
       
    }
}
