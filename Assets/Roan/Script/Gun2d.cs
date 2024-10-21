using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2d : MonoBehaviour
{
    public Transform bulletSpawnPoint;   
    public GameObject bulletPreFab;      
    public float bulletSpeed = 10f;      
    public float maxBulletDistance = 10f; 
    public float shotDelay = 5f;         

    private int bulletCount;             
    private bool canShoot = true;        
    private float lastShotTime = 0f;

    private Rigidbody2D rb2d;


    void Start()
    {
        
        bulletCount = Random.Range(1, 11);
        Debug.Log("Bullet count for this gun: " + bulletCount);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && bulletCount > 0)
        {
            Shoot();
        }

        
        if (!canShoot && Time.time - lastShotTime >= shotDelay)
        {
            canShoot = true;
        }
        // Flips sprite
        if (rb2d.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Shoot()
    {
        
        bulletCount--;

       
        var bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        
        var rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = bulletSpawnPoint.up * bulletSpeed;

          
            Bullet bulletScript = bullet.AddComponent<Bullet>();
            bulletScript.maxDistance = maxBulletDistance;
        }

        
        canShoot = false;
        lastShotTime = Time.time;

       
        if (bulletCount <= 0)
        {
            Debug.Log("No bullets left!");
        }
    }
}
