namespace AtonTestTask.Interfaces
{
    public interface IFoodPricesService
    {
        public IFood GetFood(string name);
        public List<IFood> GetFoods();
        public void LoadFoodPricesFromFile(string path);
    }
}