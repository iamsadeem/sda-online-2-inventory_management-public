using System;

// Entry point of the program
class Program
{
    static void Main(string[] args)
    {
        // Creating a new instance of the Store class to manage the items with 300 max capacity
        var store = new Store(300);

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

        while (true)
        {
            Console.WriteLine("\n,---------. .---.  .---.     .-''-.             .-'''-. ,---------.    ,-----.    .-------.        .-''-.   ");
            Console.WriteLine("\\          \\|   |  |_ _|   .'_ _   \\           / _     \\\\          \\ .'  .-,  '.  |  _ _   \\     .'_ _   \\  ");
            Console.WriteLine(" `--.  ,---'|   |  ( ' )  / ( ` )   '         (`' )/`--' `--.  ,---'/ ,-.|  \\ _ \\ | ( ' )  |    / ( ` )   ' ");
            Console.WriteLine("    |   \\   |   '-(_{;}_). (_ o _)  |        (_ o _).       |   \\  ;  \\  '_ /  | :|(_ o _) /   . (_ o _)  | ");
            Console.WriteLine("    :_ _:   |      (_,_) |  (_,_)___|         (_,_). '.     :_ _:  |  _`,/ \\ _/  || (_,_).' __ |  (_,_)___| ");
            Console.WriteLine("    (_I_)   | _ _--.   | '  \\   .---.        .---.  \\  :    (_I_)  : (  '\\_/ \\   ;|  |\\ \\  |  |'  \\   .---. ");
            Console.WriteLine("   (_(=)_)  |( ' ) |   |  \\  `-'    /        \\    `-'  |   (_(=)_)  \\ `\"/  \\  ) / |  | \\ `'   / \\  `-'    / ");
            Console.WriteLine("    (_I_)   (_{;}_)|   |   \\       /          \\       /     (_I_)    '. \\_/``\".'  |  |  \\    /   \\       /  ");
            Console.WriteLine("    '---'   '(_,_) '---'    `'-..-'            `-...-'      '---'      '-----'    ''-'   `'-'     `'-..-'   ");


            // Print current volume and sorted items by name
            Console.WriteLine($"\nCurrent volume: {store.GetCurrentVolume()}");
            Console.WriteLine("Sorted items by name:-");
            var sortedItems = store.SortByNameAsc();
            foreach (var sortedItem in sortedItems)
            {
                Console.WriteLine(sortedItem.ToString());
            }

            // Prompt the user with options
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Delete an item from the store.");
            Console.WriteLine("2. Add an item to the stor.");
            Console.WriteLine("3. Sort items by creation date: ascending/descending.");
            Console.WriteLine("4. Grouping items based on their creation dates: New/Old.");
            Console.WriteLine("5. Quit.\n");
            string? choice = Console.ReadLine();

            // Switch statement to perform actions based on user's choice
            switch (choice)
            {
                case "1": // Find and delete an item by name input
                    Console.WriteLine("\nEnter an item's name to delete it or type < to go back:");
                    string? input;
                    while ((input = Console.ReadLine()) != "<")
                    {
                        if (input != null)
                        {
                            if (store.FindItemByName(input) != null)
                            {
                                store.DeleteItem(input);
                                Console.WriteLine($"{input} deleted from the store.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid name or type <:");
                                continue;
                            }
                        }
                    }
                    break;

                case "2": // Add an item through input sequentially; first name then quantity and optional date
                    Console.WriteLine("\nEnter an item's name to add it to the store, or type < to go back:");
                    while ((input = Console.ReadLine()) != "<")
                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("Please enter a valid name.");
                            continue;
                        }

                        if (store.FindItemByName(input) != null)
                        {
                            Console.WriteLine($"An item with the name '{input}' already exists in the store. \nEnter a new item name or type < to go back:");
                            continue;

                        }

                        int quantity;
                        while (true)
                        {
                            Console.WriteLine($"Enter the quantity of '{input}':");
                            if (!int.TryParse(Console.ReadLine(), out quantity))
                            {
                                Console.WriteLine("Invalid quantity. Please enter a valid number.");
                                continue;
                            }
                            break;
                        }

                        DateTime? createdDate = null;
                        while (true)
                        {
                            Console.WriteLine("Enter the creation date in format (yyyy, MM, dd), or leave empty for today's date:");
                            var dateInput = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(dateInput))
                            {
                                break;
                            }
                            if (DateTime.TryParse(dateInput, out DateTime parsedDate))
                            {
                                createdDate = parsedDate;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Please try again.");
                            }
                        }

                        var newItem = new Item(input, quantity, createdDate);
                        store.AddItem(newItem);
                        Console.WriteLine($"{input} added to the store.");
                        break;
                    }
                    break;

                case "3": // Sort by date: ascending/descending
                    var collectionSortedByDateAsc = store.SortByDate(SortOrder.ASC);
                    Console.WriteLine("\nSorted items by date - ascending:");
                    foreach (var item in collectionSortedByDateAsc)
                    {
                        Console.WriteLine(item);
                    }
                    var collectionSortedByDateDesc = store.SortByDate(SortOrder.DESC);
                    Console.WriteLine("\nSorted items by date - descending:");
                    foreach (var item in collectionSortedByDateDesc)
                    {
                        Console.WriteLine(item);
                    };
                    break;

                case "4": // Dictionary here acts as a container for grouping the items into two categories based on their creation dates: New arrivals & Old items
                    var groupByDate = store.GroupByDate();
                    foreach (var group in groupByDate)
                    {
                        Console.WriteLine($"\n{group.Key} Items:");
                        foreach (var item in group.Value)
                        {
                            Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
                        }
                    };
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
