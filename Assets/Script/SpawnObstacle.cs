using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab del obstáculo (rueda)
    public Transform targetPoint; // Punto de destino al que se dirigirán las ruedas

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();

        if (obstacleRigidbody != null && targetPoint != null)
        {
            // Calculamos la dirección hacia el punto de destino
            Vector3 direction = (targetPoint.position - transform.position).normalized;
            // Aplicamos una fuerza para que ruede hacia el punto de destino
            obstacleRigidbody.AddForce(direction * 500f);
        }
    }
}
