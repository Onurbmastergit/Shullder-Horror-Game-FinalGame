using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Script : MonoBehaviour
{   
    public AudioSource key_pickup;

     void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        Mission.key_founds = +1;
        key_pickup.Play();
        Door_Outside.key_found = true;
        Door_Inside.key_found = true;
        Destroy(gameObject);
        
    }
  }
}
