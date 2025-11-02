using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlayTutScript : MonoBehaviour
{
    public GameObject nextText;
    public GameObject me;
    public GameObject enableThis;
    public GameObject disableThis;

    void Start()
    {
        enableThis.SetActive(true);
        disableThis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            me.SetActive(false);
            nextText.SetActive(true);
        }
    }
}
