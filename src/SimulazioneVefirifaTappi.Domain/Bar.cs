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

        public Party[] PriciestEvents()
        {
            double maxcost = 0.0;
            
            foreach(Party p in Parties)
            {
                if (p.Cost > maxcost) maxcost = p.Cost;
            }

            List<Party> expensiveparty = new List<Party>();
            foreach(Party p in Parties)
            {
                if (p.Cost == maxcost) expensiveparty.Add(p);
            }
            return expensiveparty.ToArray();
        }

        public Tags[] MostFoundTag()
        {
            List<int> counts = new List<int>();
            List<Tags> mostFoundTags = new List<Tags>();
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

            int maxcount = 0;
            i = 0;
            foreach(int c in counts)
            {
                if (c > maxcount) maxcount = c;
            }

            while( i <= (int) Tags.Seventies)
            {
                if (counts[i] == maxcount)
                    mostFoundTags.Add((Tags)i);

                i++;
            }

            return mostFoundTags.ToArray();
        }
    }
}
