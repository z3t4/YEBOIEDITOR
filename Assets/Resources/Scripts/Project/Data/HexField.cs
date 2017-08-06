using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HexField : MonoBehaviour
{
    public int x, y;
    public FieldType field;

    public enum FieldType
    {
        Grass = 0,
        Water = 1,
        Mountain = 2,
        Dirt = 3
    }

    public HexField(int x, int y , int idType)
    {
        this.x = x;
        this.y = y;
        this.field = (FieldType)idType;
    }
}
