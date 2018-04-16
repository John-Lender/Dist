using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Distance : MonoBehaviour {
    private float llatitude2 = 43.028150f;
    private float llongitude2 = 131.895929f;
    private float latitude1;
    private float longitude1;
    private float latitude2;
    private float longitude2;
    private float cl1;
    private float cl2;
    private float sl1;
    private float sl2;
    private float c_delta;
    private float s_delta;
    private float x;
    private float y;
    private float ad;
    private int Radius = 6372795;
    public static Distance Instance { set; get; }
    public float dist;

   public void Awake()
    {
        Instance = this;
    }

	
	void Start () {
        latitude2 = llatitude2 * Mathf.PI / 180;
        longitude2 = llongitude2 * Mathf.PI / 180;
        cl2 = Mathf.Cos(latitude2);
        sl2 = Mathf.Sin(latitude2);
    }
	
	void Update () {
        latitude1 = GPS.Instance.latitude * Mathf.PI / 180;
        longitude1 = GPS.Instance.longitude * Mathf.PI / 180;
        cl1 = Mathf.Cos(latitude1);
        sl1 = Mathf.Sin(latitude1);
        c_delta = Mathf.Cos(longitude2 - longitude1);
        s_delta = Mathf.Sin(longitude2 - longitude1);
        y = Mathf.Sqrt(Mathf.Pow(cl2 * s_delta, 2.0f) + Mathf.Pow(cl1 * sl2 - sl1 * cl2 * c_delta, 2.0f));
        x = sl1 * sl2 + cl1 * cl2 * c_delta;
        ad = Mathf.Atan2(y, x);
        dist = Mathf.Round(ad * Radius);

        
    }
}
