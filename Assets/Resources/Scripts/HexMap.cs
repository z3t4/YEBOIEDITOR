using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

    public Transform hexSupport;
    private static float xratio = 3f;
    private static float yratio = 0.866f;
    public float sizeX;
    public float sizeY;
    private Dictionary<Vector2, Transform> hexMap = new Dictionary<Vector2, Transform>();
	// Use this for initialization
	void Start () {
		//generateHexMap

        for(int x = 0; x < sizeX; ++x)
        {
            for (int y = 0; y < sizeY; ++y)
            {
                Transform transform = Instantiate(hexSupport);
                float delta = y % 2 == 1 ? xratio / 2 : 0;
                transform.SetPositionAndRotation(new Vector3(xratio * x - delta - (sizeX * xratio / 2), 0, y * yratio - (sizeY * yratio / 2) ), new Quaternion());
                hexMap.Add(new Vector2(x, y), transform);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
