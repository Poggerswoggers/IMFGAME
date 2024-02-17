using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventory: MonoBehaviour
{
    public static Inventory Instance { get { return _instance; } }
    private static Inventory _instance;
    List<Item> itemList;
    public GameObject itemPic;
    public Transform InventoryPanel;
    
    public Sprite[] Thumbnails;
    public GameObject[] SelectedGameObject;

    public GameObject cursorItem;
    [HideInInspector]
    public Item SelectedItem;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
    }

    void Start()
    {
        itemList = new List<Item>();
        //Debug.Log("Inventory");
    }


    private void Update()
    {
        //Cancel the selection
        if (Input.GetMouseButton(1))
        {
            cursorItem.gameObject.SetActive(false);
            if(SelectedItem) SelectedItem.UI_Item.SetActive(true);
            SelectedItem = null;
        }

        if(Input.GetMouseButtonDown(0)  && SelectedItem !=null)
        {
            if(SelectedGameObject[((int)SelectedItem.itemType)].GetComponent<Animator>())
            {
                SelectedGameObject[((int)SelectedItem.itemType)].GetComponent<Animator>().SetTrigger("swing");
            }
        }
    }
    public void UseItem(Item item)
    {
        if(SelectedItem) SelectedItem.UI_Item.SetActive(true);
        
        SelectedItem = item;
        for(int i=0; i<SelectedGameObject.Length; i++)
        {
            if (i == (int)item.itemType)
            {
                SelectedGameObject[i].SetActive(true);
            }
            else
            {
                SelectedGameObject[i].SetActive(false);
            }
            //Debug.Log((int)item.itemType);
        }
        //SelectedGameObject[(int)item.itemType].SetActive(true);
        //CursorImage.sprite = SelectedThumbnails[(int)item.itemType];
        //cursorItem.gameObject.SetActive(true);
        //item.UI_Item.SetActive(false);
    }
    
    public void KeepItem(Item item)
    {
        SelectedItem = null;
        SelectedGameObject[(int)item.itemType].SetActive(false);
    }


    public void UsedItem()
    {
        //cursorItem.gameObject.SetActive(false);

        SelectedItem.numberOfUse--;
        if (SelectedItem.numberOfUse <= 0)
        {
            Destroy(SelectedItem.UI_Item);
            SelectedGameObject[((int)SelectedItem.itemType)].SetActive(false);
        }
        else SelectedItem.UI_Item.SetActive(true);

        //SelectedItem = null;
    }

    public void AddItem(Item item)
    {
        GameObject newitem = Instantiate(itemPic, InventoryPanel);
        newitem.GetComponent<UseItem>().item = item;
        newitem.GetComponentsInChildren<Image>()[0].sprite = Thumbnails[(int)item.itemType];
        item.UI_Item = newitem;
        itemList.Add(item);
    }
}
