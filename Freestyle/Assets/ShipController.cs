using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

    // Variables

    public GameObject BulletPrefab;

    private float move_speed = 0.1f;

    private int max_cooldown = 1000;

    private int cooldown = 0;

    private float bullet_speed = 0.1f;



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
            Debug.Log("Test");
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
        Vector3 bullet_spawn = transform.position + 1.5f * transform.up;
        GameObject bullet = Instantiate(BulletPrefab, bullet_spawn, Quaternion.identity);
        Rigidbody2D bullet_rig = (Rigidbody2D)bullet.GetComponent<Rigidbody2D>();
        bullet_rig.velocity = bullet_speed * transform.up;
    }
}
