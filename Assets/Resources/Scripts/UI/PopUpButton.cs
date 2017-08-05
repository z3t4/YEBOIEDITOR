using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour {

    public GameObject popup;
    public void onLaunchPopUp()
    {
        popup.SetActive(true);
        if (UIControler.actualPopUp != popup)
        {
            UIControler.actualPopUp.SetActive(false);
        }
        if (UIControler.subMenu)
        {
            UIControler.subMenu = null;
            UIControler.subMenu.SetActive(false);
        }
        UIControler.actualPopUp = popup;
    }
}
