using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HexField : MonoBehaviour
{
    public enum FieldType
    {
        Grass = 0,
        Water = 1,
        Mountain = 2,
        Dirt = 3
    }

    public struct Data
    {
        public int x, y;
        public FieldType field;
        public int playerControl;
    }

    public Data data;
}
