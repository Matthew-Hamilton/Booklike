using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 direction;
    Vector3 positionChange;
    [Range(0.2f, 20)]
    public float speed =1;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        getDirection();
        positionChange = transform.position;
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        positionChange -= transform.position;
        //Debug.Log("Set: " + positionChange);
    }

    void getDirection()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
