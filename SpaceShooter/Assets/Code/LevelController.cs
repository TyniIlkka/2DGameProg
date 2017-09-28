using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private GameObject[] _enemyMovementTargets;
        [SerializeField] private float _spawnInterval = 1;
        [SerializeField] private int _maxEnemyOnField;
        [SerializeField, Tooltip("The wait time to first spawn.")] private float _waitToSpawn;
        private int _enemyCount;

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
        }

        protected void Start()
        {
            StartCoroutine(SpawnRoutine());
        }
        private IEnumerator SpawnRoutine()
        {
            yield return new WaitForSeconds(_waitToSpawn);
            while(_enemyCount < _maxEnemyOnField)
            {
                EnemySpaceShip enemy = SpawnEnemyUnit();
                if(enemy != null)
                {
                    _enemyCount++;
                }else
                {
                    Debug.LogError("Could not spawn an enemy!");
                    yield break;
                }
                yield return new WaitForSeconds(_spawnInterval);
            }
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
