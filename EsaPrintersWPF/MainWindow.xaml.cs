using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Printing;

namespace EsaPrintersWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            printerList.Items.Add(new Printer("SRVODEPRN11V.rsyd.net"));
            printerList.Items.Add(new Printer("SRVODEPRN12V.rsyd.net"));
            printerList.Items.Add(new Printer("SRVODEPRN13V.rsyd.net"));
            printerList.Items.Add(new Printer("SRVODEPRN14V.rsyd.net"));
            printerList.Items.Add(new Printer("SRVODEPRN15V.rsyd.net"));
            printerList.Items.Add(new Printer("SRVODEPRN16V.rsyd.net"));
        }

        private class Printer
        {
            public string Name;

            public Printer(string name)
            {
                Name = name;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        private void printerList_SelectionChanged(object sender, EventArgs e)
        {
            Printer prn = (Printer)printerList.SelectedItem;
            using (var printServer = new PrintServer(string.Format(@"\\{0}", prn)))
            {
                foreach (var queue in printServer.GetPrintQueues())
                {
                    if (!queue.IsShared)
                    {
                        continue;

                    }
                    lbPrinters.Items.Add(queue.Name + Environment.NewLine);
                }
            }
        }

        private void getPrnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lbPrinters.SelectedIndex > 0)
            {
                MessageBox.Show(lbPrinters);
            }
        }

       

      
    }
}
