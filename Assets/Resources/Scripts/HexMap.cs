using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

    private static float xratio = 3f;
    private static float yratio = 0.866f;
    private static Dictionary<Vector2, Transform> hexMap = new Dictionary<Vector2, Transform>();
	
    public static void generateMap(int xSize, int ySize)
    {
        clearMap();
        for (int x = 0; x < xSize; ++x)
        {
            for (int y = 0; y < ySize; ++y)
            {
                constructField(x, y, HexField.FieldType.Grass, xSize, ySize);
            }
        }
    }

    public static void loadMap(List<HexField> fields, int xSize, int ySize)
    {
        clearMap();
        Debug.Assert(fields.Count > 0);
        hexMap.Clear();
        foreach(HexField f in fields)
        {
            constructField(f.x, f.y, f.field, xSize, ySize);
        }
    }

    private static void constructField(int x, int y, HexField.FieldType type, int xSize, int ySize)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Materials/HexBlockGO"));
        Transform transform = obj.transform;
        float delta = y % 2 == 1 ? xratio / 2 : 0;
        transform.SetPositionAndRotation(new Vector3(xratio * x - delta - (xSize * xratio / 2), 0,
            y * yratio - (ySize * yratio / 2)), new Quaternion());
        hexMap.Add(new Vector2(x, y), transform);
        HexField field = obj.AddComponent<HexField>();
        field.x = x;
        field.y = y;
        field.field = type;
        textureGameObject(obj, type);
        Project.fields.Add(field);
        transform.parent = GameObject.Find("Map").transform;
    }

    public static void textureGameObject(GameObject obj, HexField.FieldType type)
    {
        switch (type)
        {
            case HexField.FieldType.Grass:
                obj.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Fields/Grass");
                break;
            case HexField.FieldType.Water:
                obj.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Fields/Water");
                break;
            case HexField.FieldType.Mountain:
                obj.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Fields/Mountain");
                break;
            case HexField.FieldType.Dirt:
                obj.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Fields/Dirt");
                break;
        }
    }

    private static void clearMap()
    {
        foreach (var item in hexMap.Values)
        {
            Destroy(item.gameObject);
        }
        Project.fields.Clear();
        hexMap.Clear();
    }
}
