using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class SpaceShipBase : MonoBehaviour
    {
        // Backing field for the property Speed.
        // SerializeField attribute forces Unity to serialize this variable
        // in order to make it editable inside the editor.
        [SerializeField]
        private float _speed = 1.5f;

        private Weapon[] _weapons;
        private Projectile _damage;
        private Health _health;

        public float Speed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }

        public Weapon[] Weapons
        {
            get { return _weapons; }
        }

        protected virtual void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>(includeInactive: true);
        }

        protected void Shoot()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.Shoot();
            }
        }

        protected abstract void Move();

        protected virtual void Update()
        {
            try
            {
                Move();
            }
            catch (System.NotImplementedException exception)
            {
                Debug.Log(exception.Message);
            }
            catch (System.Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        //When Spaceships collide with something they take famage
        void OnTriggerEnter2D(Collider2D collision)
        {

            // if Collision with game object = true: take damage
            if (collision.gameObject)
            {
                //Getting damage from Projectile doesn't work and don't know was it requirements
                _damage = GetComponent<Projectile>();//Damage that is done to the ships
                _health = GetComponent<Health>();   //Current Healt of the ship that is collided

                //Debuggin the value of the _damage
                Debug.Log(_damage);

                //check if _health is null or not
                if (_health != null)
                {
                    //Decreases health amount of damage
                    _health.DegcreaseHealth(30); // Change the value to _damage variable when you get things to work.
                }

                //Destroy projectiles when you hit the enemyship and player if collides with enemy
                //Destroy(collision.gameObject);
            }
        }
    }
}