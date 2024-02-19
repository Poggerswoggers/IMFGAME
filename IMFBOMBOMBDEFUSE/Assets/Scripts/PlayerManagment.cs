using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManagment : MonoBehaviour
{
    [SerializeField] GameObject zoomCam;
    [SerializeField] Camera normalCam;
    bool zoom;

    [SerializeField] TextMeshProUGUI bombtext;
    int bombDiffused;

    [SerializeField] int bombs;


    //End game
    public GameObject endWinCanvas;
    public GameObject endLoseCanvas;
    [SerializeField] GameObject exitTp;

    public AudioSource aS;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            zoom = !zoom;
            zoomCam.SetActive(zoom);
        }
    }

    public void BombDiffuse(bool con)
    {
        bombDiffused++;
        bombtext.text = "BOMB DIFFUSED:" + bombDiffused.ToString() + "/" + bombs;

        if(bombDiffused == bombs)
        {
            exitTp.SetActive(true);
        }

        if(!con)
        {
            endLoseCanvas.SetActive(true);
            aS.enabled = false;
        }
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
