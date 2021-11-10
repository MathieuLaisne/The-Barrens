using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICase
{
    private bool _city;
    private bool _empty = false;
    private int _nbSearch;
    private Item[] _items;

    public Item Search()
    {
        if (_empty)
        {
            return new Item(Random.Range(0, 1));
        }
        _nbSearch--;
        if (_nbSearch == 0 && Random.Range(0, 1) == 1)
        {
            return new Item(Random.Range(0, 100)); // last object needs to be only among some plans depending on the type of the ruin.
        }
        return new Item(Random.Range(0, 100));
    }
}
