using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GetFolders : MonoBehaviour
{
    public List<string> folders;
    public string m_Text;
    public GetFiles files;
    public Room room;

    private void Start()
    {
        gameObject.GetComponent<Dropdown>().ClearOptions();
        DirectoryInfo dir = new DirectoryInfo("Assets/Rooms");
        DirectoryInfo[] info = dir.GetDirectories();
        foreach (DirectoryInfo f in info)
        {
            folders.Add(f.Name);
        }
        gameObject.GetComponent<Dropdown>().AddOptions(folders);
        gameObject.GetComponent<Dropdown>().value = 0;
        DropdownValueChanged();
    }
    // Update is called once per frame
    void Update()
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

    public void DropdownValueChanged()
    {
        Dropdown myDropdown = gameObject.GetComponent<Dropdown>();
        m_Text = myDropdown.options[myDropdown.value].text;
        room.folderPath = m_Text;
        Debug.Log(m_Text);
        files.folderPath = m_Text;
        files.UpdateSaves();
    }
}
