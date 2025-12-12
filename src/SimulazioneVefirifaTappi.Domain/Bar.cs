using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulazioneVefirifaTappi.Domain
{
    public class Bar
    {
        public string Name { get; private set; }
        public List<Party> Parties { get; private set; }

        public Bar(string name)
        {
            Name = name;
            Parties = new List<Party>();
        }

        public void AddEvent(string name, double cost, DateOnly date, Tags[] tags)
        {
            if (cost < 0.0)
                throw new ArgumentException("cost cannot be negative");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is not valid");

            if (tags == null)
                throw new ArgumentException("the list of tags given is not valid");

            Parties.Add(new Party(name, cost, date, tags));
        }

        public Party PriciestEvent()
        {
            double maxcost = 0.0;
            Party party = Parties[0];
            
            for(int i = 0; i<Parties.Count; i++)
            {
                if (Parties[i].Cost > maxcost)
                    party = Parties[i];
            }

            return party;
        }

        public Tags MostFoundTag()
        {
            List<int> counts = new List<int>();            
            int count = 0;            
            int i = 0;          

            while ( i <= (int) Tags.Seventies)
            {
                count = 0;
                foreach(Party p in Parties)
                {
                    foreach(Tags t in p.Tags)
                    {
                        if(t == (Tags)i)
                        {
                            count++;                            
                        }   
                    }
                }
                counts.Add(count);
                i++;
            }
            int r = counts.IndexOf(counts.Max());
            return (Tags)r;
        }
    }
}
