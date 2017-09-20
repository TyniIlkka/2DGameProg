﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private Spawner _enemySpawner;

        [SerializeField]
        private GameObject[] _enemyMovementTargets;

        protected void Awake()
        {
            if(_enemySpawner == null)
            {
                Debug.Log("No reference to a enemy spawner.");
                //_enemySpawner = GameObject.FindObjectOfType<Spawner>();
                _enemySpawner = GetComponentInChildren<Spawner>();

            //    Transform childTransform = transform.Find("EnemySpawner");
            //    if(childTransform != null)
            //    {

            //    }
            //  _enemySpawner = transform.Find("EnemySpawner").gameObject.GetComponent<Spawner>();
            }

            SpawnEnemyUnit();
        }

        private EnemySpaceShip SpawnEnemyUnit()
        {
            GameObject spawnedEnemyObject = _enemySpawner.Spawn();
            EnemySpaceShip enemyShip = spawnedEnemyObject.GetComponent<EnemySpaceShip>();
            if(enemyShip != null)
            {
                enemyShip.SetMovementTargets(_enemyMovementTargets);
            }
            return enemyShip;
        }
    }
}
