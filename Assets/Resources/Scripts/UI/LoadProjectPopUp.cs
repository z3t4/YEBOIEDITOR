using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProjectPopUp : MonoBehaviour {

    public GameObject context;
    public GameObject left;
    public GameObject right;
    
    List<GameObject> objects = new List<GameObject>();
    
	public void onActivate()
    {
        List<string> ss = Project.getListProjectNames();

        resetContent();
        
        int line = ss.Count / 2 + (ss.Count % 2 == 0 ? 0 : 1);
        context.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(context.GetComponent<RectTransform>().sizeDelta.x, line * 65 + 10);
        //Init the first 2;
        if (ss.Count > 0)
        {
            left.SetActive(true);
            left.transform.GetChild(0).GetComponent<Text>().text = ss[0];
            left.transform.GetChild(2).GetComponent<LoadProjectSelect>().name = ss[0];
            if (ss.Count > 1)
            {
                right.SetActive(true);
                right.transform.GetChild(0).GetComponent<Text>().text = ss[1];
                right.transform.GetChild(2).GetComponent<LoadProjectSelect>().name = ss[1];
                int actualLine = 1;
                for (int i = 2; i < ss.Count; i++)
                {
                    GameObject obj;
                    if(i % 2 == 0)
                    {
                        ++actualLine;
                        obj = Instantiate(left);
                        obj.transform.SetParent(context.transform);
                        obj.GetComponent<RectTransform>().localPosition =
                            new Vector3(left.GetComponent<RectTransform>().localPosition.x,
                            left.GetComponent<RectTransform>().localPosition.y - (65 * (actualLine - 1)));
                    }
                    else
                    {
                        obj = Instantiate(right);
                        obj.transform.SetParent(context.transform);
                        obj.GetComponent<RectTransform>().localPosition =
                            new Vector3(right.GetComponent<RectTransform>().localPosition.x,
                            right.GetComponent<RectTransform>().localPosition.y - (65 * (actualLine - 1)));
                    }
                    obj.transform.GetChild(0).GetComponent<Text>().text = ss[i];
                    obj.transform.GetChild(2).GetComponent<LoadProjectSelect>().name = ss[i];
                }
            }
        }
    }
    

    private void resetContent()
    {
        left.SetActive(false);
        right.SetActive(false);
        foreach (GameObject item in objects)
        {
            Destroy(item);
        }
    }	
}
