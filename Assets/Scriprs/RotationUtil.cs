using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUtil : MonoBehaviour
{
    [SerializeField] private float _rotatoionSpeed;


    void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotatoionSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
    }


    public void SetRandomRotation()
    {
        transform.eulerAngles= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0,365));
    }
}
