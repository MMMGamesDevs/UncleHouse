using System.Collections.Generic;
using UnityEngine;

public class ItemsManager
{
    Dictionary<string, int> _items = new Dictionary<string, int>();
    HashSet<string> _repeatableItems = new HashSet<string>
    {
        "Bullet",
    };

    public bool AddItem(string name, int number = 1)
    {
        if (!_items.ContainsKey(name)) _items.Add(name, number);
        else if (_repeatableItems.Contains(name)) _items.Add(name, _items[name] + number);
        else return false;
        return true;
    }

    public bool HasItem(string name)
    {
        return _items.ContainsKey(name);
    }

    public int GetNumberItem(string name)
    {
        return !_items.ContainsKey(name) ? 0: _items[name];
    }
    public void ShowDebugLog()
    {
        string info = $"{_items.Count} items -> ";
        foreach (var item in _items)
        {
            info += $"{item.Key}({item.Value}) ";
        }
        Debug.Log(info);
    }

}
