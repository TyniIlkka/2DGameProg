using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public interface IHealt
    {
        int CurrenHealt { get; }

        void IncreaseHealt(int amount);

        void DegcreaseHealt(int amount);


    }
}
