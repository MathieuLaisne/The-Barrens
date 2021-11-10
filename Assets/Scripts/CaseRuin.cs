using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseRuin : ICase
{
    private bool _city;
    private bool _empty = false;
    private int _nbSearch;
    private List<Item> _items;
    private bool _wall;
    private int _val;

    public CaseRuin(int nbItem, bool wall)
    {
        _wall = wall; _val = 0;
        for (int i = 0; i < nbItem; i++)
        {
            _items.Add(new Item(Random.Range(0, 100))); // object range need to be only among some sort of items depending on the type of the ruin.
        }
        _nbSearch = Random.Range(5, 7) + Random.Range(0, 2) + Random.Range(-1, 1);
    }

    public int getVal()
    {
        return _val;
    }

    public void setVal(int newVal)
    {
        _val = newVal;
    }

    public bool isWall()
    {
        return _wall;
    }

    public void setWall()
    {
        _wall = true;
    }
}
