# C# Exercise: Inventory System with a Dictionary

A small C# practice exercise from my learning log. It builds a simple game-style inventory using a `Dictionary<string, int>`.

## The Task

Write a class `Inventory` that stores item names and amounts:

- `void AddItem(string name, int amount)`: adds items and stacks them if the item already exists. Amounts of 0 or less are ignored.
- `bool RemoveItem(string name, int amount)`: returns `false` if the item doesn't exist or there aren't enough. Removes the item completely when its amount reaches 0.
- `int GetCount(string name)`: returns the amount of an item, or 0 if it isn't there.

Rules: no LINQ.

## What I Practised

- Storing data in a `Dictionary<string, int>` as a private field inside a class
- `ContainsKey` to check whether an item exists
- `TryGetValue` to check and read a value in one step
- `Remove` to delete a key
- Input validation with `string.IsNullOrWhiteSpace`
- Encapsulation: the dictionary is `private readonly`, so it can only be changed through the class methods

## Example Output

```
Potions: 5
Arrows: 0
Remove 2 potions: True
Remove 10 potions: False
Remove a shield: False
Remove the sword: True
Swords left: 0
```

## What I Learned

- A dictionary should live **inside** the class as a field, so all methods share the same data.
- `TryGetValue` is safer and cleaner than checking `ContainsKey` and then reading the value separately.
- Passing `null` as a key to a dictionary throws an exception, so names should be validated first.
- Methods like `RemoveItem` can return a `bool` instead of throwing an exception, so the caller can react to a failed action.

## How to Run

1. Copy `Program.cs` into a new C# console project.
2. Run it with `dotnet run`, or in any online C# compiler.

## Next Steps

- Add a maximum number of slots
- Add events such as `ItemAdded` and `InventoryFull`
- Rebuild the same system in GDScript for Godot
