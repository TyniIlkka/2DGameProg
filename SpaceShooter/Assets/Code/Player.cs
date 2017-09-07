using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Player : SpaceshipBase
    {
        Vector3 movementVector = Vector3.zero;

        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";

        private Vector3 GetInputVector()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxis);
            float verticalInput = Input.GetAxis(VerticalAxis);
          
            return new Vector3(horizontalInput, verticalInput);
        }

        protected override void Move()
        {
            Vector3 inputVector = GetInputVector();
            Vector2 movementVector = inputVector * Speed;
            transform.Translate(GetInputVector());
        }

    }
}
