using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Projectile : MonoBehaviour, IDamageProvider
    {

        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _speed;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private bool _islaunched = false;

        //Trying to get damage work from projectile
        int IDamageProvider.GetDamage
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        protected void Awake()
        {
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
        

        public void Launch(Vector2 direction)
        {
            _direction = direction;
            _islaunched = true; 
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

            }
        }
    }
}
