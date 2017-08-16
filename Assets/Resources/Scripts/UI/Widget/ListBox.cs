using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBox : MonoBehaviour {

    public GameObject scrollElement;
    public InputField selectedItemInput;
    public GameObject contentPanel;
    public GameObject listElement;

    public Dictionary<string, object> objects = new Dictionary<string, System.Object>();

    public object selectedObject = null;
    
    void populate(Dictionary<string, System.Object> population)
    {

        objects.Clear();
        foreach (string key in population.Keys)
        {
            objects.Add(key, population[key]);
        }
    }

    public void onButtonClick()
    {
        scrollElement.SetActive(!scrollElement.activeSelf);
    }

    public void onElementClick(string name)
    {
        selectedItemInput.text = name;
        scrollElement.SetActive(false);
    }

    public object getSelectedObject()
    {
        return selectedObject; 
    }

    private void deselect()
    {
        selectedObject = null;
        selectedItemInput.text = "";
    }
    
}
