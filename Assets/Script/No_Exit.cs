using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_Exit : MonoBehaviour
{
 public Collider collision1;
  public AudioSource close_door;
   public AudioSource opened;
  public GameObject open;
   public GameObject close;
  public static bool altar_found = false;
void Update()
{
  if(altar_found == true){
    close.SetActive(false);
    open.SetActive(true);
     opened.Play();
  }
}
  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        collision1.enabled = false;
        close.SetActive (true);
        open.SetActive (false);
        close_door.Play();
        Mission.enter_on = true;
    }
  }
}
