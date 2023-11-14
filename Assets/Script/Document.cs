using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour
{
    public GameObject document;
    public AudioSource documentPickup;
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            documentPickup.Play();
            Mission.documents_take ++ ;
            Seguir_Inimigo.velocidadeInimigo = +3;
           document.SetActive(false);
        }
        
    }
}
