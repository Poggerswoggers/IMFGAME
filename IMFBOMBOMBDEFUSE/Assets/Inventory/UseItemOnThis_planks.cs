using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemOnThis_planks : UseItemOnThis
{

    [SerializeField] GameObject tpMarker;
    public AudioSource aS;
    public AudioClip woodbreakSound;

    public int hitpoints;
    [SerializeField] Transform plankRoot;

    public override void Start()
    {
        if(tpMarker !=null) tpMarker.SetActive(false);
    }
    public override void DoesntWork()
    {
        //nothing
    }

    public override void FirstUnlockInstance()
    {
        SubsequentActivation_IfAny();
    }

    public override void SubsequentActivation_IfAny()
    {
        if(hitpoints>0)
        {
            StartCoroutine(DelayCo());
            hitpoints--;
            aS.PlayOneShot(woodbreakSound);
            SetItemAsUsed();
        }
        if(hitpoints == 0)
        {
            if (tpMarker != null)
            {
                tpMarker.SetActive(true);
            }
            gameObject.SetActive(false);

        }
    }
    IEnumerator DelayCo()
    {
        yield return new WaitForSeconds(0.2f);
        plankRoot.GetChild(hitpoints - 1).gameObject.SetActive(false);
    }
   
}
