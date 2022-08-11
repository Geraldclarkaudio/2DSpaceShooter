using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpBGRotate : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;
    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
