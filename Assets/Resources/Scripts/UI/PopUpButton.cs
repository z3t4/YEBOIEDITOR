using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour {

    public GameObject popup;
    public void onLaunchPopUp()
    {
        if(popup) popup.SetActive(true);
        if (UIControler.actualPopUp != popup && UIControler.actualPopUp)
            UIControler.actualPopUp.SetActive(false);
        if (UIControler.subMenu)
        {
            UIControler.subMenu.SetActive(false);
            UIControler.subMenu = null;
        }
        UIControler.actualPopUp = popup;
    }
}
