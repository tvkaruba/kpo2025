using AutoFixture;
using AutoFixture.Xunit2;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using S4.HseCarShop.Models;
using S4.HseCarShop.Models.Abstractions;
using S4.HseCarShop.Services;
using S4.HseCarShop.Services.PedalCars;
using S4.HseCarShop.Services.HandCars;
using S4.HseCarShop.Models.PedalCar;
using S4.HseCarShop.Models.HandCar;

namespace S4.HseCarShop.Tests.Services;

public class CarStorageTests
{
    private readonly Faker _faker;

    public CarStorageTests()
    {
        _faker = new Faker();
    }

    [Fact]
    [Trait("TestCategory", "CarStorage")]
    public void GetCar_HaveCarsInStorage_ReturnsSuitableCar()
    {
        // Arrange
        var engineType = _faker.PickRandom(EngineType.Pedal, EngineType.Hand);

        var carStorage = new CarStorage();

        var pedalEngineFactory = new PedalEngineFactory();
        var pedalCarFactory = new PedalCarFactory(pedalEngineFactory);
        var handEngineFactory = new HandEngineFactory();
        var handCarFactory = new HandCarFactory(handEngineFactory);

        var pedalSize = (uint)_faker.Random.Int(1, 100);
        var pedalEngine = new PedalCarParams(pedalSize);

        carStorage.AddCar(pedalCarFactory, pedalEngine);

        var handCarParams = new HandCarParams(GripsType.Rubber);

        carStorage.AddCar(handCarFactory, handCarParams);

        // Act
        var car = carStorage.GetCar(new[] { (CarType)engineType });

        // Assert
        Assert.NotNull(car);
        Assert.Equal((CarType)engineType, car.Type);

        //car.Should().NotBeNull();
        //car.Engine.Type.Should().Be(engineType);

        // Немного ужастей
        //persons.Should().ContainSingle(x => x.name == "Егор").Which.age.Should().BeGreaterThan(9);
        //age.Should().BeGreaterThan(9)
        //10.May(2020).At(21, 20, 30)

        // А может давайте еще так хД
        //a = b; => Move().b.To().a;
    }

    [Theory]
    [InlineData(EngineType.Hand)]
    [InlineData(EngineType.Pedal)]
    [InlineData((EngineType)42)]
    [Trait("TestCategory", "CarStorage")]
    public void GetCar_EmptyStorage_ReturnsNull(EngineType engineType)
    {
        // Arrange

        // Act
        var carStorage = new CarStorage();
        var car = carStorage.GetCar(new[] { (CarType)engineType });

        // Assert
        Assert.Null(car);
        
        //car.Should().BeNull();
    }


    [Theory]
    [MemberData(nameof(GetCarTestData))]
    [Trait("TestCategory", "CarStorage")]
    public void GetCar_EmptyStorage_ReturnsNull2(EngineType engineType)
    {
        // Arrange

        // Act
        var carStorage = new CarStorage();
        var car = carStorage.GetCar(new[] { (CarType)engineType });

        // Assert
        Assert.Null(car);

        //car.Should().BeNull();
    }

    //public static IEnumerable<object[]> GetCarTestData =>
    public static TheoryData<EngineType> GetCarTestData =>
    [
        EngineType.Pedal,
        EngineType.Hand,
        (EngineType)42,
    ];
}
