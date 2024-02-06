using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    public GameObject trap;

    private float startDelay = 1.5f;
    private float spawnInterval = 2f;

    private void Update()
    {
        SpawnWheel();
    }

    private void Start()
    {
        InvokeRepeating("spikeWheel", startDelay, spawnInterval);  //llama peri�dicamente a la funci�n SpawnRandomAnimal
    }

    private void SpawnWheel()
    {
        Instantiate(trap, new Vector3(103, 3, 0), Quaternion.identity);
    }
}
