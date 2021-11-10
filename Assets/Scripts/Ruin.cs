using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin
{
    private int pile;
    private IMap _map;
    
    public Ruin(int size)
    {
        pile = Random.Range(5, 16);
        _map = new MapRuin(size);
    }
}
