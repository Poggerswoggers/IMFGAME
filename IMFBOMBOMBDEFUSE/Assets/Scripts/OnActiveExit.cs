using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActiveExit : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WinCo());        
    }

    IEnumerator WinCo()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<PlayerManagment>().endWinCanvas.SetActive(true);
    }
}
