using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemOnThis : MonoBehaviour
{
    public Item.ItemType ItemType;

    public virtual void Start()
    {
        
    }

    public virtual void DoesntWork()
    {

    }

    public virtual void FirstUnlockInstance()
    {
        
    }

    public virtual void SubsequentActivation_IfAny()
    {
       
    }

    public void SetItemAsUsed()
    {
        Inventory.Instance.UsedItem();
        if (GetComponent<Used>() == null) this.gameObject.AddComponent<Used>();
    }

    void OnMouseDown()
    {
        if (Inventory.Instance.SelectedItem)
        {
            if (Inventory.Instance.SelectedItem.itemType == ItemType && GetComponent<Used>()==null)//!Inventory.Instance.SelectedItem.Unlocked)
            {
                FirstUnlockInstance();
            }
            else
            {
                if (GetComponent<Used>())
                {
                    SubsequentActivation_IfAny();
                }
                else DoesntWork();
            }
        }
        else
        {
            if (GetComponent<Used>())
            {
                SubsequentActivation_IfAny();
            }
            else
            {
                DoesntWork();
            }
        }

    }
}
