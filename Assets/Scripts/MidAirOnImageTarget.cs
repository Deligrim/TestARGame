using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using UnityEngine.Events;


public class MidAirOnImageTarget : MonoBehaviour
{
    public TransformEvent OnAcceptUserHit;

    private ImageTargetAnchor _registeredTarget;


    public void TargetRegister(ImageTargetAnchor target)
    {
        _registeredTarget = target;
        target.ShowAnchor();
    }
    public void TargetRemove(ImageTargetAnchor target)
    {
        _registeredTarget = null;
        target.HideAnchor();
    }

    void Start()
    {
        
    }
    void Update()
    {
        if (_registeredTarget)
        {

            if (Input.touchCount == 2)
            {
                OnAcceptUserHit.Invoke(_registeredTarget.transform);
            }

        }
    }
    [Serializable]
    public class TransformEvent : UnityEvent<Transform>
    {
        public TransformEvent()
        {

        }
    }

}
