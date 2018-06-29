using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
using System;

public class GroudOnImageTarget : MonoBehaviour {
    

    [Header("Called while camera looking Image Target, transmit Screen position of a Image Target Anchor")]
    public AnchorInputListenerBehaviour.InputReceivedEvent OnImageLooking;
    [Header("Called while verifide return hit from finder, transmit this HitResult")]
    public HitTestEvent OnAcceptUserHit;
   
    public GameObject GroudFinderAnchor;

    private ImageTargetAnchor _registeredTarget;
    private HitTestResult _lastHitResult;

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
    public void ReceiveHit(HitTestResult hit)
    {
        _lastHitResult = hit;
    }

	void Start () 
    {
        GroudFinderAnchor.SetActive(false);
	}
	void Update () 
    {
        GroudFinderAnchor.SetActive(false);
        if (_registeredTarget)
        {
            var screenpos = VuforiaManager.Instance.ARCameraTransform.GetComponent<Camera>().WorldToScreenPoint(_registeredTarget.transform.position);
            OnImageLooking.Invoke(new Vector2(screenpos.x, screenpos.y));
            if(_lastHitResult!=null&&_lastHitResult.HitTestPtr!=IntPtr.Zero)
            {
                GroudFinderAnchor.SetActive(true);
                GroudFinderAnchor.transform.position = _lastHitResult.Position;
                GroudFinderAnchor.transform.rotation = _lastHitResult.Rotation;
                if(Input.touchCount == 2){
                    OnAcceptUserHit.Invoke(_lastHitResult);
                }
            }
        }
          
	}
}
