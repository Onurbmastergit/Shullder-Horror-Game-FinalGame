using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void exitGame(){
        if(Input.GetKeyDown(KeyCode.Escape)){
             Application.Quit();
        }
       
    }
    void Update()
    {
       exitGame(); 
    }
}
