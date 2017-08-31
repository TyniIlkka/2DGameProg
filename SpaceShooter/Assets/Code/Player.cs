using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {

        public float speed = 1f;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(GetMovementVector());
        }

        private Vector3 GetMovementVector()
        {
            Vector3 movementVector = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftArrow)){
                movementVector += Vector3.left;
            }

            if (Input.GetKey(KeyCode.RightArrow)){
                movementVector += Vector3.right;
            }

            if (Input.GetKey(KeyCode.UpArrow)){
                movementVector += Vector3.up;
            }

            if (Input.GetKey(KeyCode.DownArrow)){
                movementVector += Vector3.down;
            }

            movementVector = movementVector * Time.deltaTime * speed;
            return movementVector;
        }
    }
}
