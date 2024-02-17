using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [HideInInspector]
    public Item item;

    [SerializeField] bool isUsing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Use()
    {
        if(!isUsing)
        {
            isUsing = true;
            Inventory.Instance.UseItem(item);
        }
        else
        {
            isUsing = false;
            Inventory.Instance.KeepItem(item);
        }
        
    }
}
