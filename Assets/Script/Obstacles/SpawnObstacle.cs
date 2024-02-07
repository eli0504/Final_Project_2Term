using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private ObstacleController obstacleController;

    public GameObject obstaclePrefab; // Prefab del obstáculo (rueda)
    public Transform targetPoint; // Punto de destino al que se dirigirán las ruedas
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada instanciación de rueda

    private void Start()
    {
        obstacleController = GetComponent<ObstacleController>();
    }

    private void Update()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);    // Invoca repetidamente la función SpawnObstacle con el intervalo especificado

        Spawn();
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>(); //conectar con otro script

        if (obstacleController != null)
        {
            obstacleController.SetTargetPoint(targetPoint.position);  // Establece el punto objetivo al que se dirigirá la rueda
        }
    }
}
