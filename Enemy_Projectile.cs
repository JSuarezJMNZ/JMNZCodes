using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileShoot : MonoBehaviour
{

    // timer
    [SerializeField] float startTime;
    float currentTime;

    // prefab to file
    [SerializeField] GameObject projectilePrefab;

    // Damage
    [SerializeField] float damage;

    // speed
    [SerializeField] float projectileVelocity;
    // shoot point
    [SerializeField] Transform shootpoint;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            // shoot projectile
            var projectile = Instantiate(projectilePrefab, shootpoint.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileVelocity;

            // reset currenttime
            currentTime = startTime;
        }
    }
}