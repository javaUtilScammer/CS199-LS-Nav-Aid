using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingArrowScript : MonoBehaviour{
	
	public GameObject cube, camera;
	public float rot;
	private GameObject dropdown, btn;
	private bool valid, done;
	private Text txt;
	private float destLat, destLon;
	private string destLoc;
	private int val;

	IEnumerator Start(){
		// Input.location.Start();
		valid = true;
		Input.compass.enabled = true;
		txt = GameObject.Find("MessageText").GetComponent<Text>();
		dropdown = GameObject.Find("DestList");
		btn = GameObject.Find("ConfirmButton");
        Dropdown dd = dropdown.GetComponent<Dropdown>();
		val = dd.value;
		if(val==0) valid = false;
        
		// First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        	valid = false;
            // yield break;

        // Start service before querying location
        Input.location.Start(0.1f, 0.1f);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
            yield return new WaitForSeconds(1);
            // changeText(maxWait+"");
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1){
            // someText.text = "Timed out";
            // print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed){
            // someText.text = "Unable to determine device location";
            // print("Unable to determine device location");
            yield break;
        }
        else{
            // Access granted and location value could be retrieved
            if(valid){
				destLoc = dd.options[val].text;
				getLatLon(val);
				dropdown.SetActive(false);
				btn.SetActive(false);
            	cube.SetActive(true);
				setPosition();
            }
        }
		
        // Stop service if there is no need to query location updates continuously
        // Input.location.Stop();
	}

	void getLatLon(int val){
		if(val==1){
			destLat = 14.6387413f;
			destLon = 121.0796711f;
		}
		else if(val==2){
			destLat = 14.6416518f;
			destLon = 121.0797779f;
		}
		else if(val==3){
			destLat = 14.6394942f;
			destLon = 121.0785127f;
		}
		else if(val==4){
			destLat = 14.6352561f;
			destLon = 121.0755483f;
		}
		else if(val==5){
			destLat = 14.6392334f;
			destLon = 121.0803981f;
		}
		else if(val==6){
			destLat = 14.6401900f;
			destLon = 121.0799803f;
		}
		else if(val==7){
			destLat = 14.6364309f;
			destLon = 121.0783372f;
		}
		else if(val==8){
			destLat = 14.6369412f;
			destLon = 121.0788988f;
		}
		else if(val==9){
			destLat = 14.6399850f;
			destLon = 121.0767347f;
		}
		else if(val==10){
			destLat = 14.6386889f;
			destLon = 121.0804146f;
		}
		else if(val==11){
			destLat = 14.6382039f;
			destLon = 121.0774633f;
		}
		else if(val==12){
			destLat = 14.6401997f;
			destLon = 121.0778601f;
		}
		else if(val==13){
			destLat = 14.6395065f;
			destLon = 121.0767193f;
		}
		else if(val==14){
			destLat = 14.6389641f;
			destLon = 121.0781854f;
		}
		else if(val==15){
			destLat = 14.6351955f;
			destLon = 121.0766706f;
		}
		else if(val==16){
			destLat = 14.6384758f;
			destLon = 121.0763518f;
		}
		else if(val==17){
			destLat = 14.6377805f;
			destLon = 121.0764395f;
		}
		else if(val==18){
			destLat = 14.6397787f;
			destLon = 121.0780598f;
		}
		else if(val==19){
			destLat = 14.6406405f;
			destLon = 121.0762996f;
		}
		else if(val==20){
			destLat = 14.6360702f;
			destLon = 121.0777993f;
		}
		else if(val==21){
			destLat = 14.6375399f;
			destLon = 121.0769940f;
		}
		else if(val==22){
			destLat = 14.6396980f;
			destLon = 121.0774399f;
		}
		else if(val==23){
			destLat = 14.6400883f;
			destLon = 121.0760601f;
		}
		else if(val==24){
			destLat = 14.6389821f;
			destLon = 121.0767668f;
		}
		else if(val==25){
			destLat = 14.6381749f;
			destLon = 121.0763520f;
		}
		else if(val==26){
			destLat = 14.6402668f;
			destLon = 121.0774594f;
		}
		else if(val==27){
			destLat = 14.6392054f;
			destLon = 121.0774710f;
		}
		else if(val==28){
			destLat = 14.6382194f;
			destLon = 121.0777003f;
		}
		else if(val==29){
			destLat = 14.6379609f;
			destLon = 121.0772245f;
		}
		else if(val==30){
			destLat = 14.6380147f;
			destLon = 121.0768485f;
		}
		else if(val==31){
			destLat = 14.6406518f;
			destLon = 121.0768412f;
		}
		else if(val==32){
			destLat = 14.6393620f;
			destLon = 121.0810702f;
		}
		else if(val==33){
			destLat = 14.6399802f;
			destLon = 121.0784475f;
		}
	}

	float getDist(){
		float lat1 = Input.location.lastData.latitude;
		float lon1 = Input.location.lastData.longitude;
		// float lat1 = 14.639603f;
		// float lon1 = 121.081111f;
		float lat2 = destLat;
		float lon2 = destLon;
		float R = 6371000f;
		float dLat = Mathf.Deg2Rad*(lat2 - lat1);
	    float dLon = Mathf.Deg2Rad*(lon2 - lon1);
	    lat1 = Mathf.Deg2Rad*(lat1);
	    lat2 = Mathf.Deg2Rad*(lat2);
	 
	    float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2) * Mathf.Cos(lat1) * Mathf.Cos(lat2);
	    float c = 2 * Mathf.Asin(Mathf.Sqrt(a));
	    return R * 2 * Mathf.Asin(Mathf.Sqrt(a));
	}

	void setPosition(){
		float myLat = Input.location.lastData.latitude;
		float myLon = Input.location.lastData.longitude;
		// float myLat = 14.639603f;
		// float myLon = 121.081111f;
		Vector2 vec = new Vector2(destLon-myLon,destLat-myLat);
		vec.Normalize();
		float x = vec.x*5;
		float y = vec.y*5;
		// txt.text = x+"\n"+y;
		cube.transform.position = new Vector3(x,0,y);
	}

	void Update(){
		// float offset = getOffset();
		// float dir = (Input.compass.trueHeading+offset)* Mathf.Deg2Rad;
		// float x = (Mathf.Cos(dir))*5;
		// float y = (Mathf.Sin(dir))*5;
        // cube.transform.eulerAngles = new Vector3(0,Input.compass.trueHeading,0);
        if(!valid){
        	if(!done){
				if(val==0)
					txt.text = "Invalid destination was selected.\n Please restart the app.";
				else
					txt.text = "GPS location is not enabled in this device.\n Please activate and then restart the app.";
				done = true;
        	}
        }
        else{
	        rot = Input.compass.trueHeading;
	        camera.transform.eulerAngles = new Vector3(0,rot,0);
	        setPosition();
	        cube.transform.eulerAngles = new Vector3(63.6076f,rot,180f);
	        txt.text = "Destination selected! Follow the arrow on the screen toward "+destLoc+"\n";
			txt.text += "Distance: "+getDist()+"m\n";
			// txt.text += offset+" "+destLat+" "+destLon+" "+destLoc+" "+Input.location.lastData.latitude+" "+Input.location.lastData.longitude;
        }
	}

}

