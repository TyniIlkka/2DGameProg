using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Destoyer : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    

    }
}
