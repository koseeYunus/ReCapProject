using Business.Concrate;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- ReCap ---");

            CarManager carManager=new CarManager(new EfCarDal());
            BrandManager brandManager =new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id+" - "+item.BrandName+" - "+item.ColorName+" - "+item.ModelYear+" - "+item.DailyPrice+" - "+item.Decription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //brandManager.Add(new Brand {BrandName= "Volkswagen" });           
            //colorManager.Update(new Color { Id = 1, ColorName = "Pembe" });
            //Car updateCar = new Car { Id=1, BrandId=4, ColorId=1, DailyPrice=500, ModelYear=2005, Description="Yeni Açıklama."};
            //carManager.Update(updateCar);

            //Console.WriteLine("Bütün arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"{car.Id}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}

            //Console.WriteLine("\n\nColor Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //foreach (var car in carManager.GetAllByColorId(2))
            //{
            //    Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            //}

            //Console.WriteLine("\n\nId'si 2 olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //Car carById = carManager.GetById(2);
            //Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");


            //Console.WriteLine("\n\nGünlük fiyat aralığı 100 ile 165 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //foreach (var car in carManager.GetByDailyPrice(100, 165))
            //{
            //    Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            //}

            //Console.WriteLine("\n");

            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = -300, ModelYear = "2021", Descriptions = "Otomatik Dizel" });
            //brandManager.Add(new Brand { BrandName = "a" });

        }
    }
}
