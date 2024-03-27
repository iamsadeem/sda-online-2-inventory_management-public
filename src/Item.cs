
/**

The Item class represents every item in the store inventory.
Each item has a unique name, a specified quantity, and an optional creation date.
The quantity indicates the number of units of the item available in stock and cannot be negative.
If no creation date is provided, the current date is used by default.
*/
public class Item
{

    public string Name { get; }
    private int _quantity;
    private DateTime _createdDate;

    public int Quantity
    {

        get => _quantity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Quantity), "Quantity cannot be negative.");
            }
            _quantity = value;
        }
    }

    public DateTime CreatedDate => _createdDate;

    public Item(string name, int quantity, DateTime? createdDate = null)
    {
        Name = name;
        Quantity = quantity;
        _createdDate = createdDate ?? DateTime.Now;
    }

    // Override ToString() functiom to print items
    public override string ToString() { return $"‣ Item Name: {Name}, quantity: {Quantity}, created date: {CreatedDate.ToShortDateString()}."; }
}