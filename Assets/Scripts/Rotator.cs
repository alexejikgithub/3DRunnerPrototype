using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotatoionSpeed;


        private void Awake()
        {
            SetRandomRotation();
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, 0, _rotatoionSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
        }


        public void SetRandomRotation()
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, Random.Range(0, 365));
            transform.eulerAngles = eulerAngles;
        }
    }
}