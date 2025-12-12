namespace SimulazioneVefirifaTappi.Domain
{
    public class Party
    {
        public string Name { get; private set; }
        public DateOnly Date { get; private set; }
        public Tags[] Tags { get; private set; }
        public double Cost { get; private set; }
        public bool IsFree { get; private set; }
        public Party(string name, double cost, DateOnly date, Tags[] tags)
        {
            Name = name;
            Cost = cost;
            Date = date;
            Tags = tags;

            if (Cost == 0.0)
                IsFree = true;
            else
                IsFree = false;
        }

        public bool ContainsTag(Tags tag)
        {
            if (Tags.ToList().Contains(tag))
                return true;
            else
                return false;
        }

        public bool ContainsGroupOfTags(Tags[] tags)
        {
            int count = 0;

            foreach(Tags t in tags)
            {
                if (!Tags.ToList().Contains(tags[count]))
                    return false;

                count++;
            }

            return true;
        }
    }
}
