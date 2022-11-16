using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue: MonoBehaviour
{

    // Fields
    private bool shooting = false;
    private Vector3 offscreenPos = new Vector3(100, 100, 100);
    private Rigidbody2D rig_bod;

    // Start is called before the first frame update
    void Start()
    {
        rig_bod = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        if (shooting == true) {

            Vector3 previousPos = transform.position;

            // Postion Update
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0.1f;
            transform.position = worldMousePos;

            // Velocity Update
            rig_bod.velocity = transform.position - previousPos;

        } else
        {
            if (readyToShoot())
            {
                // Update cue ball colour through signal

                // Pick up cue on click
                if (Input.GetMouseButtonDown(0))
                {
                    shooting = true;
                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        shooting = false;
        transform.position = offscreenPos;
    }


    bool readyToShoot()
    {

        GameObject ballHolder = GameObject.Find("Balls");
        Rigidbody2D[] ballsRigs = ballHolder.GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D ball in ballsRigs)
        {
            if (ball.velocity.magnitude > 0.1) {
                return false;
            }
        }

        return true;

    }

}
