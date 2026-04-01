using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulazioneVefirifaTappi.Domain.Boh
{
    public class Move
    {
        public AttackTypes Type { get; private set; }
        public int BasePower { get; init; }
        public int Precision { get; init; }

        public Move(int power, int precision)
        {
            BasePower = power;
            Precision = precision;
        }
    }
}
