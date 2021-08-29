using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    

      [SerializeField]
      private float speed = 6.0F;

      [SerializeField]
      private Transform target;

      private void Awake()
      {
          if (!target) target = FindObjectOfType<mainhero>().transform;
      }

      private void Update()
      {
          Vector3 position = target.position; position.y = 0.1f; position.z = -8.0F;
          transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
      } 
}

