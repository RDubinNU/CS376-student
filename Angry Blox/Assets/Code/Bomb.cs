using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    void Destruct()
    {
        Destroy(this.gameObject);
    }

    void Boom()
    {
        // Turn on point effector
        PointEffector2D pe = GetComponent<PointEffector2D>();
        pe.enabled = true;

        // Turn off sprite renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;

        // Run animation
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > ThresholdForce)
        {
            Boom();
        }
    }

}


