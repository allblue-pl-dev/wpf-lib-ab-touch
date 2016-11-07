using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ABTouch
{
    public class ABTRestTimer
    {

        const int DefaultTimerInterval = 180;


        private Window window = null;
        private Action callback = null;

        private DispatcherTimer timer = null;

        int timerInterval = ABTRestTimer.DefaultTimerInterval;


        public ABTRestTimer(Window window, Action callback, int timer_interval_in_seconds)
        {
            this.window = window;
            this.callback = callback;
            this.timerInterval = timer_interval_in_seconds;

            window.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.button_Click), true);
            window.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(this.uiElement_MouseButtonUp), true);

            this.resetTimer();
        }

        public ABTRestTimer(Window window, Action callback) :
                this(window, callback, ABTRestTimer.DefaultTimerInterval)
        {

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.resetTimer();
        }

        private void resetTimer()
        {
            if (this.timer != null)
                this.timer.Stop();

            this.timer = new DispatcherTimer();
            this.timer.Tick += this.timer_Tick;
            this.timer.Interval = new TimeSpan(0, 0, this.timerInterval);
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.callback();
        }

        private void uiElement_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.resetTimer();
        }

    }
}

