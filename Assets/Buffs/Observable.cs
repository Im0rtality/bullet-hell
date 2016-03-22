using System;
using System.Collections;
using System.Collections.Generic;

public class Observable
{
	private List<IObserver> observers = new List<IObserver> ();

	public void Register (IObserver observer)
	{
		observers.Add (observer);
	}

	public void Notify (BuffableProperty value)
	{
		observers.ForEach (observer => observer.Notify (value));
	}
}