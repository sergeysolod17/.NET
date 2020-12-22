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

namespace TMM_WPF
{
    /// <summary>
    /// Interaction logic for TableResult.xaml
    /// </summary>
    public partial class TableResult : Page
    {
        public TableResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ShowTable()
        {
            this.dataGrid1.BindingGroup = new BindingGroup();
            
        }
    }
}
