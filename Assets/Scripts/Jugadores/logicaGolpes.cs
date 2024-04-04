using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaGolpes : MonoBehaviour
{
    public bool golpe=false;
    public Rigidbody rJugador;
    public vidaManager v;
    private int i = 0;

    void Update()
    {
        if(golpe)
        {
            rJugador.AddForce(new Vector3(0,1,3),ForceMode.Impulse);
            i++;
            if (i == 2)
            {
                v.vida++;
                i = 0;
                golpe = false;
            }
        }
    }
}
