using System;

namespace HealthyHeaven
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Vegetable tomato = new Vegetable("tomato", 70);
            Vegetable cucumber = new Vegetable("cucumber", 80);
            Vegetable carrot = new Vegetable("carrot", 120);
            Vegetable potato = new Vegetable("potato", 140);
            Vegetable corn = new Vegetable("corn", 60);

            Salad Shopska = new Salad("Shopska");

            Shopska.Add(tomato);
            Shopska.Add(cucumber);
            Shopska.Add(carrot);

            Salad Selska = new Salad("Selska");

            Selska.Add(potato);
            Selska.Add(corn);
            Selska.Add(potato);

            Restaurant myRestaurant = new Restaurant("MyRestaurant");

            myRestaurant.Add(Shopska);
            myRestaurant.Add(Selska);

            Console.WriteLine(myRestaurant.Buy("Shopska"));
        }
    }
}