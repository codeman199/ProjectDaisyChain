using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Plot
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] plotArray;
    private TextMesh[,] debugTextArray;

    public Plot(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        plotArray = new int[width, height];
        debugTextArray = new TextMesh[width,height];

        for (int i = 0; i < plotArray.GetLength(0); i++){
            for(int j = 0; j < plotArray.GetLength(1); j++){
                debugTextArray[i,j] = UtilsClass.CreateWorldText(plotArray[i,j].ToString(), null, GetWorldPosition(i,j) + new Vector3(cellSize,cellSize)*0.5f,30,Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i+1, j), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void setValue(int x, int y, int value) {
        if(x >= 0 && y >= 0 && x < width && y < height){
            plotArray[x,y] = value;
            debugTextArray[x,y].text = plotArray[x,y].ToString();
        }
    }

    public void setValue(Vector3 worldPosition, int value){
        int x,y;
        GetXY(worldPosition, out x, out y);
        setValue(x,y,value);
    }

    public int getValue(int x, int y){
        if(x >= 0 && y >= 0 && x < width && y < height){
            return plotArray[x,y];
        } else {
            return -1;
        }
    }

    public int getValue(Vector3 worldPosition){
        int x,y;
        GetXY(worldPosition, out x, out y);
        return getValue(x,y);
    }
}
