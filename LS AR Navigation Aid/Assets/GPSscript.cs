using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GPSscript : MonoBehaviour {
	public Text someText;
	public bool tracking;
	
	void changeText(string text){
		someText.text = text;
	}

	IEnumerator Start(){
		tracking = false;
		Input.compass.enabled = true;
		Input.location.Start();
		someText = GetComponent<Text>();
		// First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start(0.1f, 0.1f);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            changeText(maxWait+"");
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            someText.text = "Timed out";
            // print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            someText.text = "Unable to determine device location";
            // print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            someText.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            someText.text += "\nDirection: "+Input.compass.trueHeading;
            someText.text += "\nTracking: "+tracking;
            // print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        // Input.location.Stop();
	}

	void Update(){
		// someText.text = "LOLOLOL";
        someText.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        someText.text += "\nDirection: "+Input.compass.trueHeading;
		someText.text += "\nTracking: "+tracking;
	}

}

