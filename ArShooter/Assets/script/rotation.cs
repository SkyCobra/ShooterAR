using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
        public float moveSpeed = 100f;
        public GameObject centre;

        private float movement = 0f;

        void Update()
        {
            {
                transform.RotateAround(Vector3.zero, Vector3.down, moveSpeed * Time.deltaTime);
            }
        }
}
