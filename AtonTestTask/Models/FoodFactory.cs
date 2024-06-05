using AtonTestTask.Interfaces;

namespace AtonTestTask.Models
{
    public static class FoodFactory
    {
        public static IFood? CreateFood(string name, double price)
        {
            IFood? food;

            switch (name.ToLower())
            {
                case "meat":
                    food = new Meat { Name = name, Price = price };
                    break;
                case "fruit":
                    food = new Fruit { Name = name, Price = price };
                    break;
                default: return new NullFood();
            }

            return food;
        }
    }
}
