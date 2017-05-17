using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_points : MonoBehaviour {

    //define masivu, kas satures visus waypointus
    public static Transform[] wpoints;

    private void Awake()
    {
        //uzskaita visus waypointus, kas trodas zem Waypoints objekta
        wpoints = new Transform[transform.childCount];
        for (int i = 0; i < wpoints.Length; i++)
        {
            //ievieto uzskaititus waypointus defineta masiva
            wpoints[i] = transform.GetChild(i);
        }
    }
}
