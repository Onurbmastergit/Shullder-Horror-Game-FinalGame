using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Read_Notes : MonoBehaviour
{
   public GameObject document_1;
   public GameObject document_2;
   public GameObject document_3;
   public GameObject document_4;
   public GameObject document_5;
   public AudioSource paper;
   bool show_me1 = false;
   bool show_me2 = false;
   bool show_me3 = false;
   bool show_me4 = false;
   bool show_me5 = false;
   bool take_document1 = false;
   bool take_document2 = false;
   bool take_document3 = false;
   bool take_document4 = false;
   bool take_document5 = false;
    
    void Update()
    {
     if(Mission.documents_take == 1){
        take_document1 = true;
     }
     if(Mission.documents_take == 2){
        take_document2 = true;
     }
     if(Mission.documents_take == 3){
        take_document3 = true;
     }
     if(Mission.documents_take == 4){
        take_document4 = true;
     }
     if(Mission.documents_take == 5){
        take_document5 = true;
     }   
     if(Input.GetKeyDown(KeyCode.F1)
     && take_document1 == true){
       show_me1 =!show_me1;
        show_me2 = false;
        show_me3 = false;
        show_me4 = false;
        show_me5 = false;
       paper.Play();
       }
    if(Input.GetKeyDown(KeyCode.F2)
    && take_document2 == true){
       show_me2 =!show_me2;
       show_me1 = false;
        show_me3 = false;
        show_me4 = false;
        show_me5 = false;
       paper.Play();
       }
    if(Input.GetKeyDown(KeyCode.F3)
    && take_document3 == true){
       show_me3 =!show_me3;
       show_me1 = false;
        show_me2 = false;
        show_me4 = false;
        show_me5 = false;
       paper.Play();
       }
    if(Input.GetKeyDown(KeyCode.F4)
    && take_document4 == true){
       show_me4 =!show_me4;
       show_me1 = false;
        show_me2 = false;
        show_me3 = false;
        show_me5 = false;
       paper.Play();
       }
    if(Input.GetKeyDown(KeyCode.F5)
    && take_document5 == true){
       show_me5 =!show_me5;
       show_me2 = false;
        show_me3 = false;
        show_me4 = false;
        show_me1 = false;
       paper.Play();
       }             
      document_1.GetComponent<RawImage>().enabled = show_me1;
      document_2.GetComponent<RawImage>().enabled = show_me2;
      document_3.GetComponent<RawImage>().enabled = show_me3;
      document_4.GetComponent<RawImage>().enabled = show_me4;
      document_5.GetComponent<RawImage>().enabled = show_me5;  
    }
}
