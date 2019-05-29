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
    TILETYPE type;
    Vector2? slot = null;
    bool IsPlaced = false;
    bool IsSeed = false;
    int ContinentNumber;

    const float XOFFSET        = 0.675f;
    const float YOFFSET        = -0.784f;
    const float YOFFSET_ADJUST = -0.393f;

    Tile(TILETYPE type)
    {
        this.type = type;
    }

    public void SetType(TILETYPE type)
    {
        this.type = type;
    }
    public Vector2? GetSlot()
    {
        return slot;
    }

    public void SetSlot(Vector2 slot)
    {
        this.slot = slot;
    }

    public bool GetPlaced()
    {
        return IsPlaced;
    }

    public void SetPlaced(bool isPlaced)
    {
        IsPlaced = isPlaced;
    }

    public bool GetSeed()
    {
        return IsSeed;
    }

    public void SetSeed(bool isSeed)
    {
        IsSeed = isSeed;
    }

    public int GetContinent()
    {
        return ContinentNumber;
    }

    public void SetContinent(int continentNumber)
    {
        ContinentNumber = continentNumber;
    }

    public void UpdatePosition(Vector2 slot)
    {
        transform.position = new Vector2(XOFFSET * slot.x, (slot.x % 2 != 0) ? (YOFFSET * slot.y) + YOFFSET_ADJUST : (YOFFSET * slot.y));
    }
}
