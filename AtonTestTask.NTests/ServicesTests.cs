using AtonTestTask.Interfaces;
using AtonTestTask.Models;
using AtonTestTask.Services;

namespace AtonTestTask.NTests
{
    public class ServicesTests
    {
        private IFoodPricesService _foodPricesService;
        private IAnimalInfoService _animalInfoService;
        private IAnimalService _animalService;

        [SetUp]
        public void Setup()
        {
            _foodPricesService = new FoodPricesService();
            _animalInfoService = new AnimalInfoService(_foodPricesService);
            _animalService = new AnimalService(_animalInfoService);
        }

        [Test]
        public void AnimalInfoService_NameInValid_ShouldThrowException()
        {
            //arange
            var animal = new Animal { Kind = "Dog", Weigth = 150 };

            //act
            var exception = Assert.Throws<Exception>(() => _animalInfoService.GetPrice(animal));

            //assert
            Assert.IsNotNull(exception);
        }
        [Test]
        public void AnimalInfoService_FileInValid_ShouldThrowFileNotFoundException()
        {
            //arange
            var path = "InValidPath" + Guid.NewGuid();

            //act
            var exception = Assert.Throws<FileNotFoundException>(() => _animalInfoService.LoadAnimalsInfoFromFile(path));

            //assert
            Assert.IsNotNull(exception);
        }
        [Test]
        public void AnimalService_FileInValid_ShouldThrowFileNotFoundException()
        {
            //arange
            var path = "InValidPath" + Guid.NewGuid();

            //act
            var exception = Assert.Throws<FileNotFoundException>(() => _animalService.LoadAnimalsFromFile(path));

            //assert
            Assert.IsNotNull(exception);
        }
        [Test]
        public void FoodPricesService_FileInValid_ShouldThrowFileNotFoundException()
        {
            //arange
            var path = "InValidPath" + Guid.NewGuid();

            //act
            var exception = Assert.Throws<FileNotFoundException>(() => _foodPricesService.LoadFoodPricesFromFile(path));

            //assert
            Assert.IsNotNull(exception);
        }
    }
}