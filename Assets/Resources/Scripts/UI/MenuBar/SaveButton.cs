using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour {

    public void onSelect()
    {
        Project.saveProject();
        UIControler.subMenu.SetActive(false);
        UIControler.subMenu = null;
    }
}
