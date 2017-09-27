﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public interface IHealth
    {
        int CurrentHealth { get; }

        void IncreaseHealth(int amount);

        void DegcreaseHealth(int amount);


    }
}