using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Transform target;

    [SerializeField]
    private GameObject explosion;

    public LayerMask enemyLayer;
    public Rigidbody2D rb;
    public float angleChangeSpeed;


    private void Start()
    {
        
    }
    void Update()
    {
        if (target == null)
        {
            Debug.Log("No target");
            transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime);

            if(transform.position.y >= 16)
            {
                Destroy(this.gameObject);
            }
        }

        else if (target!= null) // somehow this code works. 
        {
            float distance = Vector3.Distance(transform.position, target.position);
            Vector2 dir = (Vector2)target.position - rb.position;
            float rotAmount = Vector3.Cross(dir, transform.up).z;


            rb.angularVelocity = -angleChangeSpeed * rotAmount;
            rb.velocity = transform.up * _speed;

            if (distance <= 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
              //  Destroy(explosion, 2.0f);
            }
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 11)
        {
            Debug.Log("Theres one!");
            target = other.gameObject.transform;
        }
    }

    // this needs to be changed so that the target is findable after instantiation with a collider. 
    // if more than 1 object is in the collider make sure it only choses the closest one. 
    // only enemies can be targetted with homing missle. 
    //the only way an enemy that dodghes can be hit is with this missle.
    // colliding with an enemy will instantiate the explosion for this which looks different than the one thats been happening.


}
