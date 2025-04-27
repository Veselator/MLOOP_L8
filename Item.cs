namespace MLOOP_L8
{
    public class Item
    {
        private string name;
        private double weight;
        private double volume;

        public string? Name
        {
            get
            {
                return name;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }
        }

        public Item(string name, double weight, double volume)
        {
            this.name = name;
            this.weight = weight;
            this.volume = volume;
        }

        public Item()
        {
            name = "Книга";
            weight = 2.74;
            volume = 16.3;
        }

        public override string ToString()
        {
            return $"{name}, вага {weight} кг, об'єм {volume} л";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Item) return false;
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
