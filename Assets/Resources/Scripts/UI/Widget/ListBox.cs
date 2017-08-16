using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBox : MonoBehaviour {

    public GameObject scrollElement;
    public InputField selectedItemInput;
    public GameObject contentPanel;
    public ListBoxElement listElement;

    public Dictionary<string, object> objects = new Dictionary<string, System.Object>();

    public object selectedObject = null;
    private List<ListBoxElement> otherElements = new List<ListBoxElement>();

    public void Start()
    {
        Dictionary<string, object> d = new Dictionary<string, object>();
        d.Add("a", "b");
        d.Add("b", "c");
        d.Add("c", "b");
        d.Add("d", "b");
        d.Add("e", "c");
        d.Add("f", "b");
        d.Add("g", "b");
        d.Add("h", "b");
        d.Add("i", "b");
        d.Add("j", "b");
        populate(d);
    }

    void populate(Dictionary<string, System.Object> population)
    {
        objects.Clear();
        int count = 0;
        float contentPanelSize = 40.0f;
        foreach (string key in population.Keys)
        {
            objects.Add(key, population[key]);
            if(count == 0)
            {
                listElement.gameObject.SetActive(true);
                listElement.text.text = key;
            }
            else
            {
                ListBoxElement element = Instantiate(listElement);
                otherElements.Add(element);
                Vector3 pos = listElement.transform.position;
                element.transform.SetParent(listElement.transform.parent);
                pos.y -= 30 * count;
                element.transform.SetPositionAndRotation(pos, new Quaternion());
                contentPanelSize += 30;
                element.text.text = key;
            }
            count++;
        }
        if (contentPanelSize < scrollElement.GetComponent<RectTransform>().sizeDelta.y)
            contentPanelSize = scrollElement.GetComponent<RectTransform>().sizeDelta.y;
        contentPanel.GetComponent<RectTransform>().sizeDelta =
            new Vector2(contentPanel.GetComponent<RectTransform>().sizeDelta.x,
                contentPanelSize);
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

    private void OnCloseMaster()
    {
        foreach (var item in otherElements)
        {
            Destroy(item);
        }
        listElement.gameObject.SetActive(false);
    }
}
