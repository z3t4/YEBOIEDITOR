using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBoxElement : MonoBehaviour {

    public ListBox listBox;
    public Text text;

    public void onClick()
    {
        listBox.onElementClick(text.text);
    }
}
