using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text tx;
    public bool activo;
    public int i;
    
    
    void Start()
    {
        i = 0;
        activo = true;

        StartCoroutine(Contador());

    }


    private void WaitForSeconds(int v) => throw new NotImplementedException();

    // Update is called once per frame
    IEnumerator Contador()
    {
        while (activo) {
            yield return new WaitForSeconds(1);
            tx.text = TimeFormat(i);
            i += 1;
        }
        
        
        
    }

    public string TimeFormat(int s)
    {
        int hora = (int)(s / 3600);
        int minuto = (int)((s - (hora * 3600)) / 60);
        int segundo = s - (hora * 3600) - (minuto * 60);

        string thora = hora < 10 ? "0" + hora : "" + hora;
        string tmin = minuto < 10 ? "0" + minuto : "" + minuto;
        string tseg = segundo < 10 ? "0" + segundo : "" + segundo;

        return thora + ":" + tmin + ":" + tseg;

    }

}
