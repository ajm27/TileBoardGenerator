using System;
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
    public bool Placed = false;
    TILETYPE type;
    Vector2? slot = null;

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

    public Vector2? GetSlot()
    {
        return slot;
    }

    public void SetSlot(Vector2 slot)
    {
        this.slot = slot;
    }
}
