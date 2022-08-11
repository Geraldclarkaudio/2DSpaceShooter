using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemy : MonoBehaviour
{
    public int health;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private int rotSpeed;
    [SerializeField]
    private float rayLength;
    Vector3 currentEulerAngles;
    [SerializeField]
    private GameObject rayEndPos;
    public GameObject explodePrefab;

    public bool rotateNormal = true;

    public bool atSentryPos = false;
    private SpriteRenderer _renderer;

    private Animator anim;

    private void Awake()
    {
        health = 3;
    }
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(explodePrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


        if (atSentryPos == true)
        {
            return;
        }
        else if(atSentryPos == false)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);

        if(transform.position.y <= -14f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PatrolZone"))
        {
            anim.SetBool("Rot", true);
            atSentryPos = true;
            StartCoroutine(Patrol());
        }

        if(other.CompareTag("Laser"))
        {
            StartCoroutine(HitVisual());
            health--;
        }

        if(other.CompareTag("Missle"))
        {
            health = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PatrolZone"))
        {
            anim.SetBool("Rot", false);
            atSentryPos = false;
        }
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(12.0f);

        atSentryPos = false;
    }

    IEnumerator HitVisual()
    {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
    }
}
