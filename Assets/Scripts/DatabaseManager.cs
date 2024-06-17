using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.IO;
using System.Linq;

public class DatabaseManager : MonoBehaviour
{
    private string dbPath;
    private SQLiteConnection dbConnection;

    void Awake()
    {
        dbPath = Path.Combine(Application.streamingAssetsPath, "planetinfo.db");
        dbConnection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Connected to database at " + dbPath);
    }

    public List<PlanetData> GetPlanets()
    {
        return dbConnection.Table<PlanetData>().ToList();
    }

    public PlanetData GetPlanetByName(string name)
    {
        return dbConnection.Table<PlanetData>().Where(p => p.Name == name).FirstOrDefault();
    }

    void OnDestroy()
    {
        dbConnection.Close();
    }
}

public class PlanetData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }

    public override string ToString()
    {
        return Biography;
    }
}
