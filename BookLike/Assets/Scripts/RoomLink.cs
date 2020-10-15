using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoomLink : MonoBehaviour
{
    public string roomType;
    public string roomFile;
    public List<RoomLink> connectedRooms = new List<RoomLink>();

    int randomPick;

    public RoomLink(string roomType_)
    {
        for(int i = 0; i < 4; i++)
        {
            connectedRooms.Add(null);
        }
        roomType = roomType_;
        Start();
    }
    
    public RoomLink(int lastRoomDir)
    {
        for (int i = 0; i < 4; i++)
        {
            connectedRooms.Add(null);
        }
        switch (lastRoomDir)
        {
            case 0:
                RandomiseRoomType("CapLeft", "CapTop", "CapRight", "TUp", "CoridorHorizontal", "CornerTopLeft", "CornerTopRight");
                break;
            case 1:
                RandomiseRoomType("CapRight", "CapTop", "CapBottom", "TRight", "CoridorVertical", "CornerBottomRight", "CornerTopRight");
                break;
            case 2:
                RandomiseRoomType("CapLeft", "CapRight", "CapBottom", "TDown", "CoridorHorizontal", "CornerBottomLeft", "CornerBottomRight");
                break;
            case 3:
                RandomiseRoomType("CapLeft", "CapTop", "CapBottom", "TLeft", "CoridorVertical", "CornerBottomLeft", "CornerTopLeft");
                break;
        }
        Start();
    }
    
    void Start()
    {
        RandomiseRoom();
    }

    void RandomiseRoom()
    {
        string[] files;

        files = Directory.GetFiles(Application.persistentDataPath + "/" + roomType);
        randomPick = Random.Range(0, files.Length);
        roomFile = files[randomPick];
        Debug.Log(roomFile);
    }

    void RandomiseRoomType(string disqualifiedRoom1 = " ", string disqualifiedRoom2 = " ", string disqualifiedRoom3 = " ", string disqualifiedRoom4 = " ", string disqualifiedRoom5 = " ", string disqualifiedRoom6 = " ", string disqualifiedRoom7 = " ", string disqualifiedRoom8 = " ", string disqualifiedRoom9 = " ", string disqualifiedRoom10 = " ", string disqualifiedRoom11 = " ")
    {
        List<string> folders =  new List<string>();
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        DirectoryInfo[] info = dir.GetDirectories();
        foreach (DirectoryInfo f in info)
        {
            folders.Add(f.Name);
        }

        bool assignedType = false;
        while (!assignedType)
        {
            int randValue = Random.Range(0, 14);
            if (folders[randValue] != disqualifiedRoom1 && folders[randValue] != disqualifiedRoom2 && folders[randValue] != disqualifiedRoom3
                && folders[randValue] != disqualifiedRoom4 && folders[randValue] != disqualifiedRoom5 && folders[randValue] != disqualifiedRoom6
                && folders[randValue] != disqualifiedRoom7 && folders[randValue] != disqualifiedRoom8 && folders[randValue] != disqualifiedRoom9 &&
                folders[randValue] != disqualifiedRoom10 && folders[randValue] != disqualifiedRoom11)
            {
                roomType = folders[randValue];
                assignedType = true;
            }
        }
    }

    public void SetRoomLink(int Direction, RoomLink Room)
    {
        connectedRooms[Direction] = Room;
    }

    public RoomLink GetConnectedRoom(int Direction)
    {
        return connectedRooms[Direction];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
