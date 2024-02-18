using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialLock : MonoBehaviour
{
    [SerializeField] GameObject dialLock;
    [SerializeField] Transform dialRotPoint;
    public bool active;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            dialRotPoint.Rotate(Vector3.up * speed *Input.GetAxis("Mouse ScrollWheel")  * Time.deltaTime);

            Debug.Log("up");
        }
    }

    private void OnMouseDown()
    {

        if (!dialLock.activeSelf)
        {
            dialLock.SetActive(true);
            active = true;
        }
        else
        {
            dialLock.SetActive(false);
            active = false;
        }
    }



}
