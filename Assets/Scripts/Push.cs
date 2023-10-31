using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private GameObject[] Walls;
    private GameObject[] Blocks;
    private GameObject[] Door;

    public static bool Target = true;
    public static Vector3 pos;

    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Walls");
        Blocks = GameObject.FindGameObjectsWithTag("Blocks");
        Door = GameObject.FindGameObjectsWithTag("Door");
    }

    public bool Move(Vector2 direction)
    {
        if (ObjToBlock(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    public bool ObjToBlock(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;
        
        foreach (var wall in Walls)
        {
            if (wall.transform.position.x == newpos.x && wall.transform.position.y == newpos.y)
            {
                Target = false;
                return true;
            }
        }

        foreach (var block in Blocks)
        {
            if (block.transform.position.x == newpos.x && block.transform.position.y == newpos.y)
            {
                Target = false;
                return true;
            }
        }

        if (Door != null)
        {
            foreach (var door in Door)
            {
                if (door.transform.position.x == newpos.x && door.transform.position.y == newpos.y)
                {
                    if (!PersonCode.keydoor)
                    {
                        Target = false;
                        return true;
                    }
                    else
                    {
                        Door = null;
                    }
                }
            }
        }
        Target = true;
        return false;
    }
}

