using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Start : MonoBehaviour
{
    public string scenename;
    public Animator cam;
    public GameObject starts;
    public GameObject ghost;
    public GameObject imagem;
    public AudioSource confirm_sound;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
             cam.SetTrigger("Starts");
             StartCoroutine(repeat());
             starts.SetActive(false);
             imagem.SetActive(false);
             ghost.SetActive(true);
             sound1.Stop();
             sound2.Stop();
             sound3.Stop();
             confirm_sound.Play();
        }
    }

   IEnumerator repeat()
  {
    yield return new WaitForSeconds (2.0f);
    SceneManager.LoadScene(scenename);
        
  }
}
