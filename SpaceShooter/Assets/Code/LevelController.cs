using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelController : MonoBehaviour      
    {
        public static LevelController Current
        {
            get; private set;
        }

        [SerializeField] private GameObjectPool _playerProjectilePool;
        [SerializeField] private GameObjectPool _enemyProjectilePool;
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private GameObject[] _enemyMovementTargets;
        [SerializeField] private float _spawnInterval = 1;
        [SerializeField] private int _maxEnemyOnField;
        [SerializeField, Tooltip("The wait time to first spawn.")] private float _waitToSpawn;
        private int _enemyCount;

        protected void Awake()
        {
            if (Current == null)
            {
                Current = this;
            }
            else
            {

            }


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

        public Projectile GetProjectile(SpaceShipBase.Type type)
        {
            GameObject result = null;
            if(type == SpaceShipBase.Type.Player)
            {
                result = _playerProjectilePool.GetPooledObject();
            }
            else
            {
                result = _enemyProjectilePool.GetPooledObject();
            } 

            if(result != null)
            {
                return result.GetComponent<Projectile>();
            }

            return null;
        }

        public bool ReturnProjectile(SpaceShipBase.Type type, Projectile projectile)
        {
            if(type == SpaceShipBase.Type.Player)
            {
                return _playerProjectilePool.ReturnObject(projectile.gameObject);
            }
            else
            {
                return _enemyProjectilePool.ReturnObject(projectile.gameObject);
            }
        }
    }
}
