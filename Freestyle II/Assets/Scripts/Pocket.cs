using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{

    private AudioSource audS;

    // Start is called before the first frame update
    void Start()
    {
        audS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Red Ball" || collider.gameObject.tag == "Yellow Ball") {

            audS.Play();

        }

    }

}
