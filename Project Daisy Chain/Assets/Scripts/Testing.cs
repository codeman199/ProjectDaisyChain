using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Plot plot;
    private Plot tools;

    private void Start()
    {
        plot = new Plot(6, 6, 10f, new Vector3(-60,-30));
        tools = new Plot(5, 2, 10f, new Vector3(10,10));
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            plot.setValue(UtilsClass.GetMouseWorldPosition(), 3);
            tools.setValue(UtilsClass.GetMouseWorldPosition(), 1);
        }

        if(Input.GetMouseButtonDown(1)){
            Debug.Log(plot.getValue(UtilsClass.GetMouseWorldPosition()));
            Debug.Log(tools.getValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
