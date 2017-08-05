using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class HexField : MonoBehaviour
{
    public int x, y;
    public FieldType field;

    public enum FieldType
    {
        Grass = 0,
        Rock = 1,
        Sand = 2,
        Poop = 3
    }

    public HexField(int x, int y, int fieldId)
    {
        this.x = x;
        this.y = y;
        this.field = (FieldType)fieldId;
    }
}
