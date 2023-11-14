using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Player : MonoBehaviour
{
       public string scenename;

    void OnTriggerEnter (Collider collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(scenename);
        }
    }
}
