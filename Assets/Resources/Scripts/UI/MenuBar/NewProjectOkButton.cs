using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewProjectOkButton : MonoBehaviour {

    public InputField nameField;
    public InputField x;
    public InputField y;
    public InputField playerCount;

    public void onSelect()
    {
        int x1, y1, playerCount2;
        if(nameField.text.Trim() == "" ||  // Name
            !int.TryParse(x.text, out x1) || // X
            !int.TryParse(y.text, out y1) || // Y
            !int.TryParse(playerCount.text, out playerCount2)) // Player count
        {
            return;
        }
        Project.newProject(nameField.text, x1, y1, playerCount2, false);
        UIControler.actualPopUp.SetActive(false);
        UIControler.actualPopUp = null;
    }

}
