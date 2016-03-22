using System;

public class Observer: IObserver
{
	public delegate void NotifyCallback (BuffableProperty value);

	private NotifyCallback callback;

	public Observer (NotifyCallback callback)
	{
		this.callback = callback;
	}

	public void Notify (BuffableProperty value)
	{
		callback (value);
	}
}
