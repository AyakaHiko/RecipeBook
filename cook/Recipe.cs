using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cook
{
    public class Recipe 
    {
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public int Portions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> CookOrder { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            CookOrder = new List<string>();
        }
    }

    public class Ingredient : IEquatable<Ingredient>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Count { get; set; }

        public bool Equals(Ingredient other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Unit == other.Unit && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ingredient)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Count.GetHashCode();
                return hashCode;
            }
        }
    }
}
