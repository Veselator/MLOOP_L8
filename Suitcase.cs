using System.Drawing;
using System.Text;

namespace MLOOP_L8
{
    public class Suitcase
    {
        // Зовнішній вигляд
        private Color mainColor;
        private TexturePattern pattern;

        // Технічні характеристики
        private string? manufacturer;
        private double weight; // В кг
        private double volumeCapacity; // В л

        private List<Item> items;

        // Делегати Action
        public event Action? OnItemAdded;
        public event Action<Item>? OnItemRemoved;

        public Color MainColor
        {
            get 
            { 
                return mainColor; 
            }
        }

        public TexturePattern Pattern
        {
            get
            {
                return pattern;
            }
        }

        public string? Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (value is null) return;
                if (value.Length > 70) return;
                manufacturer = value;
            }
        }

        public double SuitWeight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0 || value >= 500) return;
                weight = value;
            }
        }

        public double TotalWeight
        {
            get
            {
                return weight + items.Sum(item => item.Weight);
            }
        }

        public double VolumeCapacity
        {
            get
            {
                return volumeCapacity;
            }
            set
            {
                if (value <= 0 || value >= 500) return;
                volumeCapacity = value;
            }
        }

        public double FilledVolume
        {
            get
            {
                return items.Sum(item => item.Volume);
            }
        }

        public Suitcase(string manufacturer, double weight, double volume, Color color, TexturePattern pattern)
        {
            this.manufacturer = manufacturer;
            this.weight = weight;
            this.volumeCapacity = volume;
            mainColor = color;
            this.pattern = pattern;

            items = new List<Item>();
        }

        public Suitcase()
        {
            manufacturer = "УКРВАЛІЗИ";
            weight = 244.4;
            volumeCapacity = 100.0;
            mainColor = Color.Blue;
            pattern = TexturePattern.Solid;

            items = new List<Item>();
        }

        public bool AddItem(Item item)
        {
            if (FilledVolume + item.Volume - volumeCapacity > 0.0000) return false;
            items.Add(item);
            OnItemAdded?.Invoke();
            return true;
        }

        public bool AddItems(List<Item> newItems)
        {
            // Додаємо все або нічого
            // Якщо загальний об'єм після додавання нових предметів буде більшим за максимальну ємність,
            // то нічого не додаємо

            if (FilledVolume + newItems.Sum(item => item.Volume) - volumeCapacity > 0.0000) return false;
            items.AddRange(newItems);
            OnItemAdded?.Invoke();
            return true;
        }

        public bool Remove(Item item)
        {
            bool result = items.Remove(item);
            if (result) OnItemRemoved?.Invoke(item);
            return result;
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(items);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($" Валіза виробництва {manufacturer} пофарбована в колір {mainColor}, в паттерн {pattern}.\n" +
                $" Вага валізи: {weight} кг, загальна вага: {TotalWeight} кг, максимальній об'єм: {volumeCapacity} л, зайнятий об'єм: {FilledVolume} л.\n" +
                $" Валіза містить {items.Count} елементів:");
            if (items.Count == 0)
            {
                builder.AppendLine("\tЕлементи відсутні");
                return builder.ToString();
            }
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"\t[{i}] {items[i].ToString()}");
            }

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Suitcase) return false;
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
