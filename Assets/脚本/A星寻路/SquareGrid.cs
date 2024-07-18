using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid
{
    /// <summary>
    /// F权重，根据具体规则设置，我们这里先求和来用
    /// </summary>
    public int F => g + h;

    /// <summary>
    /// 从起点地格到此地格的成本
    /// </summary>
    public int g;

    /// <summary>
    /// 从这个地格到目的地的估计费用
    /// </summary>
    public int h;

    /// <summary>
    /// 地格的位置
    /// </summary>
    public Vector3Int position;

    /// <summary>
    /// 相邻地格列表
    /// </summary>
    public List<SquareGrid> adjacentTiles = new List<SquareGrid>();

    /// <summary>
    /// 是否阻挡
    /// </summary>
    public bool isObstacle;

    /// <summary>
    /// 父亲地格
    /// </summary>
    public SquareGrid parent;

    public SquareGrid(Vector3Int v, int gg, int hh, bool o, SquareGrid p)
    {
        g = gg;
        h = hh;
        position = v;
        isObstacle = o;
        parent = p;
    }

    int GetDistance(Vector3Int a, Vector3Int b)
    {
        int distance = Mathf.Max(Mathf.Abs(a.x - b.x), Mathf.Abs(a.y - b.y), Mathf.Abs(a.x + a.y - b.x - b.y));
        return distance;
    }
    public void SearchAdjacentTiles(Vector3Int target)
    {
        int y = position.y;
        int x = position.x;
        int z = position.z;
        Vector3Int vector = new Vector3Int(0, 0, 0);
        int mindistance = 0;
        bool isobstacle = false;
        vector.Set(x, y+1, z);
        mindistance = GetDistance(vector, target);
        isobstacle = TilemapManager.tilemapManager.isObstacle(vector);
        adjacentTiles.Add(new SquareGrid(vector, g + 1, mindistance, isobstacle, this));

        vector.Set(x, y - 1, z);
        mindistance = GetDistance(vector, target);
        isobstacle = TilemapManager.tilemapManager.isObstacle(vector);
        adjacentTiles.Add(new SquareGrid(vector, g + 1, mindistance, isobstacle, this));

        vector.Set(x-1, y, z);
        mindistance = GetDistance(vector, target);
        isobstacle =TilemapManager.tilemapManager.isObstacle(vector);
        adjacentTiles.Add(new SquareGrid(vector, g + 1, mindistance, isobstacle, this));

        vector.Set(x+1, y , z);
        mindistance = GetDistance(vector, target);
        isobstacle = TilemapManager.tilemapManager.isObstacle(vector);
        adjacentTiles.Add(new SquareGrid(vector, g + 1, mindistance, isobstacle, this));
    }
}
