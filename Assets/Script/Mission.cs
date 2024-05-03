using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Mission : MonoBehaviour
{
   public TextMeshProUGUI textoTela;
    public TextMeshProUGUI textoTela2;
   public GameObject document;
   public GameObject key;
   public GameObject monster;

    bool mission_take_documents = false;

    public static bool enter_hospital = true; 

   public static int documents_take = 0;
    int documents_objt = 5;

    public static int key_founds = 0;

    int key_obj = 1;

    bool hud_mission = true;
    public static bool enter_on = false;

    public static bool key_found1 = false;
    bool key_mission = false;
    public static bool final_part = false;

    void Update(){ 
        if(documents_take < 3 && Display_Controls.inve_screen == false){
            monster.SetActive(false);
        }
        if(documents_take > 3 && Display_Controls.inve_screen == false){
            monster.SetActive(true);
        }

        if(enter_hospital == true){
            textoTela.text = "<b>Investigue o Hospício<b>";
             textoTela2.text = "<b>Investigue o Hospício<b>";
        }
        if(enter_on == true){
            mission_take_documents = true;
            enter_hospital = false;
        }

        if(Input.GetKeyDown(KeyCode.T)){
           hud_mission  =!hud_mission;
        }

         if( mission_take_documents == true){
            key.SetActive(false);
            textoTela.text = "<b>Descubra a Historia do Hospício<b>\n"+documents_take+"/"+documents_objt;
            textoTela2.text = "<b>Descubra a Historia do Hospício<b>\n"+documents_take+"/"+documents_objt;
            if(documents_take >= documents_objt){
                mission_take_documents = false;
                key.SetActive(true);
                key_mission = true;
            }
        }
        if(key_founds >= key_obj){
            key_mission = false;
            final_part = true;
        }

        if(key_mission == true){
          textoTela.text = "<b>Ache a chave da sala do altar<b>\n"+key_founds+"/"+key_obj;
          textoTela2.text = "<b>Ache a chave da sala do altar<b>\n"+key_founds+"/"+key_obj;
          
        }
        if(final_part == true){
          textoTela.text = "<b>Ache a Boneca e saia do Hospício<b>";
           textoTela2.text = "<b>Ache a Boneca e saia do Hospício<b>";
          EscapeCar.car_coll = true;
        }

    textoTela.GetComponent<TextMeshProUGUI>().enabled = hud_mission;
    }

  
}
