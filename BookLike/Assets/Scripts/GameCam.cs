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
        if (thisCamera.ScreenToWorldPoint(Vector3.zero).x < -9.5)
        {
            xOffset += -9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).x;
            thisCamera.transform.position += new Vector3(-9.5f - (float)thisCamera.ScreenToWorldPoint(Vector3.zero).x, 0, 0);
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
        Debug.Log(xOffset);
    }
}
