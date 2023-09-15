using System;

namespace Warrior
{
    public class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        public string Name { get; private set; }
        public Faction Faction { get; private set; }
        private int health;
        public int Health
        {
            get { return health; }
            private set { health = Math.Max(0, value); } // Garante que a saúde não seja menor que 0
        }
        public Weapon Weapon { get; private set; }
        public Armor Armor { get; private set; }
        public bool IsAlive { get { return Health > 0; } }

        public Warrior(string name, Faction faction, Weapon weapon, Armor armor)
        {
            Name = name;
            Faction = faction;
            Health = faction == Faction.GoodGuy ? GOOD_GUY_STARTING_HEALTH : BAD_GUY_STARTING_HEALTH;
            Weapon = weapon;
            Armor = armor;
        }

        public void Attack(Warrior enemy)
        {
            int damage = CalculateDamage(enemy.Armor.ArmorPoints);
            enemy.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            int effectiveDamage = Math.Max(0, damage);
            Health -= effectiveDamage;
        }

        public int CalculateDamage(int enemyArmorPoints)
        {
            int totalDamage = Weapon.Damage - enemyArmorPoints;
            return Math.Max(0, totalDamage);
        }
    }
}
