using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StatusImg : MonoBehaviour, ITrackableEventHandler
{

    public bool isDetected = false;

    public MatchAttributes[] colliderChild;

    [TextArea(4,15)]
    public string txtInfo;


    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        colliderChild = GetComponentsInChildren<MatchAttributes>();
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            isDetected = true;
            Debug.LogError("Siempre activo");
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            isDetected = false;
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            isDetected = false;
        }
    }

    public void HideText()
    {
        int totalCollision = 0;
        for (int i = 0; i < colliderChild.Length; i++)
        {
            if(colliderChild[i].colliding)
            {
                totalCollision++;
            }
        }
        Debug.LogError("Total de collisiones");

    }
}
