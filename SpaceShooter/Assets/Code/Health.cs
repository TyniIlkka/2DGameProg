using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour, IHealth

    {
        //Collect every needed information
        [SerializeField]
        private int currentHealth;
        [SerializeField]
        private int startingHealth;
        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private int minHealth;

        int IHealth.CurrentHealth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Awake()
        {
            currentHealth = startingHealth;
        }

        // Increase SpaceShips/EnemyShips health
        void IHealth.IncreaseHealth(int amount)
        {
            currentHealth += amount;

            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            Debug.Log(currentHealth);
            
        }

        // Degcrease SpaceShips/EnemyShips health
        public void DegcreaseHealth(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= minHealth)
            {
                currentHealth = minHealth;
            }

            Debug.Log(currentHealth);
        }
    }
}