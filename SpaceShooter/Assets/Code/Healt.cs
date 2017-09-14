using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Healt : MonoBehaviour, IHealt
    {
        public int IncreaseHealth()
        {
            return healtAmount;
        }
    }
}
