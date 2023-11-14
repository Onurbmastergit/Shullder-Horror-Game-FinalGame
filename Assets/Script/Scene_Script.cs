using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Script : MonoBehaviour
{   
    public string scenename;

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(repeat()); 
    }

     IEnumerator repeat()
  {
    yield return new WaitForSeconds (2.0f);
    SceneManager.LoadScene(scenename);
        
  }
}
