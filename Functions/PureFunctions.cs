public class PureFunctions
{
    //this is a pure function
    int Max(int a, int b)
    {
        return a >= b ? a : b;
    }
}

class ItemsStorage
{
    private List<Item> _items = new List<Item>();
    private NewItemsTracker _newItemsTracker = new NewItemsTracker();
    private bool _isCleared = false;

    //this is a pure function
    public Item FindItemWithName(string name, List<Item> items)
    {
        return items.FirstOrDefault(item => item.Name == name);
    }


    //this function is impure, as it uses more than the values of parameters
    public Item FindItemWithName(string name)
    {
        return _items.FirstOrDefault(item => item.Name == name);
    }

    //this function is impure, as it modifies the input argument
    public void Empty(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; ++i)
        {
            numbers[i] = 0;
        }
    }

    public void ImpureFunction(List<Item> newItems, bool shallReplaceOldItems)
    {
        if (shallReplaceOldItems)
        {
            _items.Clear();
            _isCleared = true;
        }

        _newItemsTracker.Items = newItems;
        _newItemsTracker.LastUpdate = DateTime.Now;
        _newItemsTracker.NextUpdate = DateTime.Now.AddDays(1);

        foreach (var newItem in newItems)
        {
            if (_items.Count() < GlobalConfig.MaxItems)
            {
                _items.Add(newItem);
            }
        }
    }
}

public class NewItemsTracker
{
    public DateTime LastUpdate;
    public DateTime NextUpdate;
    public List<Item> Items;
}

public static class GlobalConfig
{
    public static int MaxItems = 10;
}

public struct Item { public string Name; }

