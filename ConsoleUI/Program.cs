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
            Console.WriteLine("\t\t--- ReCap ---\n");

            CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            CarDetail(carManager);
            Space();
            RentalAdd(rentalManager);
            Space();
            RentalDetail(rentalManager);

        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            Console.WriteLine("Recap araç kiralama kayıt.\n");
            var addedResult = rentalManager.Add(new Rental { CustomerId = 1, CarId = 3, RentDate = DateTime.Now });
            Console.WriteLine(addedResult.Message);
        }

        private static void Space()
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------------\n");
        }

        private static void RentalDetail(RentalManager rentalManager)
        {
            Console.WriteLine("Kiralanan araçların detayları.\n");
            var result = rentalManager.GetRentalDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " - " + item.CarId + " - " + item.CustomerName + " - " + item.UserName + " - " + item.ModelYear + " - " +
                        item.BrandName + " - " + item.ColorName + " - " + item.DailyPrice + " - " + item.RentDate + " - " + item.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetail(CarManager carManager)
        {
            Console.WriteLine("Araba detayları.");
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " - " + item.BrandName + " - " + item.ColorName + " - " + item.ModelYear + " - " + item.DailyPrice + " - " + item.Decription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
