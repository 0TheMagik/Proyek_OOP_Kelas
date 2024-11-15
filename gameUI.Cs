using System;
using System.Collections.Generic;

namespace EndlessEnds
{
    public class GameUI
    {
        private Character player;
        private List<Item> inventory = new List<Item>();
        private Battle battle;

        public GameUI(Character player)
        {
            this.player = player;
            this.battle = new Battle();
            // Menambahkan item dasar ke inventory
            inventory.Add(new Item("Basic Sword", ItemType.Weapon));
            inventory.Add(new Item("Health Potion", ItemType.potion));
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Endless Ends!");
            DisplayMainMenu();
        }

        private void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Explore World");
                Console.WriteLine("2. View Character Stats");
                Console.WriteLine("3. Open Inventory");
                Console.WriteLine("4. Quit Game");
                Console.Write("Choose an option (1-4): ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ExploreWorld();
                        break;
                    case "2":
                        DisplayCharacterStats();
                        break;
                    case "3":
                        OpenInventory();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for playing Endless Ends!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ExploreWorld()
        {
            Console.WriteLine("\nYou venture into the mysterious lands of Endless Ends...");
            Console.WriteLine("You encounter a hostile creature!");

            // Buat instance Enemy untuk bertarung
            Enemy enemy = new Enemy("Goblin", 30, 5);
            battle.StartCombat(player, enemy);

            // Jika player menang, beri loot
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You found a loot!");
                var loot = new Item("Mystic Potion", ItemType.potion);
                inventory.Add(loot);
                Console.WriteLine($"Added {loot} to inventory.");
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine("\n--- Character Stats ---");
            Console.WriteLine($"Name: {player.CharacterName}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Weapon: {player.weapon}");
            Console.WriteLine($"Potion: {player.potion}");
        }

        private void OpenInventory()
        {
            Console.WriteLine("\n--- Inventory ---");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine("- " + item);
                }
            }
        }
    }
}
