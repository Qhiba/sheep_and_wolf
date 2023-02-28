using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using CodeMonkey.Utils;

public class MPathNode
{
    private MGrid<MPathNode> mGrid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public MPathNode cameFromNode;

    private TextMesh debugText;

    public MPathNode(MGrid<MPathNode> mGrid, int x, int y)
    {
        this.mGrid = mGrid;
        this.x = x;
        this.y = y;

        debugText = new TextMesh();

        debugText = UtilsClass.CreateWorldText(fCost.ToString(), GameObject.Find("PathNodes").transform, (mGrid.GetWorldPosition(x, y) + (new Vector3(mGrid.GetCellSize(), mGrid.GetCellSize()) * 0.5f)), 0.2f, 20, Color.white, TextAnchor.MiddleCenter);
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
        if (fCost < int.MaxValue)
        {
            debugText.text = fCost.ToString();
        }
    }

    //public override string ToString()
    //{
    //    Debug.Log(mGrid);
    //    return x + ":" + y;
    //}
}
