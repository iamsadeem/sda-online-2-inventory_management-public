
/**

The Store class manages a collection of items within a store with fixed capacity, 
providing essential functionality to interact with the inventory.
It allows adding, deleting, searching for items, retrieving the current total volume of items
and sorting them alphabetically by name, sort items by date (ascending/descending) and group them based on arrival date.
*/
public class Store
{

    private List<Item> items;
    private int MAX_CAPACITY;

    public Store(int maximumCapacity)
    {
        items = new List<Item>();
        MAX_CAPACITY = maximumCapacity;
    }

    public void AddItem(Item item)
    {
        int currentVolume = GetCurrentVolume();
        int totalVolumeAfterAddition = currentVolume + item.Quantity;

        if (totalVolumeAfterAddition > MAX_CAPACITY)
        {
            throw new InvalidOperationException("Adding this item would exceed the maximum capacity of the store.");
        }

        if (items.Any(i => i.Name == item.Name))
        {
            throw new ArgumentException($"An item with name '{item.Name}' already exists in the store.");
        }

        items.Add(item);
    }

    public void DeleteItem(string name)
    {
        var item = FindItemByName(name);
        if (item != null)
        {
            items.Remove(item);
        }
    }

    public int GetCurrentVolume()
    {
        return items.Sum(i => i.Quantity);
    }

    public Item? FindItemByName(string name)
    {
        return items.FirstOrDefault(i => i.Name == name);
    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.Name.Trim()).ToList();
    }

    public List<Item> SortByDate(SortOrder sortOrder)
    {
        return sortOrder switch
        {
            SortOrder.ASC => items.OrderBy(i => i.CreatedDate).ToList(),
            SortOrder.DESC => items.OrderByDescending(i => i.CreatedDate).ToList(),
            _ => throw new ArgumentException("Invalid sort order."),
        };
    }

    public Dictionary<string, List<Item>> GroupByDate()
    {
        DateTime cutoffDate = DateTime.Today.AddMonths(-3);
        var groups = new Dictionary<string, List<Item>> {
            { "New Arrival", new List<Item>() },
            { "Old", new List<Item>() }
        };

        foreach (var item in items)
        {
            string category = item.CreatedDate >= cutoffDate ? "New Arrival" : "Old";
            groups[category].Add(item);
        }

        return groups;
    }
}

// Enum defining sort orders for sorting operations.
public enum SortOrder
{
    ASC,
    DESC
}
