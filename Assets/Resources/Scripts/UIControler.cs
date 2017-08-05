using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{

    public BrushState state;
    public GameObject toolBar;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(toolBar.GetComponent<RectTransform>(),
                             Input.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                changeBlock();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                this.state = BrushState.NoState;
            }
        }
    }

    void OnMouseDown()
    {

    } 

    public void setBrushState(string state)
    {
        this.state = (BrushState)Enum.Parse(typeof(BrushState), state, true);
    }

    private void changeBlock()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject blockHit = hit.transform.gameObject;
            changeMaterial(blockHit);
        }
    }

    private void changeMaterial(GameObject block)
    {
        switch(this.state)
        {
            case BrushState.Empty:
                block.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
                break;
            case BrushState.Grass:
                block.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Grass");
                break;
            case BrushState.Mountain:
                block.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Mountain");
                break;
        }
    }
}
