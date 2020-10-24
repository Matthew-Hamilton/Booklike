using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 direction;
    Vector3 positionChange;
    [Range(0.2f, 20)]
    public float speed =1;

    public Room theRoom;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        getDirection();
        positionChange = transform.position;
        if (CheckMoveX())
            transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;
        if(CheckMoveY())
            transform.position += new Vector3(0, direction.y, 0) * speed * Time.deltaTime;
        //transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        positionChange -= transform.position;
        //Debug.Log("Set: " + positionChange);
    }

    void getDirection()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    bool CheckMoveX()
    {
        GameObject[,] layoutSprites = theRoom.GetLayoutSprites();
        Sprite GroundSprite = Resources.Load<Sprite>("Tiles/Floor");
        foreach (GameObject tile in layoutSprites)
        {
            if(tile.GetComponent<SpriteRenderer>().sprite != GroundSprite)
            {
                if (transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f
                    && transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                {
                    if (transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f)
                    {
                        /* Attempts to allow it to move one way when blocked
                        if (transform.position.x < tile.transform.position.x && direction.x > 0)
                            transform.position = transform.position - new Vector3(transform.position.x, 0, 0) + new Vector3(tile.transform.position.x - 0.75f, 0, 0);
                        if (transform.position.x > tile.transform.position.x && direction.x < 0)
                            transform.position = transform.position - new Vector3(transform.position.x, 0, 0) + new Vector3(tile.transform.position.x + 0.75f, 0, 0);
                            */
                        Debug.Log("Cannot Go Left/Right");
                        return false;
                    }
                }
            }
        }
        return true;
    }
    bool CheckMoveY()
    {
        GameObject[,] layoutSprites = theRoom.GetLayoutSprites();
        Sprite GroundSprite = Resources.Load<Sprite>("Tiles/Floor");
        foreach (GameObject tile in layoutSprites)
        {
            if (tile.GetComponent<SpriteRenderer>().sprite != GroundSprite)
            {
                if (transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f
                    && transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                {
                    if (transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                    {
                        Debug.Log("Cannot Go Up/Down");
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
