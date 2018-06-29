using UnityEngine;
using System.Collections;

public class ImageTargetAnchor : MonoBehaviour
{
    public GameObject AnchorObject;
    public bool CanActive;
    public void ShowAnchor()
    {
        if(CanActive)AnchorObject.SetActive(true);
    }
    public void HideAnchor()
    {
        if (CanActive)AnchorObject.SetActive(false);
    }
}
