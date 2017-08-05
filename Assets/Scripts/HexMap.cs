using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

    public Transform hexSupport;
    public float xratio;
    public float yratio;
    public float startX;
    public float startY;
    private Dictionary<Vector2, Transform> hexMap = new Dictionary<Vector2, Transform>();
	// Use this for initialization
	void Start () {
		//generateHexMap

        for(int x = 0; x < 50000; ++x)
        {
            for (int y = 0; y < 500000; ++y)
            {
                Transform transform = Instantiate(hexSupport);
                float delta = y % 2 == 1 ? xratio / 2 : 0;
                transform.SetPositionAndRotation(new Vector3(xratio * x - delta, 0, y * yratio ), new Quaternion());
                hexMap.Add(new Vector2(x, y), transform);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
