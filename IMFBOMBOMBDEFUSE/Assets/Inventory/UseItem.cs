using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [HideInInspector]
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Use()
    {
        Inventory.Instance.UseItem(item);
    }
}
