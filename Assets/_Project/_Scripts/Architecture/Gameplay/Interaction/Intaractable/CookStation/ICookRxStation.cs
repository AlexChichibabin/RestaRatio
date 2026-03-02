using System;

public interface ICookRxStation
{
	public IObservable<float> HeatTick { get; }
}
