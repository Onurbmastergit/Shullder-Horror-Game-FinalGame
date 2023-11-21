using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Controls : MonoBehaviour
{
   public GameObject invectory;
   public GameObject player_Main;
   public GameObject hud_Game;
   public GameObject cam_inve;
   public GameObject monster;
   public bool inve_on = false;
   public static bool inve_screen = false;

   void Update(){
    if(Input.GetKeyDown(KeyCode.I)){
        inve_on =! inve_on;
    }
    if(inve_on == false){
        invectory.SetActive(inve_on);
        cam_inve.SetActive(inve_on);
        player_Main.SetActive(!inve_on);
        hud_Game.SetActive(!inve_on);
        monster.SetActive(!inve_on);
        inve_screen = inve_on;
    }
    if(inve_on == true){
        invectory.SetActive(inve_on);
        cam_inve.SetActive(inve_on);
        player_Main.SetActive(!inve_on);
        hud_Game.SetActive(!inve_on);
        monster.SetActive(!inve_on);
        inve_screen = inve_on;
    }
   }
}
