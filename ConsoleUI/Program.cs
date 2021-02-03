using Business.Concrate;
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

            CarManager carManager=new CarManager(new InMemoryCarDal());
            BrandManager brandManager =new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            CarDtoManager carDtoManager = new CarDtoManager(new InMemoryCarDtoDal(carManager.GetAll(), brandManager.GetAll(), colorManager.GetAll()));

            AllDataWrite(carDtoManager);

            brandManager.Add(new Brand {Id=4, BrandName= "Volkswagen" });
            carManager.Delete(5);
            colorManager.Update(new Color { Id = 1, ColorName = "Pembe" });

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Ekleme, silme ve guncelleme islemlerinden sonra veriler");
            AllDataWrite(carDtoManager);

        }
        public static void AllDataWrite(CarDtoManager carDtoManager)
        {
            Console.WriteLine("Butun Arabalar");
            Console.WriteLine("ID    MARKA      RENK        MODEL        FIYAT       ACIKLAMA");
            foreach (var car in carDtoManager.GetAll())
            {
                Console.WriteLine(car.Id + "    " + car.BrandName + "     " + car.ColorName + "       " + car.ModelYear + "       " + car.DailyPrice + "      " + car.Decription);
            }
        }

    }
}
