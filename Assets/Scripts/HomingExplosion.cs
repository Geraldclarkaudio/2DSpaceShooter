using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingExplosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.layer == 11)
        {
            Destroy(this.gameObject, 1.5f);
        }
    }
}
