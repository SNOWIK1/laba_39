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
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace Laba_39
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PortManager.GetPortsInfo();
            //List<PortInfo> pi = PortManager.;
            //listview_scaner.ItemsSource = pi;

            Thread myThread = new Thread(Print);

            myThread.Start();


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Главный поток: {i}");
                Thread.Sleep(50);
            }


            void Print()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Второй поток: {i}");
                    Thread.Sleep(60);
                }
            }
        }
    }
}

/*
Главный поток: 0
Второй поток: 0
Главный поток: 1
Второй поток: 1
Главный поток: 2
Второй поток: 2
Главный поток: 3
Второй поток: 3
Главный поток: 4
*/
