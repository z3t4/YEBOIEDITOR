using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarButton : MonoBehaviour {

    public GameObject subMenu;

    public void onSelect()
    {
        subMenu.SetActive(!subMenu.activeSelf);
        if(subMenu != UIControler.subMenu)
        {
            if(UIControler.subMenu) UIControler.subMenu.SetActive(false);
            UIControler.subMenu = subMenu;
        }
    }
}
