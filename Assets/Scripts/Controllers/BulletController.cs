using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float bulletSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //getting a reference to the hitableObject
        var hitted = other.GetComponent<HitableObject>();
        //if the object is hitted
        if(hitted != null){
            hitted.DetectHit();
            Destroy(gameObject);
        }

        if(other.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
