using UnityEngine;
using System.Collections;
using Vuforia;

public class ImageTargetScript : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public GameObject otherObject;
	public GPSscript otherScript;

    void Start(){
    	otherObject = GameObject.Find("MyText");
        otherScript = otherObject.GetComponent<GPSscript>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour){
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        
    }
     
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus){
        // Debug.Log("HAHA");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED){
            // Play audio when target is found
        	otherScript.tracking = true;
        }
        else{
            // Stop audio when target is lost
        	otherScript.tracking = false;
        }
    }   
}
