using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProjectSelect : MonoBehaviour {

    public string name;
    public GameObject popup;

    public void onActivate()
    {
        popup.SetActive(false);
        Project.loadProject(name);
        UIControler.actualPopUp = null;
    }

}
