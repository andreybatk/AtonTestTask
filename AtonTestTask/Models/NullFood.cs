using AtonTestTask.Interfaces;

namespace AtonTestTask.Models
{
    public class NullFood : IFood
    {
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; } = 0D;
    }
}
