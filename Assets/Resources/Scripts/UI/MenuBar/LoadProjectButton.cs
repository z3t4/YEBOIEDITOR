using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProjectButton : PopUpButton {


    public override void onLaunchPopUp()
    {
        base.onLaunchPopUp();
        popup.GetComponent<LoadProjectPopUp>().onActivate();
    }
}
