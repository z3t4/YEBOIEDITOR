using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarButton : MonoBehaviour {

    public GameObject subMenu;

    public void onSelect()
    {
        subMenu.SetActive(!subMenu.activeSelf);

    }

    public void onDeselect()
    {
        subMenu.SetActive(false);
    }
}
