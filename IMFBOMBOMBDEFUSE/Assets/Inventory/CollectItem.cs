using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    //public Color mouseOverColor = Color.blue;
    //private Color originalColor;
    //public GameObject Outline;

    public AudioSource audio;
    public AudioClip clip;
    private void Start()
    {
        //r = GetComponent<Renderer>();
        //originalColor = r.material.color;
    }

    void OnMouseEnter()
    {
        //if (Outline) Outline.SetActive(true);
        //else r.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {

        //if (Outline) Outline.SetActive(false);
        //else r.material.color = originalColor;
    }

    void OnMouseDown()
    {
        Inventory.Instance.AddItem(GetComponent<Item>());
        if(audio) audio.PlayOneShot(clip);
        this.gameObject.SetActive(false);
    }
}
