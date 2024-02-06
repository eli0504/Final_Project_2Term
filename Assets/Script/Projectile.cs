using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject shootProjectile;
    public float launchVelocity = 1000f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject axe = Instantiate(shootProjectile, transform.position, transform.rotation);
            axe.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }
    }
}
