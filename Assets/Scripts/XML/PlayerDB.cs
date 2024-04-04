using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDB
{
    
    public string playerName;
    public int playerScore;
    public string playerTime;
    
    public PlayerDB(string playerName, int playerScore, string playerTime)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
        this.playerTime = playerTime;
    }

    public PlayerDB()
    {
        this.playerName = "Player_01";
        this.playerScore = 10000;
        this.playerTime = "00:00:00";
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
        }
    }

    public string PlayerTime
    {
        get
        {
            return playerTime;
        }

        set
        {
            playerTime = value;
        }
    }

    public override string ToString()
    {
        return "Player Name: " + playerName + " Player Score: " + playerScore + " Player Time: " + playerTime;
    }
}