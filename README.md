# Inventory Management 📦

In this assignment, you will create a simple inventory management system which allows users to add, remove, and view items in the inventory.

### Requirements

1. Create class `Item`, which has name (readonly), quantity, and created date, which are private. Amount of each item cannot be negative. Provide the following features:
   - Constructor to take parameters of name, quantity, and created date (optional, if not set, it will be current date).

2. Create class `Store` with the following properties and methods:
   - A collection to store items, which is private. Initially, this will be an empty collection.
   - Methods to add/delete one item to the collection. Do not allow to add items with the same name to the store.
   - Method `GetCurrentVolume` to compute the total amount of items in the store.
   - Method `FindItemByName` to find an item by name.
   - Method `SortByNameAsc` to get the sorted collection by name in ascending order.

### Extra feature: Capacity

Class `Store` should have the following features:
   - Maximum capacity, which is the total amount of items allowed in the store. The constructor should also take an integer value as the maximum capacity of the inventory.
   - Modify the add method to not overload the capacity.

### Extra feature: Complex functionalities

Class `Store` should have extra features:
   - Method `SortByDate` to get the sorted collection by date dynamically (asc or desc).
   - Method `GroupByDate` to return 2 groups `New Arrival` and `Old` items. `New Arrival` items are those created within the last three months. Items created before August are categorized as `Old`.

Happy coding! 🚀
