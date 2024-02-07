using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private SpawnObstacle spawnObstacle;

    private Vector3 targetPoint;
    public float speed = 5f;

    private void Start()
    {
        spawnObstacle = FindObjectOfType<SpawnObstacle>();
    }

    public void SetTargetPoint(Vector3 target)
    {
        targetPoint = target;
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        /*
        if (transform.position == targetPoint)
        {
            spawnObstacle.Destroy(obstaclePrefab);
        }*/
    }
}
