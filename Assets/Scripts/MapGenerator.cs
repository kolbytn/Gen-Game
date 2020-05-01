using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public PolygonCollider2D confiner;
    public PlayerController playerController;
    public int width = 20;
    public int height = 20;
    public Vector2 start;

    int tileCount = 2;

    void Start()
    {
        GenerateMap();
        confiner.points = new Vector2[] { new Vector2(0, 0), new Vector2(0, height), new Vector2(width, height), new Vector2(width, 0) };
        playerController.Teleport(new Vector2(10, 10), Vector2.zero);
    }

    void GenerateMap()
    {
        Tile blank = Resources.Load<Tile>("Tiles/1bit_small_63");
        Tile ground = Resources.Load<Tile>("Tiles/1bit_small_6");
        GameObject treePrefab = Resources.Load<GameObject>("Prefabs/tree");

        int[,] map = new int[width, height];
        for (int i = 0; i < map.GetUpperBound(0); i++)
        {
            for (int j = 0; j < map.GetUpperBound(1); j++)
            {
                int tileIndex = (int) Math.Floor(UnityEngine.Random.value * tileCount);
                if (tileIndex == tileCount)
                {
                    tileIndex--;
                }

                if (tileIndex == 0)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), blank);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), ground);
                }

                if (UnityEngine.Random.value < .1)
                {
                    GameObject treeObject = Instantiate(treePrefab, new Vector3(i, j, 0), Quaternion.identity);
                }
            }
        }
    }
}
