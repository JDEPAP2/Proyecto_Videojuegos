using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;//If you want to use the BinaryFormatter class, must type this namespace first
using System.IO;//If you want to use the FIle class and FileStream class, you have to use this namespace
//IO: Input / Output

using System.Xml;

public class UtilsXML : MonoBehaviour
{
    static ArrayList playerList = new ArrayList();

    void Start()
    {
        SaveByXML();
        LoadByXML();
    }

    public void CreateNewPlayer(string playerName, int playerScore, string playerTime)
    {
        PlayerDB newPlayer = new PlayerDB(playerName, playerScore, playerTime);
        if (existNameinXML(playerName))
            return;
        foreach (PlayerDB player in playerList)
        {
            if (player.PlayerName == newPlayer.PlayerName)
            {
                newPlayer.PlayerName = newPlayer.PlayerName + "_" + playerList.Count;
            }

        }
        playerList.Add(newPlayer);
    }

    public void SaveByXML()
    {
        if (File.Exists(Application.dataPath + "/Data.xml"))
        {
            ArrayList PreCharged = LoadByXML();

            foreach (PlayerDB player in PreCharged)
            {
                playerList.Add(player);
            }

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Laderboard");
            xmlDoc.AppendChild(root);

            foreach (PlayerDB player in playerList)
            {
                XmlElement playerNode = xmlDoc.CreateElement("Player");
                playerNode.SetAttribute("Name", player.PlayerName);
                root.AppendChild(playerNode);

                XmlElement playerScore = xmlDoc.CreateElement("Score");
                playerScore.InnerText = player.PlayerScore.ToString();
                playerNode.AppendChild(playerScore);

                XmlElement playerTime = xmlDoc.CreateElement("Time");
                playerTime.InnerText = player.PlayerTime;
                playerNode.AppendChild(playerTime);
            }

            File.Delete(Application.dataPath + "/Data.xml");
            xmlDoc.Save(Application.dataPath + "/Data.xml");
            playerList.Clear();
        }
        else
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Laderboard");
            xmlDoc.AppendChild(root);

            foreach (PlayerDB player in playerList)
            {
                XmlElement playerNode = xmlDoc.CreateElement("Player");
                playerNode.SetAttribute("Name", player.PlayerName);
                root.AppendChild(playerNode);

                XmlElement playerScore = xmlDoc.CreateElement("Score");
                playerScore.InnerText = player.PlayerScore.ToString();
                playerNode.AppendChild(playerScore);

                XmlElement playerTime = xmlDoc.CreateElement("Time");
                playerTime.InnerText = player.PlayerTime;
                playerNode.AppendChild(playerTime);
            }
            xmlDoc.Save(Application.dataPath + "/Data.xml");
        }
    }

    public bool existNameinXML(string name)
    {
        string filePath = Application.dataPath + "/Data.xml";

        if (File.Exists(filePath))
        {
            ArrayList PreCharged = LoadByXML();
            foreach (PlayerDB player in PreCharged)
            {
                if (name == player.playerName)
                    return true;
            }
        }
        return false;
    }

    public ArrayList LoadByXML()
    {
        string filePath = Application.dataPath + "/Data.xml";
        ArrayList playerList = new ArrayList();

        if (File.Exists(filePath))
        { 

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                PlayerDB player = new PlayerDB();
                player.PlayerName = node.Attributes["Name"].Value;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "Score")
                    {
                        player.PlayerScore = int.Parse(childNode.InnerText);
                    }
                    else if (childNode.Name == "Time")
                    {
                        player.PlayerTime = childNode.InnerText;
                    }
                }
                playerList.Add(player);
            }
            // foreach (PlayerDB player in playerList)
            // {
            //     Debug.Log(player.PlayerName + " " + player.PlayerScore + " " + player.PlayerTime);
            // }
            return playerList;

        }
        else
        {
            Debug.Log("NOT FOUNDED");
            return null;
        }
    }
}
