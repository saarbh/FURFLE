using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;


    public FirstPersonAIO FirstPersonAIO1;
    public FirstPersonAIO FirstPersonAIO2;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    // Use this for initialization
    void Start()
    {
      Debug.Log("Transform Tag is: " + cameraTwo.tag);
      Debug.Log("Transform Tag is: " + cameraOne.tag);
        FirstPersonAIO1 = GameObject.Find("PinkGirl").GetComponent<FirstPersonAIO>();
        FirstPersonAIO2 = GameObject.Find("CowBoy").GetComponent<FirstPersonAIO>();
      
        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        
        if (Input.GetMouseButtonDown(0))
         { 
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              Debug.Log(ray);
             float distance = 40;
             RaycastHit hit;
             if (Physics.Linecast(ray.origin, ray.origin + ray.direction * distance, out hit))
             {
                Debug.Log(hit.transform.name);

                if(hit.transform.name == "CowBoy"){
                    cameraPositionChange(1);
                }
                if(hit.transform.name == "PinkGirl"){
                cameraPositionChange(0);}
                
             }
         }      
    }  

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
          Debug.Log(camPosition);
        //Set camera position 0
        if (camPosition == 0)
        {
            cameraTwo.tag = "Untagged";
            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);
            FirstPersonAIO2.enabled = false;

            cameraOne.tag = "MainCamera";
            FirstPersonAIO1.enabled = true;
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            
        }

        //Set camera position 1
        if (camPosition == 1)
        {
      cameraOne.SetActive(false);   

            cameraOne.tag = "Untagged";
             FirstPersonAIO1.enabled = false;   
            cameraOneAudioLis.enabled = false;   

            cameraTwo.tag = "MainCamera";
            FirstPersonAIO2.enabled = true;
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;
            
        }

    }
}
