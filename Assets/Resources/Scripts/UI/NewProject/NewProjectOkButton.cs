using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewProjectOkButton : MonoBehaviour {

    public InputField nameField;
    public InputField x;
    public InputField y;
    public void onSelect()
    {
        int x1, y1;
        if(nameField.text.Trim() == "" || !int.TryParse(x.text, out x1) || !int.TryParse(y.text, out y1))
        {
            return;
        }
        Project.newProject(nameField.text, 10, 10, false);
        UIControler.actualPopUp.SetActive(false);
        UIControler.actualPopUp = null;
    }

}
