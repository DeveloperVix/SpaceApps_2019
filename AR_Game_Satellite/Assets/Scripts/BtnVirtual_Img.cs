using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BtnVirtual_Img : MonoBehaviour, IVirtualButtonEventHandler
{
    public VirtualButtonBehaviour vbObj;
    public StatusImg statusImg;

    private void Start() {
        vbObj.RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        statusImg.ShowInfo();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.LogError("Virtual btn released");
    }
}
