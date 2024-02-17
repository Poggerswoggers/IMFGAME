using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    public enum ItemType
    {
        Wirecutter,
        BattleAxe
    }

    public int numberOfUse = 1;
    public ItemType itemType;

    [HideInInspector]
    public GameObject UI_Item;

}
