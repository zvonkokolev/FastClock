using System;

namespace EventsDemo.FastClockWpf
{
	/// <summary>
	/// Interaction logic for DigitalClock.xaml
	/// </summary>
	public partial class DigitalClock
	{
		//private readonly DigitalClock _digitalClock;
		protected readonly FastClock.FastClock _fastClock;
		public DigitalClock()
		{
			InitializeComponent();
		}
		private void Window_Initialized(object sender, EventArgs e)
		{
		}
	}
}
