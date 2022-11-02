using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

    // Variables

    public GameObject BulletPrefab;

    private float move_speed = 0.1f;

    private int max_cooldown = 25;

    private int cooldown = 0;

    private float bullet_speed = 10f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {

        MoveShip();
        FireControl();
        checkForEnd();

    }


    void MoveShip()
    {

        Vector3 pos = transform.position;

        if ((Input.GetKey("right")) && (Input.GetKey("left")))
        {
            // Do nothing if both arrows are held  
        }

        else if (Input.GetKey("right"))
        {
            pos.x += move_speed;
            transform.position = pos;
        }
        else if (Input.GetKey("left"))
        {
            pos.x -= move_speed;
            transform.position = pos;
        }
    }


    void FireControl()
    {

        if (cooldown == 0 && Input.GetKey("space"))
        {
            Fire();
            cooldown = max_cooldown;
        } else
        {
            if (cooldown > 0) {
                cooldown -= 1;
            }
        }


    }

        void Fire()
    {
        Vector3 bullet_spawn = transform.position + 0.5f * transform.up;
        GameObject bullet = Instantiate(BulletPrefab, bullet_spawn, Quaternion.identity);
        Rigidbody2D bullet_rig = (Rigidbody2D)bullet.GetComponent<Rigidbody2D>();
        bullet_rig.velocity = bullet_speed * transform.up;
    }

    void checkForEnd()
    {
        // Check for end
        GameObject enemies = GameObject.Find("Enemies");
        BoxCollider2D[] colliders = enemies.GetComponentsInChildren<BoxCollider2D>();

        if (colliders.Length == 0)
        {
            Enemy.spawnNewWave();
        }
    }

    void OnBecameInvisible()
    {
        // Reset if off screen
        Vector3 pos = transform.position;
        pos.x = 0;
        transform.position = pos;

    }

}
