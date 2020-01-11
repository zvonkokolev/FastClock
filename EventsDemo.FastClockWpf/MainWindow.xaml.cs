using System;
using System.Windows;
using EventsDemo.FastClock;

namespace EventsDemo.FastClockWpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private FastClock.FastClock _fastClock;
		private DigitalClock _digitalClock;
		private bool _isButtonClicked;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MetroWindow_Initialized(object sender, EventArgs e)
		{
			DatePickerDate.SelectedDate = DateTime.Today;
			TextBoxTime.Text = DateTime.Now.ToShortTimeString();
			DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
			_fastClock = new FastClock.FastClock(dateTime);
		}
		
		private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
		{
			DatePickerDate.SelectedDate = DateTime.Today;
			TextBoxTime.Text = DateTime.Now.ToShortTimeString();
		}

		private void SetFastClockStartDateAndTime()
		{
			//_fastClock = new FastClock.FastClock(DateTime.Now);
			//_fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;
		}

		private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
		{
			textBlockDate.Text = fastClockTime.Date.ToShortDateString();
			textBlockTime.Text = fastClockTime.ToShortTimeString();
			if (_isButtonClicked)
			{
				_digitalClock = new DigitalClock();
				_isButtonClicked = false;
			}
			if(_digitalClock != null)
			{
				_digitalClock.Owner = this;
				_digitalClock.Show();
				_digitalClock.TextBlockClock.Text = fastClockTime.ToShortTimeString();
			}
		}

		private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
		{
			_fastClock.IsRunning = checkBoxClockRuns.IsChecked == true;
			_fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;
		}

		private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
		{
			_isButtonClicked = true;
			_fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;
		}

		private void SliderFactor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if(_fastClock != null)
			{
				_fastClock.Mply = SliderFactor.Value;
			}
		}
	}
}
