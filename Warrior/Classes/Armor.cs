namespace Warrior
{
    public class Armor
    {
        public int ArmorPoints { get; private set; }
        public string Name { get; private set; }

        public Armor(int armorPoints, string name)
        {
            ArmorPoints = armorPoints;
            Name = name;
        }
    }
}
