using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{

    public string type;
    public float fadeTime = 0.2f;

    //Not fifty but some shades of grey.
    public Color normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color highlighted = new Color(0.960784f, 0.960784f, 0.960784f);
    public Color pressed = new Color(0.7843137f, 0.7843137f, 0.7843137f);
    public Color highlightedpressed = new Color(0.70588235f, 0.70588235f, 0.70588235f);
    public Color disabled = new Color(0.58823552f, 0.58823552f, 0.58823552f);

    //**********************************************************************

    protected static Dictionary<string, SelectableButton> selectableButton = new Dictionary<string, SelectableButton>();
    protected bool selected = false;
    protected bool pointerIn = false;
    Image image;
    protected bool fading = false;
    private float fadeTimer = 0.0f;
    private Color fadeColorDest = new Color();

    //**********************************************************************

    void Start()
    {
        image = GetComponent<Image>();
        Debug.Assert(type.Trim() != "","Veuillez placer le type du selectionnable button : " + this.name);
    }

    private void Update()
    {
        if(fading)
        {
            fade();
        }
    }

    public virtual void onPointerDown()
    {
        if (!selectableButton.ContainsKey(type))
        {
            selectableButton.Add(type, this);
        }
        else if (this == selectableButton[type])
        {
            onDeselect();
            selectableButton[type] = null;
            return;
        }
        else
        {
            if (selectableButton[type] != null) selectableButton[type].onDeselect();
            selectableButton[type] = this;
        }
        selected = true;
        startFade(highlightedpressed);   
    }

    public virtual void onPointerUp()
    {
        startFade(selected ? highlightedpressed : highlighted);
    }

    public virtual void onPointerEnter()
    {
        pointerIn = true;
        image.color = selected ? highlightedpressed : highlighted;
        fading = false;
    }

    public virtual void onPointerExit()
    {
        pointerIn = false;
        fading = false;
        image.color = selected ? pressed : normal;
    }

    protected virtual void onDeselect()
    {
        if (pointerIn) startFade(highlighted);
        else image.color = normal;
        selected = false;
    }

    protected virtual void startFade(Color fadeColor)
    {
        fading = true;
        fadeTimer = 0.0f;
        fadeColorDest = fadeColor;
    }

    protected virtual void fade()
    {
        fadeTimer += Time.deltaTime;
        image.color = Color.Lerp(image.color,fadeColorDest, fadeTimer / fadeTime);
        if(fadeTimer > fadeTime)
        {
            fading = false;
            fadeTimer = 0.0f;
        }

    }
}
