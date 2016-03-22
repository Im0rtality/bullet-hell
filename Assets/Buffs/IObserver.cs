using System;

public interface IObserver
{
	void Notify (BuffableProperty value);
}
