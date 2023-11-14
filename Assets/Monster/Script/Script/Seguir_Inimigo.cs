using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir_Inimigo : MonoBehaviour
{
    Rigidbody rb;
    private UnityEngine.AI.NavMeshAgent navMesh;
    private GameObject player;
    public static float velocidadeInimigo = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // resumir GetCompon...
        rb.freezeRotation = true; // travar rotacao de personagem ao inserir for�a
    }


    void Update()
    {

         navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh.speed = velocidadeInimigo;

        navMesh.destination = player.transform.position;
        if(Vector3.Distance(transform.position, player.transform.position) < 1.5f);
        {
            navMesh.speed = 0;
            StartCoroutine("ataque");
        }

    }

    IEnumerator ataque()
    {
        yield return new WaitForSeconds(2.8f);
        navMesh.speed = velocidadeInimigo;
    }

}
