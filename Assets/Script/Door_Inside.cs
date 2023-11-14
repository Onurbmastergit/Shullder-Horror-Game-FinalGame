using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Inside : MonoBehaviour
{   
    bool canOpenDoor = false;
    public static bool active_outside = true;
    public AudioSource lock_closed;
    public AudioSource opened;
    public AudioSource closed;
    public static bool key_found = false;    
    public bool locked = false;
    public RawImage icon;
    public Animator _animator;
    private bool _doorOpen = false;
    void Update(){
        if(Door_Outside.active_inside == false){
            gameObject.GetComponent<Collider>().enabled = false;
        } if(Door_Outside.active_inside == true){
            gameObject.GetComponent<Collider>().enabled = true;
        }
        _doorOpen = false;
        if(key_found == true){
            locked = false;
        }
    }
    void OnTriggerEnter(Collider _col){
        canOpenDoor = true;
         if(_col.gameObject.CompareTag("Player")){
             active_outside = false;
        }
        if(_col.gameObject.CompareTag("Player") && locked == true){
             lock_closed.Play();
         }
          if(_col.gameObject.CompareTag("Player") && locked == false){
             _animator.SetTrigger("Inside");
             _doorOpen = true;
             opened.Play();
          }
    }
      void OnTriggerExit(Collider _col){
        canOpenDoor = false;
            lock_closed.Stop();

        if(_col.gameObject.CompareTag("Player")){
            if(_doorOpen == false && locked == false){
              StartCoroutine(repeat());
            }
        }
    }
     IEnumerator repeat()
  {
    yield return new WaitForSeconds (3.0f);
        active_outside = true;
      _animator.SetTrigger("Close2");
        closed.Play();
  }

}
