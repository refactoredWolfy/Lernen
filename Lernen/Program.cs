using System;
using System.Collections.Generic;

// Exercise (Intermediate): Inventory class with a Dictionary<string, int>
// - AddItem ignores amounts of 0 or less
// - RemoveItem returns false if the item is missing or there isn't enough,
//   and removes the key completely when the amount reaches 0
// - GetCount returns 0 if the item isn't there

public class Inventory
{
    private readonly Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string name, int amount)
    {
        if (string.IsNullOrWhiteSpace(name) || amount <= 0) {
            return;
        }

        if (items.ContainsKey(name)) {
            items[name] += amount;
        } else {
            items[name] = amount;
        }
    }

    public bool RemoveItem(string name, int amount)
    {
        if (string.IsNullOrWhiteSpace(name) || amount <= 0) {
            return false;
        }

        int current;
        if (!items.TryGetValue(name, out current) || current < amount) {
            return false;
        }

        if (current == amount) {
            items.Remove(name);
        } else {
            items[name] = current - amount;
        }

        return true;
    }

    public int GetCount(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) {
            return 0;
        }

        int count;
        if (items.TryGetValue(name, out count)) {
            return count;
        }

        return 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        inventory.AddItem("potion", 3);
        inventory.AddItem("potion", 2);   // stacks to 5
        inventory.AddItem("sword", 1);
        inventory.AddItem("arrow", 0);    // ignored

        Console.WriteLine($"Potions: {inventory.GetCount("potion")}");
        Console.WriteLine($"Arrows: {inventory.GetCount("arrow")}");
        Console.WriteLine($"Remove 2 potions: {inventory.RemoveItem("potion", 2)}");
        Console.WriteLine($"Remove 10 potions: {inventory.RemoveItem("potion", 10)}");
        Console.WriteLine($"Remove a shield: {inventory.RemoveItem("shield", 1)}");
        Console.WriteLine($"Remove the sword: {inventory.RemoveItem("sword", 1)}");
        Console.WriteLine($"Swords left: {inventory.GetCount("sword")}");
    }
}