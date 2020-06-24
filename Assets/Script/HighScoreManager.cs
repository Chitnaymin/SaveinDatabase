using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour {

    string connectionString;
    private List<HighScore> highScores = new List<HighScore>();

    public InputField PlayerName;
    public InputField Score;

    public Text result;

    void Start() {
        connectionString = "URI=file:" + Application.dataPath + "/database/assets.sqlite";
    }

    public void btnSave() {
        string pName = PlayerName.text;
        int i = 0;
        try {
            i = int.Parse(Score.text);
        } catch (Exception e) {
            Debug.Log("Score Type CastError" + e);
        }
        InsertScore(pName, i);
    }

    public void btnLoad() {
        List<HighScore> player = GetScores();
        string res = "";
        foreach (var ele in player) {
            res += ele.GetPlayerName() + " has " + ele.GetScore() + "\n";
        }
        result.text = res;
    }

    void InsertScore(string name, int newScore) {
        string todayDate = FunDateTimeAccess.GetTodayDate();
        string sqlQuary = String.Format("INSERT INTO HighScores(Name, Score,date) VALUES (\"{0}\",\"{1}\",\"{2}\");", name, newScore, todayDate);
        SQLInput(sqlQuary);
    }

    private void DeleteScore(int id) {
        string sql = String.Format("DELETE FROM HighScores WHERE PlayerID =\"{0}\";", id);
        SQLInput(sql);
    }

    private List<HighScore> GetScores() {
        highScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                string sqlQuary = "SELECT * FROM HighScores";
                dbCmd.CommandText = sqlQuary;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        print(reader.GetString(1) + " has " + reader.GetInt32(2));
                        highScores.Add(new HighScore(
                            reader.GetInt32(0) ,
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3)
                            ));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        return highScores;
    }

    void SQLInput(string sql) {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                dbCmd.CommandText = sql;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
}
