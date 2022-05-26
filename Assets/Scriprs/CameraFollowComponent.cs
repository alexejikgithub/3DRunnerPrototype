using System;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{
   [SerializeField] private Transform _target;

   [SerializeField] private Vector3 _offset;


   private Vector3 _desiredPosition;

   private void LateUpdate()
   {
      _desiredPosition = new Vector3(transform.position.x, transform.position.y, _target.position.z ) + _offset;
      transform.position = _desiredPosition;
   }
}


