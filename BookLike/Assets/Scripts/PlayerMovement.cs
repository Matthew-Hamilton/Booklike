using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Vector2 direction;
    Vector2 weapDirection;
    float shootCoolDown;
    public float shootDelay = 0.5f;
    [Range(0.2f, 20)]
    public float speed =1;

    public WeaponManager weaponManager;
    public Room theRoom;
    // Start is called before the first frame update


    private void Start()
    {
        shootCoolDown = shootDelay;
    }
    // Update is called once per frame
    void Update()
    {
        setDirection();
        setWeapDirection();
        transform.position += CheckMove() * speed * Time.deltaTime;

        if (Mathf.Round(Input.GetAxisRaw("Fire1")) > 0 && shootCoolDown <= 0)
        {
            Shoot();
        }
        else
        {
            shootCoolDown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        weaponManager.Fire(gameObject);
        shootCoolDown = shootDelay;
        Debug.Log("Player Shoots");
    }

    void setDirection()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void setWeapDirection()
    {
        weapDirection = new Vector2(Input.GetAxisRaw("AltHorizontal"), Input.GetAxisRaw("AltVertical")).normalized;
    }

    public Vector2 GetWeaponDirection()
    {
        return weapDirection.normalized;
    }
    public Vector2 GetVelocity()
    {
        return direction;
    }

    Vector3 CheckMove()
    {
        GameObject[,] layoutSprites = theRoom.GetLayoutSprites();
        Sprite GroundSprite = Resources.Load<Sprite>("Tiles/Floor");
        Vector3 RefinedMove = direction;

        foreach (GameObject tile in layoutSprites)
        {
            if (tile.GetComponent<SpriteRenderer>().sprite != GroundSprite)
            {
                if (transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f
                    && transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                {
                    if (transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f
                    && transform.position.y+ 0.25 > tile.transform.position.y - 0.5f && transform.position.y- 0.25 < tile.transform.position.y + 0.5f)
                    {
                        RefinedMove.x = 0;
                    }
                    if (transform.position.x + 0.25 > tile.transform.position.x - 0.5f && transform.position.x - 0.25 < tile.transform.position.x + 0.5f
                    && transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                    {
                        RefinedMove.y = 0;
                    }
                    /*if (direction.x > 0 && transform.position.x + direction.x * speed * Time.deltaTime + 0.25 > tile.transform.position.x - 0.5f)
                        RefinedMove.x = 0;
                    if (direction.x < 0 && transform.position.x + direction.x * speed * Time.deltaTime - 0.25 < tile.transform.position.x + 0.5f)
                        RefinedMove.x = 0;
                    if (direction.y > 0 && transform.position.y + direction.y * speed * Time.deltaTime + 0.25 > tile.transform.position.y - 0.5f)
                        RefinedMove.y = 0;
                    if (direction.y < 0 && transform.position.y + direction.y * speed * Time.deltaTime - 0.25 < tile.transform.position.y + 0.5f)
                        RefinedMove.y = 0;*/
                }
            }
        }
        return RefinedMove;
        
    }

    
}
