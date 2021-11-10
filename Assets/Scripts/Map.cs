using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : IMap
{
    private string _type;
    private int _size;
    private ICase[] _map;

    public Map(string type, int size)
    {
        int nbRuin = 0;
        int city = 1;
        bool isCity = false;
        bool isRuin = false;
        _type = type;_size = size;
        switch(type)
        {
            case "ruin":
                
                break;
            case "valley":
                nbRuin = Random.Range(size / 3, size / 3 + 4);
                while(city == 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (city > 0 && i > 5 && j > 5 && i < size - 5 && j < size - 5)
                            {
                                isCity = Random.Range(0, 1f) > 0.3;
                                city--;
                            }
                            if (nbRuin > 0 && !isCity)
                            {
                                isRuin = Random.Range(0, 1f) > 0.3;
                                nbRuin--;
                            }
                            _map[i * _size + j] = new Case(isCity, isRuin);
                        }
                    }
                }
                break;
            case "plains":
                nbRuin = Random.Range(size / 2, size / 2 + 3);
                while (city == 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (city > 0 && i > 5 && j > 5 && i < size - 5 && j < size - 5)
                            {
                                isCity = Random.Range(0, 1f) > 0.3;
                                city--;
                            }
                            if (nbRuin > 0 && !isCity)
                            {
                                isRuin = Random.Range(0, 1f) > 0.3;
                                nbRuin--;
                            }
                            _map[i * _size + j] = new Case(isCity, isRuin);
                        }
                    }
                }
                break;
            case "tundra":
                nbRuin = Random.Range((int)(size / 4), (int)(size / 4 + 3));
                while (city == 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (city > 0 && i > 5 && j > 5 && i < size - 5 && j < size - 5)
                            {
                                isCity = Random.Range(0, 1f) > 0.3;
                                city--;
                            }
                            if (nbRuin > 0 && !isCity)
                            {
                                isRuin = Random.Range(0, 1f) > 0.3;
                                nbRuin--;
                            }
                            _map[i * _size + j] = new Case(isCity, isRuin);
                        }
                    }
                }
                break;
            case "desert":
                nbRuin = Random.Range((int)(size / 3.5), (int)(size / 3.5 + 3));
                while (city == 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (city > 0 && i > 5 && j > 5 && i < size - 5 && j < size - 5)
                            {
                                isCity = Random.Range(0, 1f) > 0.3;
                                city--;
                            }
                            if (nbRuin > 0 && !isCity)
                            {
                                isRuin = Random.Range(0, 1f) > 0.3;
                                nbRuin--;
                            }
                            _map[i * _size + j] = new Case(isCity, isRuin);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    public string getType()
    {
        return _type;
    }
}
