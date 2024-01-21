using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    private float speed = 4;
    //private Rigidbody _rigidbody;
    public GameObject player;

    private void Awake()
    {
       // _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized; //cálculo de la dirección enemigo -> player

       // _rigidbody.AddForce(direction * speed); //se aplica una fuerza sobre el rigidbody del enemigo hacia el player a la misma velocidad
    }
}
