using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : ICase
{
    private bool _city;
    private bool _empty = false;
    private int _nbSearch;
    private bool _wall;
    private Item[] _items;
    private Ruin _ruin;

    public Case(bool city, bool ruin)
    {
        _city = city;
        if(ruin)
        {
            int size = Random.Range(5, 10);
            _ruin = new Ruin(size);
        }
        int nbItem = Mathf.Min(Random.Range(0, 3), Random.Range(0, 3));
        for(int i=0; i<nbItem; i++)
        {
            _items[i] = new Item(Random.Range(0, 100));
        }
        _nbSearch = Random.Range(15, 30) + Random.Range(0, 10) + Random.Range(-5, 5);
    }

    public bool isCity()
    {
        return _city;
    }

}
