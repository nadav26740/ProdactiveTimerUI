using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Prodactivity_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer ticker = new DispatcherTimer();
        bool ticker_status = false;
        TimeSpan Duration = new TimeSpan(0);

        public MainWindow()
        {
            InitializeComponent();
            ticker.Tick += On_Tick;
            ticker.Interval = TimeSpan.FromSeconds(1);
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
            if (Duration.Ticks > 0)
            {
                Duration -= TimeSpan.FromSeconds(1); // taking of second
            }
            else
            {
                ChangeTickerStatus();
            }
            Show_Duration_In_UI();
        }

        void Show_Duration_In_UI()
        {
            TimeLabel.Text = Duration.ToString("hh") + ":" + Duration.ToString("mm") + ":" + Duration.ToString("ss");
        }

        private void add_Minutes_Button_Pressed(object sender, MouseButtonEventArgs e)
        {
            Duration += TimeSpan.FromMinutes(10);
            Show_Duration_In_UI();
        }

        private void StartStop_Button_Pressed(object sender, MouseButtonEventArgs e)
        {
            if (Duration.Ticks > 0)
            {
                ChangeTickerStatus();

            }
        }

        private void ChangeTickerStatus()
        {
            if (ticker_status)
            {
                startStop_Button_label.Text = "Start";
                ticker.Stop();
                Spinner_storyBoard.Stop();
            }
            else
            {
                startStop_Button_label.Text = "Stop";
                Spinner_storyBoard.RepeatBehavior = RepeatBehavior.Forever;
                Spinner_storyBoard.Begin();
                ticker.Start();
            }
            ticker_status = !ticker_status;
        }
    }
}
