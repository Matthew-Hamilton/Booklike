using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    [Range(0,5)]
    public int difficulty = 0;
    public int levelNumber = 1;
    public int maxNumRooms = 10;
    int numRooms = 0;
    RoomLink currentRoom;
    public bool Reload = false;
    public Room roomLoader = new Room();
    public GameObject player;

    bool loaded = false;
    RoomLink newRoom;
    // Start is called before the first frame update
    void Start()
    {
        //newRoom = new RoomLink("CrossRoads");
        //currentRoom = newRoom;
        ////roomLoader.LoadMap(currentRoom.roomFile);

        //GenerateRooms(newRoom);
        //roomLoader.LoadMap(newRoom.roomFile);
        //Debug.Log("Should load: " + newRoom.roomFile);
        GenerateLevel();
    }

    void GenerateLevel()
    {
        numRooms = 0;
        maxNumRooms = levelNumber + difficulty;
        newRoom = new RoomLink("CrossRoads");
        currentRoom = newRoom;
        GenerateRooms(currentRoom);
        roomLoader.LoadMap(currentRoom.roomFile);
    }


    void GenerateRooms(RoomLink prevRoom)
    {
        numRooms++;
        Debug.Log("Number of Rooms: " + numRooms);
        if(numRooms < maxNumRooms)
        {
            switch (prevRoom.roomType)
            {
                case "CrossRoads":
                    //If statements checking to see if connected room already exists eg. previous room
                    try
                    {
                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            Debug.Log("Has rooms connected");
                        }
                    }
                    catch
                    {
                        //Attaching new room to this room
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        //Linking new room the this room
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        //Creating rooms to attach to new room
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                            Debug.Log("Has rooms connected");
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            Debug.Log("Has rooms connected");
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            Debug.Log("Has rooms connected");
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;

                //TRooms
                case "TDown":
                    try
                    {
                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;
                case "TLeft":
                    try
                    {
                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    break;
                case "TRight":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;
                case "TUp":
                    try
                    {
                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }

                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;

                //Coridors
                case "CoridorHorizontal":
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;
                case "CoridorVertical":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    break;

                //Corners
                case "CornerBottomLeft":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    break;
                case "CornerBottomRight":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[0] = new RoomLink(2);
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[0]);

                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;
                case "CornerTopLeft":
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[1] = new RoomLink(3);
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[1]);
                    }
                    try
                    {
                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    break;
                case "CornerTopRight":
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[2] = new RoomLink(0);
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[2]);
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                            
                        }
                    }
                    catch
                    {
                        prevRoom.connectedRooms[3] = new RoomLink(1);
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                        GenerateRooms(prevRoom.connectedRooms[3]);
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("Num Rooms: " + numRooms + "   Max Num Rooms: " + maxNumRooms);
            Debug.Log("AddingCaps");
            //Add caps to each appropriate connecting room;
            switch (prevRoom.roomType)
            {
                case "CrossRoads":
                    try
                    {
                        //If statements checking to see if connected room already exists eg. previous room
                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        //Attaching new room to this room
                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        //Linking new room the this room
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;

                //TRooms
                case "TDown":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;
                case "TLeft":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }

                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    break;
                case "TRight":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;
                case "TUp":
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;

                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;

                //Coridors
                case "CoridorHorizontal":
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;
                case "CoridorVertical":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    break;

                //Corners
                case "CornerBottomLeft":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    break;
                case "CornerBottomRight":
                    try
                    {

                        if (prevRoom.connectedRooms[0].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[0] = new RoomLink("CapTop");
                        prevRoom.connectedRooms[0].connectedRooms[2] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;
                case "CornerTopLeft":
                    try
                    {

                        if (prevRoom.connectedRooms[1].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[1] = new RoomLink("CapRight");
                        prevRoom.connectedRooms[1].connectedRooms[3] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    break;
                case "CornerTopRight":
                    try
                    {

                        if (prevRoom.connectedRooms[2].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[2] = new RoomLink("CapBottom");
                        prevRoom.connectedRooms[2].connectedRooms[0] = prevRoom;
                    }
                    try
                    {

                        if (prevRoom.connectedRooms[3].roomFile != null)
                        {
                        }
                    }
                    catch
                    {

                        prevRoom.connectedRooms[3] = new RoomLink("CapLeft");
                        prevRoom.connectedRooms[3].connectedRooms[1] = prevRoom;
                    }
                    break;
                default:
                    break;
            }
        }
    }


    void GoLeft()
    {
        RoomLink otherRoom = currentRoom.GetConnectedRoom(3);
        try
        {
            if (otherRoom.roomFile != null)
            {
                Debug.Log("Loading PreExising Room" + otherRoom.roomFile);
                roomLoader.LoadMap(otherRoom.roomFile);
                currentRoom = otherRoom;
                player.transform.position += new Vector3(2* 8.96f, 0, 0);
            }
        }
        catch
        { Debug.Log("No room connected?"); }
        /*catch
        {
            Debug.Log("New Room Created");
            otherRoom = new RoomLink("CrossRoads");
            otherRoom.SetRoomLink(1, currentRoom);
            currentRoom.SetRoomLink(3, otherRoom);
            Debug.Log(otherRoom.roomFile);
            roomLoader.LoadMap(otherRoom.roomFile);
            currentRoom = otherRoom;

        }*/
    }
    void GoRight()
    {
        RoomLink otherRoom = currentRoom.GetConnectedRoom(1);
        try
        {
            if (otherRoom.roomFile != null)
            {
                Debug.Log("Loading PreExising Room" + otherRoom.roomFile);
                roomLoader.LoadMap(otherRoom.roomFile);
                currentRoom = otherRoom;

                player.transform.position -= new Vector3(2* 8.96f, 0, 0);
            }
        }
        catch
        { Debug.Log("No room connected?"); }
        //catch
        //{
        //    Debug.Log("New Room Created");
        //    otherRoom = new RoomLink("CrossRoads");
        //    otherRoom.SetRoomLink(3, currentRoom);
        //    currentRoom.SetRoomLink(1, otherRoom);
        //    Debug.Log(otherRoom.roomFile);
        //    roomLoader.LoadMap(otherRoom.roomFile);
        //    currentRoom = otherRoom;

        //}
    }
    void GoUp()
    {
        RoomLink otherRoom = currentRoom.GetConnectedRoom(0);
        try
        {
            if (otherRoom.roomFile != null)
            {
                Debug.Log("Loading PreExising Room" + otherRoom.roomFile);
                roomLoader.LoadMap(otherRoom.roomFile);
                currentRoom = otherRoom;

                player.transform.position -= new Vector3(0, 2* 8.96f, 0);
            }
        }
        catch
        { Debug.Log("No room connected?"); }
        //catch
        //{
        //    Debug.Log("New Room Created");
        //    otherRoom = new RoomLink("CrossRoads");
        //    otherRoom.SetRoomLink(2, currentRoom);
        //    currentRoom.SetRoomLink(0, otherRoom);
        //    Debug.Log(otherRoom.roomFile);
        //    roomLoader.LoadMap(otherRoom.roomFile);
        //    currentRoom = otherRoom;

        //}
    }
    void GoDown()
    {
        RoomLink otherRoom = currentRoom.GetConnectedRoom(2);
        try
        {
            if (otherRoom.roomFile != null)
            {
                Debug.Log("Loading PreExising Room" + otherRoom.roomFile);
                roomLoader.LoadMap(otherRoom.roomFile);
                currentRoom = otherRoom;
                player.transform.position += new Vector3(0, 2*8.96f, 0);
            }
        }
        catch
        { Debug.Log("No room connected?"); }
        //catch
        //{
        //    Debug.Log("New Room Created");
        //    otherRoom = new RoomLink("CrossRoads");
        //    otherRoom.SetRoomLink(0, currentRoom);
        //    currentRoom.SetRoomLink(2, otherRoom);
        //    Debug.Log(otherRoom.roomFile);
        //    roomLoader.LoadMap(otherRoom.roomFile);
        //    currentRoom = otherRoom;

        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 9.6f)
            GoRight();
        else if (player.transform.position.x <= -9.6f)
            GoLeft();
        else if (player.transform.position.y >= 9.6f)
            GoUp();
        else if (player.transform.position.y <= -9.6f)
            GoDown();

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            debugConnected();
        }*/
    }

    void DebugConnected(int Direction)
    {
        Debug.Log(currentRoom.connectedRooms[Direction-1].roomFile);
    }

    private void OnValidate()
    {
        GenerateLevel();
        Reload = false;
    }
}
