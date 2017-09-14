using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public interface Healt
    {
        int CurrenHealt { get; }

        void IncreaseHealt(int amount);

        void DegcreaseHealt(int amount);


    }
}
