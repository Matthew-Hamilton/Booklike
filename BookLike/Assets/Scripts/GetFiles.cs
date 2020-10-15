using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GetFiles : MonoBehaviour
{
    public List<string> maps;
    public string m_Text;
    public string folderPath;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSaves();
    }

    private void Update()
    {

        RectTransform[] children = gameObject.GetComponentsInChildren<RectTransform>();
        foreach (RectTransform componant in children)
        {
            if (componant.gameObject.name == "Dropdown List")
            {
                componant.sizeDelta = new Vector2(0, 74);
            }
        }
    }
    public void UpdateSaves()
    {
        gameObject.GetComponent<Dropdown>().ClearOptions();
        maps.Clear();
        string addFile;
        foreach(string file in Directory.GetFiles("Assets/Rooms" + "/" + folderPath))
        {
            if (!file.Contains(".meta"))
            {
                addFile = file.Substring(file.LastIndexOf("\\") + 1);
                maps.Add(addFile);
            }
        }
        gameObject.GetComponent<Dropdown>().AddOptions(maps);
        gameObject.GetComponent<Dropdown>().value = 0;

        DropdownValueChanged();

    }

    public void DropdownValueChanged()
    {
        Dropdown myDropdown = gameObject.GetComponent<Dropdown>();
        m_Text = myDropdown.options[myDropdown.value].text;
    }

}
