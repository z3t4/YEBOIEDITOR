using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    private const float CAMERA_SPEED = 7.5f;

    public static MenuBarButton menuBar;
    public BrushState state;
    public GameObject toolBar;
    public static GameObject actualPopUp = null;
    public static GameObject subMenu = null;
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
            if (Input.GetMouseButton(0))
            {
                changeBlock();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                this.state = BrushState.NoState;
            }
        }

        cameraKeyboardControler();
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

    private void cameraKeyboardControler()
    {
        if (Input.GetKey(KeyCode.Q))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.left * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.Z))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.forward * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.back * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.right * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.up * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Camera.main.transform.position + Vector3.down * CAMERA_SPEED, Time.deltaTime);
    }
}
