using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{

    // Fields
    private float propulsionControl = 1000f;
    private Rigidbody2D rig_bod;
    private bool breaking = true;
    private AudioSource audS;

    // Start is called before the first frame update
    void Start()
    {
        rig_bod = GetComponent<Rigidbody2D>();
        audS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Cue")
        {
            // Shift off breaking power if break
            if (breaking)
            {
                breaking = false;
                propulsionControl = 40f;
            }


            // Play cue sound
            Debug.Log("test");
            audS.Play();


            Vector3 objectPos = transform.position;
            Vector3 propPoint = collider.GetContact(0).point;

            Vector3 propVec = objectPos - propPoint;

            Vector3 propVel = propVec * propulsionControl;

            rig_bod.velocity = propVel;
        }

    }
}
