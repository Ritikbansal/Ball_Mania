using System.Collections;
using UnityEngine;

[System.Serializable]
public struct GridCoords{
    public int row;
    public int col;
    public GridCoords(int r,int c)
    {
        row=r;
        col=c;
    }
    public override string ToString()
    {
        return "coords "+row+","+col;
    }
}
