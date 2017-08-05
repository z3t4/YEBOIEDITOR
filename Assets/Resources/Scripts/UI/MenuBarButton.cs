using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarButton : MonoBehaviour {

    public GameObject subMenu;

    public void onSelect()
    {
        if(subMenu != UIControler.subMenu && subMenu)
        {
            if(UIControler.subMenu) UIControler.subMenu.SetActive(false);
            UIControler.subMenu = subMenu;
        }
        if (subMenu)
        {
            subMenu.SetActive(!subMenu.activeSelf);
        }
    }
}
