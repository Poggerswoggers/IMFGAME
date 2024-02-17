using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemOnThis_planks : UseItemOnThis
{
    [SerializeField] GameObject tpMarker;
    public AudioSource aS;
    public AudioClip woodbreakSound;

    public override void Start()
    {
        tpMarker.SetActive(false);
    }
    public override void DoesntWork()
    {
        //nothing
    }

    public override void FirstUnlockInstance()
    {
        aS.PlayOneShot(woodbreakSound);
        tpMarker.SetActive(true);
        gameObject.SetActive(false);

        SetItemAsUsed();
    }

    public override void SubsequentActivation_IfAny()
    {
       //nothing
    }
   
}
