using System;

// Entry point of the program
class Program {
    static void Main(string[] args) {

        // Creating a new instance of the Store class to manage the items
        var store = new Store();

        // Creating items to be added to the store with their names, quantities, and optional creation dates
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);

        // Adding items
        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(notebook);
        store.AddItem(pen);
        store.AddItem(tissuePack);
        store.AddItem(chipsBag);
        store.AddItem(sodaCan);
        store.AddItem(soap);
        store.AddItem(shampoo);
        store.AddItem(toothbrush);
        store.AddItem(coffee);
        store.AddItem(sandwich);
        store.AddItem(batteries);
        store.AddItem(umbrella);
        store.AddItem(sunscreen);

        // Print current volume
        Console.WriteLine($"Current volume: {store.GetCurrentVolume()}");

        // Print sorted items by name
        Console.WriteLine("Sorted items by name:");
        var sortedItems = store.SortByNameAsc();
        foreach (var sortedItem in sortedItems) {

            Console.WriteLine(sortedItem.ToString());        
        }

        // Find and delete an item by name input
        Console.WriteLine("\nEnter an item's name to delete it or type Quit:");
        string? input;

        while ((input = Console.ReadLine()) != "Quit") {

            if (input != null) {

                var item = store.FindItemByName(input);
                if (item != null) {
                    store.DeleteItem(item.Name);
                    Console.WriteLine($"{input} deleted from the store.");
                    break;

                } else {
                    Console.WriteLine("Enter a valid name or type Quit:");
                    continue;
                }
            } 
        }

        // Print current volume again
        Console.WriteLine($"Current volume: {store.GetCurrentVolume()}");
    }
}


/**

The Item class represents every item in the store inventory.
Each item has a unique name, a specified quantity, and an optional creation date.
The quantity indicates the number of units of the item available in stock and cannot be negative.
If no creation date is provided, the current date is used by default.
*/

public class Item {    

    public string Name { get; }
    private int quantity;
    private DateTime createdDate;

    public int Quantity {
    
        get => quantity;
        set {
        
            if (value < 0) {
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be negative.");
            }
            quantity = value;
        }
    }

    public DateTime CreatedDate => createdDate;

    public Item(string name, int quantity, DateTime? createdDate = null) {

        Name = name;
        Quantity = quantity;
        this.createdDate = createdDate ?? DateTime.Now;
    }

    // Override ToString() functiom to print items
    public override string ToString() { return $"Item Name: {Name}, quantity: {Quantity}, created date: {CreatedDate.ToShortDateString()}."; }
}

/**

The Store class manages a collection of items within a store, providing essential functionality to interact with the inventory.
It allows adding, deleting, searching for items, and retrieving the current total volume of items and sorting them alphabetically by name.
*/
public class Store {
    
    private List<Item> items;

    public Store() {
        items = new List<Item>();
    }

    public void AddItem(Item item) {

        if (items.Any(i => i.Name == item.Name)) {

            throw new ArgumentException($"An item with name '{item.Name}' already exists in the store.");
        }

        items.Add(item);
    }

    public void DeleteItem(string name) {

        var item = FindItemByName(name);
        if (item != null) {

            items.Remove(item);
        }
    }

    public int GetCurrentVolume() {

        return items.Sum(i => i.Quantity);
    }

    public Item FindItemByName(string name) {

        return items.FirstOrDefault(i => i.Name == name)!;
    }

    public List<Item> SortByNameAsc() {

        return items.OrderBy(i => i.Name.Trim()).ToList();
    }
}
