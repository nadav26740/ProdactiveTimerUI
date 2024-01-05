using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Prodactivity_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Ticker = new DispatcherTimer();
        TimeSpan Duration = new TimeSpan(0);

        public MainWindow()
        {
            InitializeComponent();
            Ticker.Tick += On_Tick;
            Ticker.Interval = TimeSpan.FromSeconds(1);
        }

        private void Exit_button_Pressed(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown(0);
        }

        private void DragBar_Held(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            
        }

        void On_Tick(object sender, EventArgs e)
        {
            Show_Duration_In_UI();
        }

        void Show_Duration_In_UI()
        {
            TimeLabel.Text = Duration.ToString("hh:mm:ss");
        }

        
    }
}
