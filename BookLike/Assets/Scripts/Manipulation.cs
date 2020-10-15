using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    public Room room;
    public Room.tileType toolType = 0;


    Room.tileType[,] map;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            map = room.GetRoom();
                Vector2 MousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);


                for (int y = 0; y < 15; y++)
                {
                    for (int x = 0; x < 15; x++)
                    {
                        if((MousePosition - (new Vector2(-7.5f*1.28f + x * 1.28f + 0.64f, -7.5f * 1.28f + y * 1.28f + 0.64f))).magnitude < 0.64f)
                        {
                            map[x, y] = toolType;
                        }
                    }
                }

            

            room.SetRoom(map);
        }
    }

    public void SetTool(int tool)
    {
        toolType = (Room.tileType)tool;
    }
}
