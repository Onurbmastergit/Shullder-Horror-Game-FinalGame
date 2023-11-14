using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_System : MonoBehaviour
{
    public RawImage chat1;

    void Update()
    {

    }

    void Chat(){

    }
    IEnumerator repeat(){
       yield return new WaitForSeconds (30.0f);
    }

}
