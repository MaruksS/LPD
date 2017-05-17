using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour {

    public static int waves;
    bool grown = false;
    void Start()
    {
        transform.Rotate(-90, 0, 0);
        waves = 0;
    }
    // Update is called once per frame
    void Update () {
        if (grown == true)
        {
            return;
        }
        else
        {
            if (waves >= 5)
            {
                Resources.wood++;
                grown = true;
                return;
            }
        }
    }
}
