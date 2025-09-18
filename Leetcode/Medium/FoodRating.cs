using static System.String;

namespace Leetcode.Medium;

public class Food
{
    public Food(string name, string cuisine, int rating)
    {
        Name = name;
        Cuisine = cuisine;
        Rating = rating;
    }

    public readonly string Name;
    public readonly string Cuisine;
    public int Rating { get; set; }

    public override bool Equals(object? obj)
    {
        if (typeof(Food) != obj?.GetType())
            return false;
        var other = (Food)obj;
        return other.Name == Name && other.Cuisine == Cuisine;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Cuisine);
    }
}

class FoodComparer : IComparer<Food>
{
    public int Compare(Food a, Food b)
    {
        return a.Rating != b.Rating
            ? b.Rating.CompareTo(a.Rating)
            : string.Compare(a.Name, b.Name, StringComparison.Ordinal);
    }
}

public class FoodRatings
{
    private Dictionary<string, Food> foodMap;
    private Dictionary<string, SortedSet<Food>> cuisineToFood;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        foodMap = new Dictionary<string, Food>();
        cuisineToFood = new Dictionary<string, SortedSet<Food>>();
        for (var i = 0; i < foods.Length; i++)
        {
            var food = new Food(foods[i], cuisines[i], ratings[i]);
            foodMap[foods[i]] = food;
            if (!cuisineToFood.ContainsKey(cuisines[i]))
                cuisineToFood[cuisines[i]] = new SortedSet<Food>(new FoodComparer());

            cuisineToFood[cuisines[i]].Add(food);
        }
    }

    public void ChangeRating(string food, int newRating) {
        var f = foodMap[food];
        var set = cuisineToFood[f.Cuisine];
        set.Remove(f);
        f.Rating = newRating;
        set.Add(f);
    }

    public string HighestRated(string cuisine) {
        return cuisineToFood[cuisine].Min!.Name;
    }
}