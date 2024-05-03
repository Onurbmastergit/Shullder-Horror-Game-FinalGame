using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_3D : MonoBehaviour
{ 
    public AudioSource pickup_battery;
    public float speed = 10f;
    void Update()
    {
        transform.Rotate(0,0,speed*Time.deltaTime);

    }
      void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player") && Cellphone.battery_max == false){
        pickup_battery.Play();
        Cellphone.battery += 70;
        Destroy(gameObject);
    }
  }
}
