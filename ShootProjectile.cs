using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public KeyCode shootButton;
    public float projectileDamage;
    public float projectileVelocity;
    // check for ammo
    public GameObject projectilePrefab;
    public Transform shootpoint;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {

            var projectile = Instantiate(projectilePrefab, shootpoint.position,
 transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right *
 projectileVelocity;
        }
    }
}
