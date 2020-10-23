using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenuController : MonoBehaviour
{
    public GameObject theMenu;

    public Camera myCamera;

    

    public Vector2 moveInput;
    public Vector2 lastInput;
    Vector2 Moved;


    public GameObject[] Options;
    public Color normal;
    public Color Highlighted;

    public int selectedOption;
 
    private int XboxController = 0;
    private int PS4Controller = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("OpenMenu"))
        {
            theMenu.SetActive(true);
        }
        if (Input.GetButtonUp("OpenMenu"))
        {
            theMenu.SetActive(false);
        }

        if (theMenu.activeInHierarchy)
        {
            string[] Controllers = Input.GetJoystickNames();

            // This checks the array of connected controllers
            for (int x = 0; x < Controllers.Length; x++)
            {
               // print(Controllers[x].Length);
                if (Controllers[x].Length == 19)
                { // if its length is 19 it means a PS4 CONTROLLER IS CONNECTED.
                   // print("PS4 CONNECTED");
                    PS4Controller = 1;
                    XboxController = 0;
                }
                if (Controllers[x].Length == 33)
                { // if 33 an xbox.
                  //  print("Xbox CONNECTED");
                    PS4Controller = 0;
                    XboxController = 1;
                }

            }

           if (XboxController == 1 || PS4Controller == 1)
            {
            moveInput.x = Input.GetAxisRaw("AltHorizontal");
            moveInput.y = Input.GetAxisRaw("AltVertical");
            if (moveInput.magnitude < 0.5)
                {
                    moveInput = Vector2.zero;
                    Debug.Log("Stick Centre-ish"); 
                }

                Moved = moveInput;


                float angle = Mathf.Atan2(Moved.y, -Moved.x) / Mathf.PI;
                angle *= 180;
                angle -= 90-22.5f;
                if (angle < 0)
                {
                    angle += 360;

                }
                Debug.Log(angle);


                for (int i = 0; i < Options.Length; i++)
                {

                    if (Moved == Vector2.zero)
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = normal;
                        
                    }

                    else if (angle > i * (360 / Options.Length) && angle < (i + 1) * (360 / Options.Length))
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = Highlighted;

                        selectedOption = i;

                    }
                    else
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = normal;

                    }
                }



                lastInput = moveInput;

            }
           else // this should then choose between which input to use. Raw for Controller. Mouse for Mouse. 
            {
            moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
            moveInput.y = Input.mousePosition.y - (Screen.height / 2f); //sets middle of the screen for the mouse. 

                if ((moveInput - lastInput).magnitude > 0.1)
                {
                    Moved = moveInput - lastInput;
                    Moved.Normalize();
                }


                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;
                angle *= 180;
                angle -= 90;
                if (angle < 0)
                {
                    angle += 360;

                }
                Debug.Log(angle);


                for (int i = 0; i < Options.Length; i++)
                {

                    if (moveInput == Vector2.zero)
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = normal;


                    }

                    else if (angle > i * (360/Options.Length) && angle < (i + 1) * (360 / Options.Length))
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = Highlighted;

                        selectedOption = i;

                    }
                    else
                    {
                        Options[i].GetComponent<SpriteRenderer>().color = normal;

                    }
                }

            }

         

            // no need to work out an angle on the radial menu.
           
               
        }

        switch (selectedOption)
        {
            case 0:
                myCamera.backgroundColor = Color.green;
                break;
            case 1:
                myCamera.backgroundColor = Color.red;
                break;
            case 2:
                myCamera.backgroundColor = Color.blue;
                break;
            case 3:
                myCamera.backgroundColor = Color.cyan;
                break;
            case 4:
                myCamera.backgroundColor = Color.gray;
                break;
            case 5:
                myCamera.backgroundColor = Color.white;
                break;
            case 6:
                myCamera.backgroundColor = Color.magenta;
                break;
            case 7:
                myCamera.backgroundColor = Color.yellow;
                break;

            default:
                myCamera.backgroundColor = Color.black;
                break;



        }


    }

}
