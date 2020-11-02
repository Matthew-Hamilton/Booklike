using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public RadialMenuController radialMenu;
    public GameObject[] weaponAttacks;
    int selectedOption;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire(GameObject entityFiring)
    {
        switch(selectedOption)
        {
            case 0:
                var newBullet = Instantiate(weaponAttacks[0], entityFiring.transform.position, Quaternion.identity);
                newBullet.GetComponent<ProjectileMovement>().parent = entityFiring;
                break;
            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        selectedOption = radialMenu.GetSelected();
    }
}
