namespace Warrior
{
    public class Weapon
    {
        public int Damage { get; private set; }
        public string Name { get; private set; }

        public Weapon(int damage, string name)
        {
            Damage = damage;
            Name = name;
        }
    }

}
