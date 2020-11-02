using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public GameObject parent;
    Vector3 velocity;
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        if(parent.GetComponent<PlayerMovement>())
        {
            velocity = new Vector3(parent.GetComponent<PlayerMovement>().GetWeaponDirection().x * speed, parent.GetComponent<PlayerMovement>().GetWeaponDirection().y * speed) + (Vector3)(parent.GetComponent<PlayerMovement>().GetVelocity());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
