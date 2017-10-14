using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour, IDamageProvider
    {

        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _speed;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private bool _islaunched = false;
        private Weapon _weapon;
        private AudioSource _audio;


        protected void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _rigidbody = GetComponent<Rigidbody2D>();

            if (_rigidbody == null)
            {
                Debug.LogError("No Rigidbody2D component was found from the GameObject!");
            }
        }

        protected void FixedUpdate()
        {
            if (!_islaunched)
            {
                return;
            }

            Vector2 velocity = _direction * _speed;
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + velocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);

        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            IDamageReceiver damageReceiver = other.GetComponent<IDamageReceiver>();
            if(damageReceiver != null)
            {
                Debug.Log("Damage taken!");
                damageReceiver.TakeDamage(GetDamage());
                //ToDo Return projectile back to pool.
                throw new System.NotImplementedException("Return projectile to the pool");   
                //Destroy(gameObject);
            }
            if(_weapon.DisposeProjectile(this) == false)
            {
                Debug.LogError("Could no return the projectile back to the pool.");
                Destroy(gameObject);
            }
        }


        public void Launch(Weapon weapon, Vector2 direction)
        {
            _weapon = weapon;
            _direction = direction;
            _islaunched = true;

            _audio.PlayOneShot(_audio.clip, 1);
        }

        public int GetDamage()
            {
            return _damage;
        }

        public void OnHit(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.DegcreaseHealth(20);
                Destroy(collision.gameObject);
            }
        }
    }
}
