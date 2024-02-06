using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject potionIttem;
    public float launchVelocity = 1000f;
    public Transform Parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject potion = Instantiate(potionIttem, Parent);
            potion.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }
    }
}
