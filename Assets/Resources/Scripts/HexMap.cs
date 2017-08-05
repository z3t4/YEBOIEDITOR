using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

    private static float xratio = 3f;
    private static float yratio = 0.866f;
    private static Dictionary<Vector2, Transform> hexMap = new Dictionary<Vector2, Transform>();
	
    public static void generateMap(int xSize, int ySize)
    {
        hexMap.Clear();
        for (int x = 0; x < xSize; ++x)
        {
            for (int y = 0; y < ySize; ++y)
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
                field.field = HexField.FieldType.Grass;
                Project.fields.Add(field);
                transform.parent = GameObject.Find("Map").transform;
            }
        }
    }
}
