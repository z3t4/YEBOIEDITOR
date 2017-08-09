using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    private const float CAMERA_SPEED = 7.5f;

    public static MenuBarButton menuBar;
    public enum CursorType
    {
        Empty,
        Brush
    }

    public CursorType cursorType = CursorType.Empty;
    public HexField.FieldType state;
    public GameObject toolBar;
    public static GameObject actualPopUp = null;
    public static GameObject subMenu = null;
    public static int actualPlayer = 0;
    void Update()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(toolBar.GetComponent<RectTransform>(),
                             Input.mousePosition))
        {
            if (Input.GetMouseButton(0))
            {
                switch (this.cursorType)
                {
                    case CursorType.Empty:
                        break;
                    case CursorType.Brush:
                        changeBlock();
                        break;
                }
                
            }

            else if (Input.GetMouseButtonDown(1))
            {
                this.cursorType = CursorType.Empty;
            }
        }

        cameraKeyboardControler();
    }

    public void setBrushState(int idstate)
    {
        this.cursorType = CursorType.Brush;
        this.state = (HexField.FieldType)idstate;
    }

    public void changeCurrentPlayer(int currentPlayer)
    {
        
    }

    private void changeBlock()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject block = hit.transform.gameObject;
            block.GetComponent<HexField>().data.field = this.state;
            HexMap.textureGameObject(block, this.state);
        }
    }

    private void cameraKeyboardControler()
    {
        if (Input.GetKey(KeyCode.Q))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.left * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.Z))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.forward * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.back * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.right * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.up * CAMERA_SPEED, Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
                Camera.main.transform.position + Vector3.down * CAMERA_SPEED, Time.deltaTime);
    }

    
}
