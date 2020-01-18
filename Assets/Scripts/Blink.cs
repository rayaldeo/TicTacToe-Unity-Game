using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public GameObject xsAndOs;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Children Count: " + xsAndOs.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
      StartCoroutine("BlinkElements");
    }

    IEnumerator BlinkElements()
    {
        int selectedObject = Random.Range(0, xsAndOs.transform.childCount);
        //Debug.Log("Chosen Number: " + selectedObject);
        xsAndOs.transform.GetChild(selectedObject).gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        xsAndOs.transform.GetChild(selectedObject).gameObject.SetActive(false);
    }
}

