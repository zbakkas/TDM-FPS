using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="scrip object/item")]
public class ittttem : ScriptableObject
{


    [Header("only game playe")]
    public TileBase tile;
    public ItemType type;
    public ActionType actiontype;
    public Vector2Int range = new Vector2Int(5, 4);
    [Header("only UI")]
    public bool stackible =true;
    [Header("both")]
    public Sprite image;

}

public enum ItemType
{
    buildingBlock,
    tool
}
public enum ActionType
{
    ding,
    mnie
}
