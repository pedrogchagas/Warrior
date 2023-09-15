using System;

namespace Warrior
{
    public static class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao jogo de combate!");

            while (true)
            {
                Console.WriteLine("Digite o nome do seu guerreiro:");
                string playerName = Console.ReadLine();

                Faction playerFaction = ChooseFaction();

                Warrior playerWarrior = CreateWarrior(playerName, playerFaction);

                Warrior enemyWarrior;

                Console.WriteLine("Escolha o inimigo:");
                Console.WriteLine("1. Inimigo Aleatório");
                Console.WriteLine("2. Escolher Informações do Inimigo");

                string enemyChoice = Console.ReadLine();

                if (enemyChoice == "1")
                {
                    enemyWarrior = CreateRandomEnemy();
                }
                else
                {
                    Console.WriteLine("Digite o nome do inimigo:");
                    string enemyName = Console.ReadLine();
                    Faction enemyFaction = ChooseFaction();

                    enemyWarrior = CreateWarrior(enemyName, enemyFaction);
                }

                Console.WriteLine("Iniciando batalha...");

                Random random = new Random();
                int playerRandomDamage = random.Next(-5, 6);
                int enemyRandomDamage = random.Next(-5, 6);

                while (playerWarrior.IsAlive && enemyWarrior.IsAlive)
                {
                    Console.WriteLine("Pressione Enter para atacar o inimigo.");
                    Console.ReadLine();
                    int playerDamage = playerWarrior.CalculateDamage(enemyWarrior.Armor.ArmorPoints) + playerRandomDamage;
                    enemyWarrior.TakeDamage(playerDamage);

                    Console.WriteLine($"{playerWarrior.Name} ataca {enemyWarrior.Name} causando {playerDamage} de dano.");
                    Console.WriteLine($"{playerWarrior.Name} possui {playerWarrior.Health} de saúde.");
                    Console.WriteLine($"{enemyWarrior.Name} possui {enemyWarrior.Health} de saúde.");
                    Console.WriteLine(new string('-', 40));

                    if (!enemyWarrior.IsAlive)
                    {
                        Console.WriteLine($"Você derrotou {enemyWarrior.Name}!");
                        break;
                    }

                    int enemyDamage = enemyWarrior.CalculateDamage(playerWarrior.Armor.ArmorPoints) + enemyRandomDamage;
                    playerWarrior.TakeDamage(enemyDamage);

                    Console.WriteLine($"{enemyWarrior.Name} ataca {playerWarrior.Name} causando {enemyDamage} de dano.");
                    Console.WriteLine($"{playerWarrior.Name} possui {playerWarrior.Health} de saúde.");
                    Console.WriteLine($"{enemyWarrior.Name} possui {enemyWarrior.Health} de saúde.");
                    Console.WriteLine(new string('-', 40));

                    if (!playerWarrior.IsAlive)
                    {
                        Console.WriteLine($"Você foi derrotado por {enemyWarrior.Name}.");
                        break;
                    }
                }

                Console.WriteLine("Deseja jogar novamente? (Digite 'sim' para jogar novamente, ou qualquer outra coisa para sair):");
                string restartChoice = Console.ReadLine().ToLower();
                if (restartChoice != "sim")
                {
                    break;
                }
            }

            Console.WriteLine("Obrigado por jogar. Até a próxima!");
        }

        // Método para escolher a facção do guerreiro
        static Faction ChooseFaction()
        {
            while (true)
            {
                Console.WriteLine("Escolha a facção do seu guerreiro (Bom ou Mau):");
                string factionChoice = Console.ReadLine().ToLower();

                if (factionChoice == "bom")
                {
                    return Faction.GoodGuy;
                }
                else if (factionChoice == "mau")
                {
                    return Faction.BadGuy;
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Por favor, escolha 'Bom' ou 'Mau'.");
                }
            }
        }

        // Método para escolher a arma do guerreiro
        static Weapon ChooseWeapon()
        {
            while (true)
            {
                Console.WriteLine("Escolha a arma do seu guerreiro (Espada, Machado ou Arco):");
                string weaponChoice = Console.ReadLine().ToLower();

                if (weaponChoice == "espada")
                {
                    return new Weapon(10, "Espada");
                }
                else if (weaponChoice == "machado")
                {
                    return new Weapon(12, "Machado");
                }
                else if (weaponChoice == "arco")
                {
                    return new Weapon(8, "Arco");
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Por favor, escolha 'Espada', 'Machado' ou 'Arco'.");
                }
            }
        }

        // Método para escolher a armadura do guerreiro
        static Armor ChooseArmor()
        {
            while (true)
            {
                Console.WriteLine("Escolha a armadura do seu guerreiro (Leve, Média ou Pesada):");
                string armorChoice = Console.ReadLine().ToLower();

                if (armorChoice == "leve")
                {
                    return new Armor(3, "Leve");
                }
                else if (armorChoice == "média")
                {
                    return new Armor(5, "Média");
                }
                else if (armorChoice == "pesada")
                {
                    return new Armor(7, "Pesada");
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Por favor, escolha 'Leve', 'Média' ou 'Pesada'.");
                }
            }
        }



        static Warrior CreateRandomEnemy()
        {
            Random random = new Random();
            string[] enemyNames = { "Inimigo1", "Inimigo2", "Inimigo3" }; // Adicione mais nomes de inimigos, se desejar
            string enemyName = enemyNames[random.Next(enemyNames.Length)];
            Faction enemyFaction = random.Next(2) == 0 ? Faction.GoodGuy : Faction.BadGuy; // Aleatoriamente escolha a facção
            Weapon enemyWeapon = GetRandomWeapon(); // Função para escolher uma arma aleatória
            Armor enemyArmor = GetRandomArmor(); // Função para escolher uma armadura aleatória
            return new Warrior(enemyName, enemyFaction, enemyWeapon, enemyArmor);
        }

        // Função para escolher uma arma aleatória
        static Weapon GetRandomWeapon()
        {
            Random random = new Random();
            string[] weaponNames = { "Espada", "Machado", "Arco" };
            string randomWeaponName = weaponNames[random.Next(weaponNames.Length)];

            switch (randomWeaponName)
            {
                case "Espada":
                    return new Weapon(10, "Espada");
                case "Machado":
                    return new Weapon(12, "Machado");
                case "Arco":
                    return new Weapon(8, "Arco");
                default:
                    return new Weapon(10, "Espada"); // Se a escolha for inválida, retorna a espada por padrão
            }
        }

        // Função para escolher uma armadura aleatória
        static Armor GetRandomArmor()
        {
            Random random = new Random();
            string[] armorNames = { "Leve", "Média", "Pesada" };
            string randomArmorName = armorNames[random.Next(armorNames.Length)];

            switch (randomArmorName)
            {
                case "Leve":
                    return new Armor(3, "Leve");
                case "Média":
                    return new Armor(5, "Média");
                case "Pesada":
                    return new Armor(7, "Pesada");
                default:
                    return new Armor(3, "Leve"); // Se a escolha for inválida, retorna a armadura leve por padrão
            }
        }


        // Método CreateWarrior para criar um guerreiro com informações fornecidas
        static Warrior CreateWarrior(string name, Faction faction)
        {
            Weapon weapon = ChooseWeapon();
            Armor armor = ChooseArmor();
            return new Warrior(name, faction, weapon, armor);
        }
    }
}
