using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Cellphone : MonoBehaviour

{   
    public GameObject battery_3d;
    public GameObject cam;
    public AudioSource flashlight_sound;
    public GameObject flashlight;
    public float zoom_max = 30;
    public float zoom_minum = 50;
    public RawImage battery_100;
    public RawImage battery_50;
    public RawImage battery_10;
    public RawImage battery_0;
    public static float battery = 100;
    public float time_limit = 2;
    float time_decurred = 0;
    bool light_on = true;
    bool battery_minum = false;
    bool recharge = false;
    public static bool battery_max = false;

    void Update()
{   
    if(battery >= 100){
        battery_max = true;
    }
    if(battery <= 100){
        battery_max = false;
    }
      
       time_decurred += Time.deltaTime;

        if(time_decurred >= time_limit && battery_minum == false )
        {
            battery --;
            time_decurred = 0;
        } 


            battery_100.GetComponent<RawImage>().enabled = false;   
            battery_50.GetComponent<RawImage>().enabled = false;   
            battery_10.GetComponent<RawImage>().enabled = false;
            battery_0.GetComponent<RawImage>().enabled = false;

        if(battery > 50){
            battery_100.GetComponent<RawImage>().enabled = true;
        }
        if(battery <= 50 && battery > 10){
            battery_50.GetComponent<RawImage>().enabled = true;
        }
        if(battery <= 10 && battery > 0){
            battery_10.GetComponent<RawImage>().enabled = true;   
        }
        if(battery <= 0 ){
            //battery_10.GetComponent<RawImage>().enabled = false;    
            battery_0.GetComponent<RawImage>().enabled = true;
            battery_minum = true;
        }
        if(battery_0.GetComponent<RawImage>().enabled == true){
          GetComponent<MeshRenderer>().enabled = false;
          light_on = false;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
        cam.GetComponent<Camera>().fieldOfView = zoom_max;
        }
         if(Input.GetKeyDown(KeyCode.Z)){
        cam.GetComponent<Camera>().fieldOfView = zoom_minum;
        } 
        if(Input.GetKeyDown(KeyCode.F) && battery > 0){
        light_on = !light_on;
        flashlight_sound.Play();
        }
       flashlight.GetComponent<Light>().enabled = light_on;
}
   
}
