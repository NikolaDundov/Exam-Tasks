namespace FightingArena
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Arena myArena = new Arena("armeec");


            Stat firstGlariatorStat = new Stat(20, 25, 35, 14, 48);
            Stat secondGlariatorStat = new Stat(40, 40, 40, 40, 40);
            Stat thirdGlariatorStat = new Stat(20, 25, 35, 14, 48);

            Weapon firstGlariatorWeapon = new Weapon(5, 28, 100);
            Weapon secondGlariatorWeapon = new Weapon(5, 28, 100);
            Weapon thirdGlariatorWeapon = new Weapon(50, 50, 50);

            Gladiator firstGladiator = new Gladiator("Stoyan", firstGlariatorStat, firstGlariatorWeapon);
            Gladiator secondGladiator = new Gladiator("Pesho", secondGlariatorStat, secondGlariatorWeapon);
            Gladiator thirdGladiator = new Gladiator("Gosho", thirdGlariatorStat, thirdGlariatorWeapon);

            myArena.Add(firstGladiator);
            myArena.Add(secondGladiator);
            myArena.Add(thirdGladiator);

            Gladiator test = myArena.GetGladitorWithHighestStatPower();

            System.Console.WriteLine(test);
            System.Console.WriteLine(myArena.Count);

            Gladiator strongestGladiator = myArena.GetGladitorWithHighestTotalPower();
            System.Console.WriteLine(strongestGladiator);

        }
    }
}
