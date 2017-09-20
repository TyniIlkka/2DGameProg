using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public interface IHealth
    {
        int CurrentHealt { get; }

        void IncreaseHealt(int amount);

        void DegcreaseHealt(int amount);


    }
}