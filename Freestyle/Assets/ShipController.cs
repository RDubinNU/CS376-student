using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

    // Variables

    public Transform tf;

    private float move_speed = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        tf = (Transform)GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {

        MoveShip();


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
            tf.position = pos;
        }
        else if (Input.GetKey("left"))
        {
            pos.x -= move_speed;
            tf.position = pos;
        }
    }
}
