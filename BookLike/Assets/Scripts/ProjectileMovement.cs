using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Sprite wallSprite;
    public GameObject parent;
    Vector3 velocity;
    float lifetime = 1;
    float speed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(parent.GetComponent<PlayerMovement>())
        {
            PlayerMovement pMove = parent.GetComponent<PlayerMovement>();
            velocity = new Vector3(pMove.GetWeaponDirection().x * speed, pMove.GetWeaponDirection().y * speed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += velocity * Time.deltaTime;
        lifetime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
