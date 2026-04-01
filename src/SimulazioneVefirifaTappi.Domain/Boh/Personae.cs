using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulazioneVefirifaTappi.Domain.Boh
{
    public class Personae
    {

        public List<AttackTypes> Resistances { get; private set; }
        public List<AttackTypes> Immunities { get; private set; }
        public List<AttackTypes> Reflections { get; private set; }
        public List<AttackTypes> Absortions { get; private set; }
        public List<AttackTypes> Weakneasses { get; private set; }
        public List<Move> Moves { get; private set; }

        public int STR { get; private set; }
        public int MAG { get; private set; }
        public int AGI { get; private set; }
        public int END { get; private set; }
        public int LUCK { get; private set; }
        public int Hp { get; private set; }
        public int Sp { get; private set; }
        private int BaseElusion { get; set; }

        public Personae(List<AttackTypes> res, List<AttackTypes> imn, List<AttackTypes> refl, List<AttackTypes> abs, List<AttackTypes> weak, List<Move> moves, int hp, int sp, int str, int mag, int agi, int end, int luck)
        {
            Resistances = res;
            Immunities = imn;
            Reflections = refl;
            Absortions = abs;
            Weakneasses = weak;
            Moves = moves;
            Hp = hp;
            Sp = sp;
            STR = str;
            MAG = mag;
            AGI = agi;
            END = end;
            LUCK = luck;
        }

        public int Attack(Move selectedmove, Personae target)
        {
            int damage;
            if (CheckHit(target, selectedmove))
            {

                if (selectedmove.Type == AttackTypes.Gun || selectedmove.Type == AttackTypes.Melee)
                {
                    damage = selectedmove.BasePower * STR;
                }
                else
                    damage = selectedmove.BasePower * MAG;

                return damage;
            }
            else
                throw new ArgumentException("Move did not hit");
        }

        private void InflictPureDamage(Personae target, int damage)
        {
            target.Hp -= damage;
        }

        private bool CheckHit(Personae target, Move selectedmove)
        {
            int moveprecision = selectedmove.Precision * AGI;
            int targetelusion = target.BaseElusion * target.AGI;

            return moveprecision > targetelusion;
        }

        public void TakeDamage(int damage, Move move, Personae attacker)
        {
            AttackTypes type = move.Type;

            if (Resistances.Contains(type))
                Hp -= damage / 2;
            else if (Immunities.Contains(type))
                Hp -= damage * 0;
            else if (Reflections.Contains(type))
                InflictPureDamage(attacker, damage);
            else if (Absortions.Contains(type))
                Hp += damage;
            else if (Weakneasses.Contains(type))
                Hp -= damage * 2;
            else
                Hp -= damage;               
        }
    }
}
