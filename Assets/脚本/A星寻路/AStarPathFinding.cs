using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarPathFinding
{
    //»ñÈ¡Âü¹þ¶Ù¾àÀë
    int GetDistance(Vector3Int a,Vector3Int b)
    {
        int distance = Mathf.Abs(a.x + a.y - b.x - b.y);
        return distance;
    }

    public List<Vector3Int> FindPath(Vector3Int startpos,Vector3Int endpos)
    {
        List<Vector3Int> path = new List<Vector3Int>();
        List<SquareGrid> open = new List<SquareGrid>();
        List<Vector3Int> close = new List<Vector3Int>();
        open.Add(new SquareGrid(startpos, 0, GetDistance(startpos, endpos), false,null));
        //path.Add(startpos);
        while(open.Count>0)
        {
            if (open[0].position == endpos)
            {
                break;
            }
            else
            {
                SquareGrid cur = open[0];
                close.Add(cur.position);
                open.RemoveAt(0);
                cur.SearchAdjacentTiles(endpos);
                foreach (var item1 in cur.adjacentTiles)
                {
                    if (close.Contains(item1.position)||item1.isObstacle) continue;
                    bool isInOpen = false;
                    foreach (var item2 in open)
                    {
                        if (item2.position == item1.position)
                        {
                            isInOpen = true;
                            break;
                        }
                    }
                    if (!isInOpen)
                    {
                        SquareGrid h = new SquareGrid(item1.position, cur.g + 1, GetDistance(item1.position, endpos), false,cur);
                        open.Add(h);
                    }
                    else
                    {
                        if(item1.g>cur.g+1)
                        {
                            item1.parent = cur;
                            item1.g = cur.g + 1;
                        }
                    }
                }
                open.OrderBy(a => a.F).ToList();
            }
        }
        if (open.Count == 0) return path;
        SquareGrid temp = open[0];
        while(temp!=null)
        {
            path.Add(temp.position);
            temp = temp.parent;
        }
        path.Reverse();
        return path;
    }
}
