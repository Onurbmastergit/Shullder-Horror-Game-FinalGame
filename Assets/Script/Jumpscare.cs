using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumpscare : MonoBehaviour
{
   public Collider collision1;
  public AudioSource scream;
  public RawImage jumpscare;
  public RawImage jumpscare2;
void Update()
{
 
}
  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        collision1.enabled = false;
        jumpscare.GetComponent<RawImage>().enabled = true;
        jumpscare2.enabled = true;
        scream.Play();
        Controller_Player.tired_out = true;
        StartCoroutine(repeat());
    }
  }
  IEnumerator repeat()
  {
    yield return new WaitForSeconds (2.0f);
    jumpscare.GetComponent<RawImage>().enabled = false;
    jumpscare2.enabled = false;
  }
}
