using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Outside : MonoBehaviour
{   
    public static bool active_inside = true;
    public AudioSource lock_closed;
    public AudioSource opened;
    public AudioSource closed;
    public static bool key_found = false;    
    public bool locked = false;
    public RawImage icon;
    public Animator _animator;
    private bool _doorOpen = false;
   
    void Update(){
        
        if(Door_Inside.active_outside == false){
            gameObject.GetComponent<Collider>().enabled = false;
        } if(Door_Inside.active_outside == true){
            gameObject.GetComponent<Collider>().enabled = true;
        }
        _doorOpen = false;
        if(key_found == true){
            locked = false;
        }


    }
    void OnTriggerEnter(Collider _col){
         if(_col.gameObject.CompareTag("Player")){
            active_inside = false;
        
         }
        if(_col.gameObject.CompareTag("Player") && locked == true){
            lock_closed.Play();
        }
         if(_col.gameObject.CompareTag("Player") && locked == false  ){
            _animator.SetTrigger("Outside");
            _doorOpen = true;
            opened.Play();
         }
    }
      void OnTriggerExit(Collider _col){
         lock_closed.Stop();

        if(_col.gameObject.CompareTag("Player")){
            if(_doorOpen == false && locked == false){
              StartCoroutine(repeat());
            }
        }
    }
     IEnumerator repeat()
  {
    yield return new WaitForSeconds (2.0f);
        active_inside = true;
      _animator.SetTrigger("Close");
      closed.Play();
  }

}
