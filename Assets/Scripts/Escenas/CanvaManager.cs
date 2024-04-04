using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{
    public GameObject panelM1, panelM2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarPanel2()
    {
        panelM2.SetActive(true);
        panelM1.SetActive(false);
    }
}
