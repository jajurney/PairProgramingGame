using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgramingGame.Enemies
{
    public interface IEnemy
    {
      string Name { get; }
      int Health { get; set; }
      int PointValue { get;  }
      void Weakness(Attack attack);
      Attack Attack();
    }
}
