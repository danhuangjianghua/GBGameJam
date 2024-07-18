using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid
{
    /// <summary>
    /// FȨ�أ����ݾ���������ã������������������
    /// </summary>
    public int F => g + h;

    /// <summary>
    /// �����ظ񵽴˵ظ�ĳɱ�
    /// </summary>
    public int g;

    /// <summary>
    /// ������ظ�Ŀ�ĵصĹ��Ʒ���
    /// </summary>
    public int h;

    /// <summary>
    /// �ظ��λ��
    /// </summary>
    public Vector3Int position;

    /// <summary>
    /// ���ڵظ��б�
    /// </summary>
    public List<SquareGrid> adjacentTiles = new List<SquareGrid>();

    /// <summary>
    /// �Ƿ��赲
    /// </summary>
    public bool isObstacle;

    /// <summary>
    /// ���׵ظ�
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
