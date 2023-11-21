using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moviment_Cam_Inve : MonoBehaviour
{
    public RawImage confirm ;
    public RawImage not_confirm;
    public float moviment_left = -3f;
    public float moviment_right = 3f;
    float x_maximus = 3.13f;
    float x_minums = -3.21f;
    bool moviment_on_right = true;
     bool moviment_on_left = true;
    void Update()
    {
        Vector3 position = transform.position;
        if(x_maximus < position.x){
            moviment_on_right = false;
        }else{
            moviment_on_right = true;
        }
         if(x_minums > position.x){
            moviment_on_left = false;
        }else{
            moviment_on_left = true;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow) && moviment_on_left == true){
            transform.Translate(moviment_right*Time.deltaTime,0,0);
        }
         if(Input.GetKey(KeyCode.RightArrow) && moviment_on_right == true){
            transform.Translate(moviment_left*Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.P) &&  Itens_Inve.item_confirm == true){
            confirm.GetComponent<RawImage>().enabled = true;
             not_confirm.GetComponent<RawImage>().enabled = false;
        }

    }
}
