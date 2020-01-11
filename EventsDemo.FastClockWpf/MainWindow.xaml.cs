using System;
using System.Windows;

namespace EventsDemo.FastClockWpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		protected readonly FastClock.FastClock _fastClock;
		private DigitalClock _digitalClock;
		public bool IsButtonClicked { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
			_fastClock = new FastClock.FastClock(dateTime);
		}

		private void MetroWindow_Initialized(object sender, EventArgs e)
		{
			DatePickerDate.SelectedDate = DateTime.Today;
			TextBoxTime.Text = DateTime.Now.ToShortTimeString();
		}
		
		private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
		{
			DatePickerDate.SelectedDate = DatePickerDate.SelectedDate;
			TextBoxTime.Text = TextBoxTime.Text;
			SetFastClockStartDateAndTime();
		}

		private void SetFastClockStartDateAndTime()
		{
			textBlockDate.Text = DatePickerDate.SelectedDate.Value.ToShortDateString();
			textBlockTime.Text = TextBoxTime.Text;
		}

		public void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
		{
			textBlockDate.Text = fastClockTime.Date.ToShortDateString();
			textBlockTime.Text = fastClockTime.ToShortTimeString();
			if (IsButtonClicked)
			{
				_digitalClock = new DigitalClock();
				IsButtonClicked = false;
			}
			if (_digitalClock != null)
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
			IsButtonClicked = true;
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
