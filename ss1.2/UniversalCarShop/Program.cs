using UniversalCarShop;

var cars = new CarService(); // создаем сервис для управления автомобилями
var customers = new CustomersStorage(); // создаем сервис для управления покупателями
var hse = new HseCarService(cars, customers); // создаем сервис для продажи автомобилей
var pedalCarFactory = new PedalCarFactory(); // создаем сервис для создания педальных автомобилей
var handCarFactory = new HandCarFactory(); // создаем сервис для создания автомобилей с ручным приводом

// добавляем покупателей

customers.AddCustomer(new Customer(
    name: "Ваня",
    legPower: 6,
    handPower: 4
));

customers.AddCustomer(new Customer(
    name: "Света",
    legPower: 4,
    handPower: 6
));

customers.AddCustomer(new Customer(
    name: "Сергей",
    legPower: 6,
    handPower: 6
));

customers.AddCustomer(new Customer(
    name: "Алексей",
    legPower: 4,
    handPower: 4
));

// добавляем автомобили

cars.AddCar(pedalCarFactory, new PedalEngineParams(2)); // добавляем педальный автомобиль
cars.AddCar(pedalCarFactory, new PedalEngineParams(3)); // добавляем педальный автомобиль
cars.AddCar(handCarFactory, EmptyEngineParams.DEFAULT); // добавляем автомобиль с ручным приводом
cars.AddCar(handCarFactory, EmptyEngineParams.DEFAULT); // добавляем автомобиль с ручным приводом

// Выведем информацию о покупателях

Console.WriteLine("=== Покупатели ===");

foreach (var customer in customers.GetCustomers())
{
    Console.WriteLine(customer);
}

// продадим автомобили
Console.WriteLine("=== Продажа автомобилей ===");

hse.SellCars();

// Выведем информацию о покупателях

Console.WriteLine("=== Покупатели ===");

foreach (var customer in customers.GetCustomers())
{
    Console.WriteLine(customer);
}