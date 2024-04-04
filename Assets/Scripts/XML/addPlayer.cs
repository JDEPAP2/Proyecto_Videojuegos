using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class addPlayer : MonoBehaviour
{
    public DatosJugador datos;
    public InputField txt;
    public UtilsXML db;
    public Text alert;

    public void AddP(string Nombreescena)
    {
        string name = txt.text;
        string test = name;

        while(test.Contains(" "))
        {
            test = test.Replace(" ", "");
        }

        if (test.Equals("")){
            alert.text = "No dejes el campo vacio";
            return;
        }

        if(name.Length != 4)
        {
            alert.text = "El alias debe contener 4 caracteres";
            return;
        }

        if (db.existNameinXML(name))
        {
            alert.text = "Ya existe alguien con este alias registrado, intenta con otro";
        }
        else
        {
            alert.text = "";
            int scoreTotal = datos.scores1 + datos.scores2 + datos.scores3 + datos.scores4;
            int tiempoTotal = datos.tiempo1 + datos.tiempo2 + datos.tiempo3 + datos.tiempo4;
            db.CreateNewPlayer(name, scoreTotal, TimeFormat(tiempoTotal));
            db.SaveByXML();
            SceneManager.LoadScene(Nombreescena);
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
