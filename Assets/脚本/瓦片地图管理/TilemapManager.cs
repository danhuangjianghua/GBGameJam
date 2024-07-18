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

    [Header("��ͼ���")]
    public int width;
    [Header("��ͼ�߶�")]
    public int heigh;
    [Header("��Ƭ��ͼ-�ذ�")]
    public Tilemap tilemapFloor;
    [Header("��Ƭ��ͼ-ǽ��")]
    public Tilemap tilemapWall;
    [Header("���:��Ƭ��ͼ���½ǵ�")]
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
            Debug.LogWarning("ȱ��blockmanager");
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
