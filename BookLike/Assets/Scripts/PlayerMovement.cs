using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Vector2 direction;
    Vector2 weapDirection;
    float shootCoolDown;
    public float shootDelay = 0.2f;
    [Range(0.2f, 20)]
    public float speed =1;

    public WeaponManager weaponManager;
    public Room theRoom;
    public GameCam theCamera;
    // Start is called before the first frame update


    private void Start()
    {
        shootCoolDown = shootDelay;
        weapDirection = new Vector2(1, 0);
    }
    // Update is called once per frame
    void Update()
    {
        setDirection();
        setWeapDirection();
        transform.position += CheckMove() * speed * Time.deltaTime;
        theCamera.beUpdated();

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
        Vector2 testDir = new Vector2(Input.GetAxisRaw("AltHorizontal"), Input.GetAxisRaw("AltVertical")).normalized;
        if (testDir.magnitude > 0.35)
        {
            weapDirection = testDir;
        }
    }

    public Vector2 GetWeaponDirection()
    {
        return weapDirection.normalized;
    }
    public Vector2 GetVelocity()
    {
        return direction * speed;
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
