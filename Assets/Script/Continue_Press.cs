using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue_Press : MonoBehaviour
{
    public string scenename;
     void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R)){
        SceneManager.LoadScene(scenename);
        }
    }
}
