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
    MapGenerator mapgenerator;
    TILETYPE type;
    Hashtable neighbors = new Hashtable();
    bool full = false;

    Tile(MapGenerator mapgenerator, TILETYPE type)
    {
        this.mapgenerator = mapgenerator;
        this.type = type;
    }

    private void Start()
    {
        Vector2 pos = transform.position;

        neighbors.Add(new Vector2(pos.x + 0, pos.y + 0.783f), null); //Top
        neighbors.Add(new Vector2(pos.x + 0, pos.y - 0.783f), null); //Bottom
        neighbors.Add(new Vector2(pos.x - 0.675f, pos.y + 0.391f), null); //Top-Left
        neighbors.Add(new Vector2(pos.x + 0.675f, pos.y + 0.391f), null); //Top-Right
        neighbors.Add(new Vector2(pos.x - 0.675f, pos.y - 0.783f), null); //Bottom-Left
        neighbors.Add(new Vector2(pos.x + 0.675f, pos.y - 0.783f), null); //Bottom-Right

        if (mapgenerator == null)
            mapgenerator = Camera.main.GetComponent<MapGenerator>();

        mapgenerator.GetTileDeck().Add(gameObject);
    }

    private void Update()
    {
        if(!full)
            CheckForNeighbors(mapgenerator.GetTileDeck());
    }

    public void SetType(TILETYPE type)
    {
        this.type = type;
    }

    public void UpdatePosition(Vector2 position)
    {
        transform.position = position;
    }

    public bool CheckForNeighbors(List<GameObject> tileDeck)
    {
        foreach(GameObject tile in tileDeck)
        {
            if (!tile.name.Equals(gameObject.name))
            {
                //Debug.DrawLine(gameObject.transform.position, tile.transform.position, Color.red);
                if (IsNeighbor(tile))
                {
                    Debug.Log(gameObject.name + " has neighbor " + tile.name);
                }
                else
                {
                    Debug.Log("Has no neighbors");
                }
            }
        }

        return false;
    }

    private bool IsNeighbor(GameObject tile)
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();

        Vector2 origin = gameObject.transform.position;
        Vector2 other_origin = tile.transform.position;

        float distance = Mathf.Sqrt(Mathf.Pow(other_origin.x - origin.x, 2) + Mathf.Pow(other_origin.y - origin.y, 2));
        float diameter = ((collider.radius * 2) / 8);

        if (distance <= diameter)
            return true;

        return false;
    }

    public Vector2 FindFreeSpace()
    {

    }
}
