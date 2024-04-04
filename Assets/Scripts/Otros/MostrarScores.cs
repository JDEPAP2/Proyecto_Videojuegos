using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarScores : MonoBehaviour
{
    public Text txtN, txtT, txtS;
    public GameObject txtA;
    public UtilsXML db;
    private Dictionary<int, PlayerDB> map;
    private List<PlayerDB> listP;

    void Start()
    {
        map = new Dictionary<int, PlayerDB>();
        listP = new List<PlayerDB>();

        ArrayList players = db.LoadByXML();
        
        if (players.Count == 0)
        {
            txtA.SetActive(true);
            return;
        }

        foreach (PlayerDB obj in players)
        {
            listP.Add(obj);
        }

        listP.Sort(
            (x, y) => y.playerScore.CompareTo(x.playerScore));

        int i = 0;
        foreach (PlayerDB obj in listP)
        {
            i++;
            map.Add(i, obj);
        }
        string resN = "", resT = "", resS = "";
        foreach (KeyValuePair<int, PlayerDB> obj in map)
        {

            resN += $"{obj.Key}.{obj.Value.PlayerName}\n";
            resT += $"{obj.Value.playerTime}\n";
            resS += $"{obj.Value.playerScore}\n";
        }
        txtN.text = resN;
        txtT.text = resT;
        txtS.text = resS;
        txtA.SetActive(false);
    }



}
