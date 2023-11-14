using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked_Sound : MonoBehaviour
{
   
public AudioSource locked;
  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        locked.Play();
    }
  }
    void OnTriggerExit(Collider other)
  {
    if(other.CompareTag("Player")){
        locked.Stop();
    }
  }
}
