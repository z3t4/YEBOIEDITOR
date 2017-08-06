using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour {

    public InputField x;
    public InputField y;

    public void onSelect()
    {
        int x1, y1;
        if ( !int.TryParse(x.text, out x1) || !int.TryParse(y.text, out y1))
        {
            return;
        }
        HexMap.generateMap(x1, y1);
        UIControler.actualPopUp.SetActive(false);
        UIControler.actualPopUp = null;
    }

}
