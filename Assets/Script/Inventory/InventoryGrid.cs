using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public GameObject[] items;
    public GameObject grid;

    private void Awake()
    {
        /*
        grid.SetActive(false);

        if (Input.GetKeyDown(KeyCode.I))
        {
            grid.SetActive(true);
        }
        */
    }

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
                items[i].SetActive(true);

            if (Input.GetKeyDown(KeyCode.O))
            {
                items[i].SetActive(false);
            }
        }
    }

}
