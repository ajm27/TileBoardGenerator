using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> TileDeck = new List<GameObject>();
    public GameObject[,] ObscureMap;

    public GameObject FoodTile;
    public GameObject WoodTile;
    public GameObject StoneTile;
    public GameObject MetalTile;
    public GameObject GoldTile;
    public GameObject FoodWoodTile;
    public GameObject FoodStoneTile;
    public GameObject WoodStoneTile;
    public GameObject MetalGoldTile;
    public GameObject FoodWoodStoneTile;
    public GameObject BlankTile;
    public GameObject MountainTile;

    // Tile Counts
    public int NUMBER_OF_FOOD            = 18;
    public int NUMBER_OF_WOOD            = 18;
    public int NUMBER_OF_STONE           = 18;
    public int NUMBER_OF_METAL           = 17;
    public int NUMBER_OF_GOLD            = 17;
    public int NUMBER_OF_FOOD_WOOD       = 11;
    public int NUMBER_OF_WOOD_STONE      = 11;
    public int NUMBER_OF_FOOD_STONE      = 11;
    public int NUMBER_OF_METAL_GOLD      = 10;
    public int NUMBER_OF_FOOD_WOOD_STONE = 6;
    public int NUMBER_OF_BLANK           = 25;
    public int NUMBER_OF_MOUNTAIN        = 15;
    public int NUMBER_OF_TOTAL_TILES;

    float ColumnOffset = -0.800f;
    int[] RowCounts    = { 9, 10, 9, 8, 9, 10, 11, 10, 9, 8, 9, 10, 11, 10, 9, 8, 9, 10, 9 };
    float[] RowOffsets = { 0.0f, 0.4f, 0.0f, -0.4f, 0.0f, 0.4f, 0.8f, 0.4f, 0.0f, -0.4f, 0.0f, 0.4f, 0.8f, 0.4f, 0.0f, -0.4f, 0.0f, 0.4f, 0.0f };

    int mapsize = 0;

    //Offset Constants
    float XOFFSET         =  0.675f;
    float YOFFSET         = -0.784f;
    float YOFFSET_ADJUST  = -0.393f;

    List<Vector2> toCheck = new List<Vector2>()
    {
        new Vector2(-1, 0), // Top-Left
        new Vector2( 0,-1), // Top
        new Vector2( 1, 0), // Top-Right
        new Vector2(-1, 1), // Bottom-Left
        new Vector2( 0, 1), // Bottom
        new Vector2( 1, 1)  // Bottom-Right
    };

    // Start is called before the first frame update
    void Start()
    {
        //ReshuffleMap();
        GenerateObscureMap();
    }

    void GenerateTileDeck()
    {
        int totalTiles = 0;

        for (int i = 0; i < NUMBER_OF_FOOD; i ++)
        {
            GameObject tile = Instantiate(FoodTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.FOOD);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_WOOD; i++)
        {
            GameObject tile = Instantiate(WoodTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.WOOD);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_STONE; i++)
        {
            GameObject tile = Instantiate(StoneTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.STONE);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_METAL; i++)
        {
            GameObject tile = Instantiate(MetalTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.METAL);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_GOLD; i++)
        {
            GameObject tile = Instantiate(GoldTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.GOLD);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_FOOD_WOOD; i++)
        {
            GameObject tile = Instantiate(FoodWoodTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.FOODWOOD);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_WOOD_STONE; i++)
        {
            GameObject tile = Instantiate(WoodStoneTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.WOODSTONE);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_FOOD_STONE; i++)
        {
            GameObject tile = Instantiate(FoodStoneTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.FOODSTONE);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_METAL_GOLD; i++)
        {
            GameObject tile = Instantiate(MetalGoldTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.METALGOLD);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_FOOD_WOOD_STONE; i++)
        {
            GameObject tile = Instantiate(FoodWoodStoneTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.FOODWOODSTONE);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_BLANK; i++)
        {
            GameObject tile = Instantiate(BlankTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.BLANK);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        for (int i = 0; i < NUMBER_OF_MOUNTAIN; i++)
        {
            GameObject tile = Instantiate(MountainTile);
            tile.GetComponent<Tile>().SetType(TILETYPE.MOUNTAIN);
            tile.transform.position = new Vector2(1000, 1000);
            TileDeck.Add(tile);
            totalTiles++;
        }

        NUMBER_OF_TOTAL_TILES = TileDeck.Count;
    }

    void RandomizeDeck()
    {
        List<GameObject> shuffled = new List<GameObject>();

        shuffled = TileDeck.OrderBy(x => Random.value).ToList();

        TileDeck = shuffled;
    }

    void GenerateRectangularMap()
    {
        Vector2 lastPosition = new Vector2(0.0f, 0.0f);
        int tileCount = 0;

        int rowIndex = 0;

        foreach (int row in RowCounts)
        {
            lastPosition.y = RowOffsets[rowIndex];

            for (int i = 0; i < row; i++)
            {
                // Place tile
                TileDeck[tileCount].transform.position = lastPosition;
                // Increase lastPosition by (current column offset + ColumnOffset, current row offset)
                lastPosition = new Vector2(lastPosition.x, lastPosition.y + ColumnOffset);
                // Increment tile count
                tileCount++;
            }

            lastPosition = new Vector2(lastPosition.x += 0.69f, lastPosition.y);

            rowIndex++;
        }
    }

    void GenerateObscureMap()
    {
        GenerateTileDeck();
        RandomizeDeck();

        mapsize = (int) Mathf.Sqrt(NUMBER_OF_TOTAL_TILES) + 2;
        ObscureMap = new GameObject[mapsize, mapsize];

        AssignSlots();
    }

    int placedTiles = 0;

    public void AssignSlots()
    {
        foreach (GameObject tile in TileDeck)
        {
            Tile tileScript = tile.GetComponent<Tile>();

            if (tileScript.Placed == false)
            {
                //Get random slot
                Vector2 slot = new Vector2(Random.Range(0, mapsize), Random.Range(0, mapsize));

                //Check if slot is null
                if (ObscureMap[(int)slot.x, (int)slot.y] == null)
                {
                    //Decide whether tile is placed
                    int rand = Random.Range(0, 5);
                    if (rand == 1)
                    {
                        //calculate position
                        Vector2 vector = new Vector2(XOFFSET * slot.x, (slot.x % 2 != 0) ? (YOFFSET * slot.y) + YOFFSET_ADJUST : (YOFFSET * slot.y));

                        //place the tile
                        tileScript.UpdatePosition(vector);
                        tileScript.SetSlot(slot);
                        tileScript.Placed = true;
                        ObscureMap[(int)slot.x, (int)slot.y] = tile;

                        placedTiles++;
                    }
                }
                else
                {
                    List<Vector2> available = CheckForNeighbors(slot);

                    foreach (Vector2 availableSlot in available)
                    {
                        //Decide whether tile is placed
                        int rand = Random.Range(0, 4);
                        if (rand == 1)
                        {
                            //calculate position
                            Vector2 vector = new Vector2(XOFFSET * slot.x, (slot.x % 2 != 0) ? (YOFFSET * slot.y) + YOFFSET_ADJUST : (YOFFSET * slot.y));

                            //place the tile
                            tileScript.UpdatePosition(vector);
                            tileScript.SetSlot(slot);
                            tileScript.Placed = true; 
                            ObscureMap[(int)slot.x, (int)slot.y] = tile;

                            placedTiles++;
                        }
                    }
                }
            }

        }

        if (placedTiles != NUMBER_OF_TOTAL_TILES)
            AssignSlots();
    }

    private List<Vector2> CheckForNeighbors(Vector2 slot)
    {
        List<Vector2> available = new List<Vector2>();

        foreach(Vector2 check in toCheck)
        {
            int adjustedX = (int) (slot.x + check.x);
            int adjustedY = (int) (slot.y + check.y);

            if (!(adjustedX < 0 || adjustedX > mapsize - 1 || adjustedY < 0 || adjustedY > mapsize - 1 ))
                if (ObscureMap[adjustedX, adjustedY] != null)
                {
                    Debug.Log($"Checking: { adjustedX } , { adjustedY }");
                    available.Add(new Vector2(adjustedX, adjustedY));
                }
        }

        return available;
    }

    public void ReshuffleMap()
    {
        TileDeck = new List<GameObject>();
        GenerateTileDeck();
        RandomizeDeck();
        GenerateRectangularMap();
    }

    public List<GameObject> GetTileDeck()
    {
        return TileDeck;
    }
}
