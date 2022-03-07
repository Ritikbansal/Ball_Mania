using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertor 
{
    public static char ToChessCol(int col)
    {
        char cCol='a';
        int iCol=cCol+col;
        return (char) iCol;
    }
    public static char ToChessRow(int row)
    {
        char cRow='1';
        int iRow=cRow+row;
        return (char) iRow;
    }
   public static Ray ScreenPointToRay(Vector3 pointPosition)
   {
       return GameManager.Instance.MainCamera.ScreenPointToRay(pointPosition);
   }
}
