using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Room : MonoBehaviour
{
    public string folderPath;
    public GameObject floorTile;
    public GameObject dropDown;

    List<Collider2D> wallColliders;

    public Color GroundColour;
    public Color Wall;
    
    string loadString;
    string roomName;
    tileType[,] roomLayout = new tileType[15,15];
    public GameObject[,] layoutSprites = new GameObject[15, 15];
    
    /*
    Ground = g
    Abys = a
    Wall = w
    */
    public enum tileType: int
    {
        Ground = 10,
        Abys = 20,
        Wall = 1,
        Rock = 2,
        Chest = 3
    }


    private void Start()
    {

        Sprite GroundSprite = Resources.Load<Sprite>("Tiles/Ground/0");
        for (int y = 0;y < 15; y++)
        {
            for (int x = 0; x < 15; x++)
            {
                roomLayout[x, y] = tileType.Ground;
                layoutSprites[x, y] = Instantiate(floorTile, this.gameObject.transform);
                layoutSprites[x, y].transform.position = new Vector3(x * 1.28f  - (15 * 1.28f)/2 + 0.64f, y * 1.28f - (15 * 1.28f) / 2 + 0.64f);
                layoutSprites[x, y].GetComponent<SpriteRenderer>().sprite = GroundSprite;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[,] GetLayoutSprites()
    {
        return layoutSprites;
    }

    public void SetRoom(tileType[,] layout)
    {
        for (int y = 0; y < 15; y++)
        {
            for (int x = 0; x < 15; x++)
            {
                roomLayout[x, y] = layout[x,y];
                layoutSprites[x, y].transform.position = new Vector3(x * 1.28f - (15 * 1.28f) / 2 + 0.64f, y * 1.28f - (15 * 1.28f) / 2 + 0.64f);
                switch(layout[x,y])
                {
                    case tileType.Ground:
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tiles/Floor");
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().color = GroundColour;
                        layoutSprites[x, y].GetComponent<Rigidbody2D>().simulated = false;

                        break;
                    case tileType.Abys:
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tiles/Void/main");

                        layoutSprites[x, y].GetComponent<Rigidbody2D>().simulated = true;
                        break;
                    case tileType.Wall:
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tiles/Tile");
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().color = Wall;

                        layoutSprites[x, y].GetComponent<Rigidbody2D>().simulated = true;
                        break;
                    default:
                        layoutSprites[x, y].GetComponent<SpriteRenderer>().sprite = null;
                        break;
                }
                
            }
        }
        
    }

    public tileType[,] GetRoom()
    {
        return roomLayout;
    }

    public void SetRoomName(string Name)
    {
        roomName = Name;
    }

    public void SetLoadName(string Name)
    {
        loadString = Name;
    }

    public void SaveMap()
    {
        Debug.Log(folderPath);
        string destination = "Assets/Rooms" + "/" + folderPath + "/" + roomName + ".dat";
        StreamWriter sw = new StreamWriter(destination);

        foreach(int character in roomLayout)
        {
            sw.WriteLine(character);
        }
        sw.Close();
        dropDown.GetComponent<GetFiles>().UpdateSaves();
        //BinaryFormatter formatter = new BinaryFormatter();
        //formatter.Serialize(file, roomLayout);
     
    }

    public void LoadMap()
    {
        loadString = dropDown.GetComponent<GetFiles>().m_Text;
        Debug.Log("Current: " + loadString);
        string destination = "Assets/Rooms" + "/" + folderPath + "/" + loadString;
        StreamReader sr = new StreamReader(destination);

        tileType[,] loadingMap = new tileType[15, 15];
        if (File.Exists(destination))
        {
            for(int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    loadingMap[x, y] = (tileType)(int.Parse(sr.ReadLine()));
                }
            }
        } 
        else
        {
            Debug.LogError("File not found");
            return;
        }

        SetRoom(loadingMap);

        sr.Close();

    }

    public void LoadMap(string filePath)
    {
        string destination = filePath;
        StreamReader sr = new StreamReader(destination);

        tileType[,] loadingMap = new tileType[15, 15];
        if (File.Exists(destination))
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    loadingMap[x, y] = (tileType)(int.Parse(sr.ReadLine()));
                }
            }
        }
        else
        {
            Debug.LogError("File not found");
            return;
        }

        SetRoom(loadingMap);

        sr.Close();

    }


    public void DeleteFile()
    {
        loadString = dropDown.GetComponent<GetFiles>().m_Text;
        string destination = "Assets/Rooms" + "/" + folderPath + "/" + loadString;
        if (File.Exists(destination))
        {
            File.Delete(destination);
        }

        dropDown.GetComponent<GetFiles>().UpdateSaves();
        dropDown.GetComponent<GetFiles>().DropdownValueChanged();
    }
}
