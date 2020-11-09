using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCam : MonoBehaviour
{
    float xOffset = 0;
    float yOffset = 0;
    Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("xMin: " + thisCamera.rect.xMin);
        //Debug.Log(thisCamera.ScreenToWorldPoint(Vector3.zero));
        
    }

    public void beUpdated()
    {
        //X Constraints
        if (thisCamera.ScreenToWorldPoint(Vector3.zero).x < -9.5)
        {
            if (transform.parent.transform.position.x > transform.position.x)
            {
                transform.position = transform.position - new Vector3(transform.position.x, 0, 0) + new Vector3(transform.parent.position.x, 0, 0);
                xOffset = 0;
            }
            else
            {
                xOffset += -9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).x;
                thisCamera.transform.position += new Vector3(-9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).x, 0, 0);
            }
        }
        else
        {
            if(xOffset > 0)
            {
                float tempOffset = Mathf.Min(-9.5f - thisCamera.ScreenToWorldPoint(Vector3.zero).x, xOffset);
                thisCamera.transform.position += new Vector3(tempOffset, 0, 0);
                xOffset += tempOffset;
                if (xOffset < 0)
                    xOffset = 0;
            }

        }
        Debug.Log("Camera right pos: " + thisCamera.ScreenToWorldPoint(new Vector3(thisCamera.pixelWidth, 0, 0)).x);
        if (thisCamera.ScreenToWorldPoint(new Vector3(thisCamera.pixelWidth, 0,0)).x > 9.5)
        {
            if (transform.parent.transform.position.x < transform.position.x)
            {
                transform.position = transform.position - new Vector3(transform.position.x, 0, 0) + new Vector3(transform.parent.position.x, 0, 0);
                xOffset = 0;
            }
            else
            {
                xOffset += 9.5f - (float)thisCamera.ScreenToWorldPoint(new Vector3(thisCamera.pixelWidth, 0, 0)).x;
                thisCamera.transform.position += new Vector3(9.5f - (float)thisCamera.ScreenToWorldPoint(new Vector3(thisCamera.pixelWidth, 0, 0)).x, 0, 0);
            }

            Debug.Log("Offset: " +xOffset);
        }
        else
        {
            if (xOffset < 0)
            {
                float tempOffset = Mathf.Max(9.5f - thisCamera.ScreenToWorldPoint(new Vector3(thisCamera.pixelWidth, 0, 0)).x, xOffset);
                thisCamera.transform.position += new Vector3(tempOffset, 0, 0);
                xOffset += tempOffset;
                if (xOffset > 0)
                    xOffset = 0;
            }

        }
        //End of X constraints

        //Y Constraints
        if (thisCamera.ScreenToWorldPoint(Vector3.zero).y < -9.5)
        {
            if (transform.parent.transform.position.y > transform.position.y)
            {
                transform.position = transform.position - new Vector3(0, transform.position.y, 0) + new Vector3(0, transform.parent.position.y, 0);
                yOffset = 0;
            }
            else
            {
                yOffset += -9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).y;
                thisCamera.transform.position += new Vector3(0, -9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).y, 0);
            }
        }
        else
        {
            if (yOffset > 0)
            {
                float tempOffset = Mathf.Min(-9.5f - thisCamera.ScreenToWorldPoint(Vector3.zero).y, yOffset);
                thisCamera.transform.position += new Vector3(0, tempOffset, 0);
                yOffset += tempOffset;
                if (yOffset < 0)
                    yOffset = 0;
            }

        }
        if (thisCamera.ScreenToWorldPoint(new Vector3(0, thisCamera.pixelHeight, 0)).y > 9.5)
        {
            if (transform.parent.transform.position.y < transform.position.y)
            {
                transform.position = transform.position - new Vector3(0, transform.position.y, 0) + new Vector3(0, transform.parent.position.y, 0);
                yOffset = 0;
            }
            else
            {
                yOffset += 9.5f - (float)thisCamera.ScreenToWorldPoint(new Vector3(0, thisCamera.pixelHeight, 0)).y;
                thisCamera.transform.position += new Vector3(0, 9.5f - (float)thisCamera.ScreenToWorldPoint(new Vector3(0, thisCamera.pixelHeight, 0)).y, 0);
            }

            Debug.Log("Offset: " + yOffset);
        }
        else
        {
            if (yOffset < 0)
            {
                float tempOffset = Mathf.Max(9.5f - thisCamera.ScreenToWorldPoint(new Vector3(0, thisCamera.pixelHeight, 0)).y, yOffset);
                thisCamera.transform.position += new Vector3(0, tempOffset, 0);
                yOffset += tempOffset;
                if (yOffset > 0)
                    yOffset = 0;
            }

        }
        //End of Y constraints
        //Debug.Log(xOffset);
    }
}
