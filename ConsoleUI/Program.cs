using Business.Concrete;
using DataAccess.Concrete.Memory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager =  new  CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.DailyPrice + "daily price" + car.Description);
            }
        }

 
        
    }
}
