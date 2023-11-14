using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public AudioSource magic;
   void OnTriggerEnter(Collider collider){
    if(collider.CompareTag("Player")){
        No_Exit.altar_found = true;
        gameObject.SetActive(false);
        magic.Play();
    }
   }
}
