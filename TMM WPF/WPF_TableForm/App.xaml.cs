using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using TMM_Analys;

namespace WPF_TableForm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MechanismAnalys [] MechanismResult;
        public static void Calculation()
        {
            App.MechanismResult = new MechanismAnalys[MechanismAnalys.QuantIteration];
            MechanismAnalys.CalculationMode = MechanismAnalys.CalculationModes.CalcVelocities;
            for (int n = 0; n < MechanismAnalys.QuantIteration; n++)
            {
                App.MechanismResult[n] = new MechanismAnalys();
                try
                {
                    App.MechanismResult[n].Calculation(n);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Помилка. Перевірте правильність введених даних.");
                    return;
                }
            }
        }
    }
}
