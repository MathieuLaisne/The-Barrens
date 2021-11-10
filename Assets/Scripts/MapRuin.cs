using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRuin : IMap
{
    private string _type;
    private int _size;
    private CaseRuin[] _map;

    public MapRuin(int size)
    {
        _size = size;
        _map = new CaseRuin[_size * _size];
        int nbWall = _size * _size;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                do
                {
                    bool wall = Random.Range(0, 1) == 1;
                    _map[i * _size + j] = new CaseRuin(Mathf.Min(Random.Range(0, 3), Random.Range(0, 3)), wall);
                    destroyUnreachable();
                    nbWall = countWalls();
                } while (nbWall < _size*_size/2) ;
            }
        }
    }

    public void setDistancesFromCell(int i, int j)
    {
        resetVal();
        _map[i * _size + j].setVal(0);
        bool stuck = false;
        int dist = 1;
        do
        {
            stuck = true;
            for (int k = 0; k < _size; k++)
            {
                for (int l = 0; l < _size; l++)
                {
                    if (_map[i*_size+j].getVal() == dist)
                    {
                        List<int[]> p = getVoisins(k, l);
                        for (int m=0; i<p.Count; i++)
                        {
                            if (_map[p[m][0] * _size + p[m][1]].getVal() == -1)
                            {
                                _map[p[m][0] * _size + p[m][1]].setVal(dist + 1);
                            }
                        }
                        stuck = false;
                    }
                }
            }
            dist++;
        } while (!stuck);
    }

   public void resetVal()
    {
        for (int k = 0; k < _size; k++)
        {
            for (int l = 0; l < _size; l++)
            {
                _map[k * _size + l].setVal(-1);
            }
        }
    }

    public List<int[]> getVoisins(int i, int j)
    {
        List<int[]> t = new List<int[]>();
        if(!_map[i * _size + j-1].isWall())
        {
            int[] a = { i, j - 1 };
            t.Add(a);
        }
        if (!_map[i * _size + j + 1].isWall())
        {
            int[] a = { i, j + 1 };
            t.Add(a);
        }
        if (!_map[(i-1) * _size + j].isWall())
        {
            int[] a = { i - 1, j };
            t.Add(a);
        }
        if (!_map[(i+1) * _size + j].isWall())
        {
            int[] a = { i+1, j };
            t.Add(a);
        }
        return t;
    }

    public void destroyUnreachable()
    {
        setDistancesFromCell(_size, 0);
        for (int k = 0; k < _size; k++)
        {
            for (int l = 0; l < _size; l++)
            {
                if(_map[k*_size+l].getVal() == -1)
                {
                    _map[k * _size + l].setWall();
                }
            }
        }
    }

    public int countWalls()
    {
        int c = 0;
        for (int k = 0; k < _size; k++)
        {
            for (int l = 0; l < _size; l++)
            {
                if (_map[k * _size + l].isWall())
                {
                    c++;
                }
            }
        }
        return c;
    }

}
