using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILETYPE
{
    FOOD = 0,
    WOOD,
    STONE,
    METAL,
    GOLD,
    FOODWOOD,
    WOODSTONE,
    FOODSTONE,
    METALGOLD,
    FOODWOODSTONE,
    BLANK,
    MOUNTAIN
}

public class Tile : MonoBehaviour
{
    TILETYPE type;

    Tile(TILETYPE type)
    {
        this.type = type;
    }

    public void SetType(TILETYPE type)
    {
        this.type = type;
    }

    public void UpdatePosition(Vector2 position)
    {
        transform.position = position;
    }
}
