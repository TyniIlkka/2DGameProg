using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public interface IDamageProvider
    {
        int GetDamage { get; }
    }
}
