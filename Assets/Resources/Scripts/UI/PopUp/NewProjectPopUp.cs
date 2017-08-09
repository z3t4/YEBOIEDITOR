using UnityEngine;
using UnityEngine.UI;

public class NewProjectPopUp : MonoBehaviour {

    public NewProjectErrorPopUp errorPopUp;

    public InputField nameField;
    public InputField x;
    public InputField y;
    public InputField playerCount;
    
    public void onOk()
    {
        int x1, y1, playerCount1;
        if (nameField.text.Trim() == "" ||  // Name
            !int.TryParse(x.text, out x1) || // X
            !int.TryParse(y.text, out y1) || // Y
            !int.TryParse(playerCount.text, out playerCount1)) // Player count
        {
            return;
        }
        if(!Project.newProject(nameField.text, x1, y1, playerCount1, false))
        {
            gameObject.SetActive(false);
            errorPopUp.x = x1;
            errorPopUp.y = y1;
            errorPopUp.mapName = nameField.text;
            errorPopUp.playerCount = playerCount1;
            errorPopUp.gameObject.SetActive(true);

        }
        UIControler.actualPopUp.SetActive(false);
        UIControler.actualPopUp = null;
    }

    public void onCancel()
    {
        gameObject.SetActive(false);
    }
}
