using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour, IHealth

    {
        //Collect every needed information
        [SerializeField] private int startingHealth;        
        [SerializeField] private int maxHealth;
        [SerializeField] private int minHealth;

        [SerializeField] private int currentHealth;

        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            private set
            {
                currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
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
            Debug.Log(currentHealth);            
        }

        public bool IsDead
        {
            get { return CurrentHealth == minHealth; }
        }

        // Degcrease SpaceShips/EnemyShips health
        public void DegcreaseHealth(int amount)
        {
            currentHealth -= amount;
            if(currentHealth <= minHealth)
            {
                currentHealth = minHealth;
            }
            Debug.Log(currentHealth);
        }
    }
}