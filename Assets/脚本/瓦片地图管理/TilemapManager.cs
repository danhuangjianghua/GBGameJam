using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    private static TilemapManager manager = null;
    public static TilemapManager tilemapManager
    {
        get
        {
            return manager;
        }
    }

    [Header("地图宽度")]
    public int width;
    [Header("地图高度")]
    public int heigh;
    [Header("瓦片地图-地板")]
    public Tilemap tilemapFloor;
    [Header("瓦片地图-墙壁")]
    public Tilemap tilemapWall;
    [Header("起点:瓦片地图左下角点")]
    public Vector3Int startPoint;
    //public BlockManager blockManager;
    Dictionary<Vector3Int, bool> map = new Dictionary<Vector3Int, bool>();

    private void Awake()
    {
        if (manager == null) manager = this;
        //Init();
        //MsgManager.msgManager.addListener(MsgName.BlockChange, changeMapState);
    }


    void Init()
    {
        for (int i = 0; i < width; ++i)
        {
            Vector3Int cur = startPoint + Vector3Int.right * i;
            for (int j = 0; j < heigh; ++j)
            {
                TileBase t = tilemapWall.GetTile(cur);
                if (t == null) map[cur] = false;
                else map[cur] = true;
                cur = cur + Vector3Int.up;
                
            }
        }
        /*
        if (blockManager == null)
        {
            Debug.LogWarning("缺少blockmanager");
            return;
        }
        for(int i=0;i<blockManager.blocks.Count;++i)
        {
            Vector3Int pos = tilemapFloor.WorldToCell(blockManager.blocks[i].transform.position);
            map[pos] =true;
        }
        */
    }

    public void changeMapState(object sender,EventArgs e)
    {
        Vector3Int pos = tilemapFloor.WorldToCell(((PositionEventArgs)e).worldPosition);
        map[pos] = ((PositionEventArgs)e).obstacle;

    }

    public bool isObstacle(Vector3Int v)
    {
        return map[v];
    }

    public Vector3 cellToWorld(Vector3Int v)
    {
        return tilemapFloor.CellToWorld(v);
    }

    public Vector3Int worldToCell(Vector3 v)
    {
        return tilemapFloor.WorldToCell(v);
    }
}
