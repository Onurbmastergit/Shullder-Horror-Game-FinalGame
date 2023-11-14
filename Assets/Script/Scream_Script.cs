using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Apear : MonoBehaviour
{
  public Collider collision1;
  public AudioSource scream;
  public GameObject monster;
void Update()
{

}
  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        collision1.enabled = false;
        monster.SetActive (true);
        scream.Play();
        Controller_Player.tired_out = true;
        StartCoroutine(repeat());
    }
  }
    IEnumerator repeat()
  {
    yield return new WaitForSeconds (3.0f);
    monster.SetActive(false);
  }
}
