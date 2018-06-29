using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Vuforia;
public class UnityEventTrackableHandler : DefaultTrackableEventHandler
{
    public UnityEvent OnFound;
    public UnityEvent OnLost;
    public bool CallBaseHandler;
	protected override void OnTrackingFound()
	{
        if(CallBaseHandler)
        base.OnTrackingFound();
        OnFound.Invoke();
	}
	protected override void OnTrackingLost()
	{
        if (CallBaseHandler)
        base.OnTrackingLost();
        OnLost.Invoke();
	}
}
