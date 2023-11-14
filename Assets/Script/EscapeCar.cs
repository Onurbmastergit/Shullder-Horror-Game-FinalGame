using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EscapeCar : MonoBehaviour
{
    public string scenename;
   public static bool car_coll = false;

   void Update()
   {
    if(car_coll == false){
       gameObject.GetComponent<Collider>().enabled = car_coll;
    }
    if(car_coll == true){
        gameObject.GetComponent<Collider>().enabled = car_coll;
    }
   }
   void OnTriggerEnter(Collider collider)
   {
    if(collider.CompareTag("Player")){
        StartCoroutine(repeat());
    }
   }
    IEnumerator repeat()
  {
    yield return new WaitForSeconds (1.0f);
    SceneManager.LoadScene(scenename);
        
  }
}
