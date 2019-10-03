using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HighScore {
    int id;
    string playerName;
    int score;
    string date;

    public HighScore(int id, string playerName, int score, string date) {
        this.score = score;
        this.playerName = playerName;
        this.id = id;
        this.date = date;
        //GetCurrentDate();
    }

    public int GetId() {
        return id;
    }

    public void SetId(int value) {
        id = value;
    }

    public string GetPlayerName() {
        return playerName;
    }

    public void SetPlayerName(string value) {
        playerName = value;
    }

    public int GetScore() {
        return score;
    }

    public void SetScore(int value) {
        score = value;
    }

    public string GetDate() {
        return date;
    }

    public void SetDate(string value) {
        date = value;
    }


}
