using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectErrorPopUp : MonoBehaviour {

    public string mapName;
    public int x, y, playerCount;

    public void onOk()
    {
        Project.newProject(mapName, x, y, playerCount, true);
        gameObject.SetActive(false);
    }
}
