﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {

    public class EnemySpaceShip : SpaceShipBase
    {
        [SerializeField]
        private float _reachDistance = 0.5f;

        private GameObject[] _movementTargets;
        private int _currentMovementTargetIndex = 0;

        public Transform CurrentMovementTarget
        {
            get
            {
                return _movementTargets[_currentMovementTargetIndex].transform;
            }
        }

        public void SetMovementTargets(GameObject[] movementTargets)
        {
            _movementTargets = movementTargets;
            _currentMovementTargetIndex = 0;
        }
        protected override void Move()
        {
            if(_movementTargets == null || _movementTargets.Length == 0)
            {
                return;
            }

            UpdateMovementTarget();
            Vector3 direction = (CurrentMovementTarget.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);

        }

        private void UpdateMovementTarget()
        {
            if ( Vector3.Distance( transform.position,
                CurrentMovementTarget.position)< _reachDistance)
            {
                if(_currentMovementTargetIndex >= _movementTargets.Length -1)
                {
                    _currentMovementTargetIndex = 0;
                }
                else
                {
                    _currentMovementTargetIndex++;
                }
            }
        }

        protected override void Update()
        {
            base.Update();

            Debug.DrawLine(transform.position, CurrentMovementTarget.position, Color.green);
        }
    }
}
