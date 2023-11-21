using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens_Inve1 : MonoBehaviour
{
    public bool selection_confirm = false;
    public static bool item_confirm = false;
    public float speed = 10f;
    void Update()
    {
      if(selection_confirm == true){
        transform.Rotate(0,0,speed*Time.deltaTime);
      } 
    }
    void OnTriggerStay(Collider collider){
        if(collider.gameObject.tag == "Invectory"){
            selection_confirm = true;
            item_confirm = true;
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.CompareTag("Invectory")){
            selection_confirm = false;
            item_confirm = false;
        }
    }
}
