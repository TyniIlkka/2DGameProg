using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour
    {

        [SerializeField]
        private int currentHealth;
        [SerializeField]
        private int startingHealth;
        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private int minHealth;

        public void Awake()
        {
            currentHealth = startingHealth;
        }

        public void IncreaseHealt(int amount)
        {
            currentHealth += amount;

            if(currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void DegcreaseHealt(int amount)
        {
            currentHealth -= amount;

            if(currentHealth <= minHealth)
            {
                currentHealth = minHealth;
            }
            
        }
    }
}
