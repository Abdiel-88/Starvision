using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    private string jsonPath;
    private List<PlanetData> planets;

    void Awake()
    {
        StartCoroutine(LoadJsonData());
    }

    private IEnumerator LoadJsonData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "planetinfo.json");

        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            UnityWebRequest request = UnityWebRequest.Get(filePath);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("DatabaseManager: JSON file not found or error in request at " + filePath);
            }
            else
            {
                string dataAsJson = request.downloadHandler.text;
                PlanetList loadedData = JsonUtility.FromJson<PlanetList>(dataAsJson);
                planets = loadedData.planets;

                if (planets != null)
                {
                    Debug.Log("DatabaseManager: Loaded " + planets.Count + " planets.");
                }
                else
                {
                    Debug.LogError("DatabaseManager: Failed to load planets from JSON.");
                }
            }
        }
        else
        {
            if (File.Exists(filePath))
            {
                Debug.Log("DatabaseManager: Found JSON file at " + filePath);
                string dataAsJson = File.ReadAllText(filePath);
                PlanetList loadedData = JsonUtility.FromJson<PlanetList>(dataAsJson);
                planets = loadedData.planets;

                if (planets != null)
                {
                    Debug.Log("DatabaseManager: Loaded " + planets.Count + " planets.");
                }
                else
                {
                    Debug.LogError("DatabaseManager: Failed to load planets from JSON.");
                }
            }
            else
            {
                Debug.LogError("DatabaseManager: JSON file not found at " + filePath);
            }
        }
    }

    public List<PlanetData> GetPlanets()
    {
        return planets;
    }

    public PlanetData GetPlanetByName(string name)
    {
        Debug.Log("Checking planet: " + name);
        if (planets == null)
        {
            Debug.LogError("DatabaseManager: Planets list is null.");
            return null;
        }
        return planets.Find(p => p.Name == name);
    }

    public void ReceivePlanetsData(string jsonData)
    {
        planets = JsonUtility.FromJson<PlanetList>(jsonData).planets;
        Debug.Log("Received planets data: " + planets.Count);
    }

    public void ReceivePlanetData(string jsonData)
    {
        PlanetData planet = JsonUtility.FromJson<PlanetData>(jsonData);
        Debug.Log("Received planet data: " + planet.Name);
    }
}

[System.Serializable]
public class PlanetList
{
    public List<PlanetData> planets;
}

[System.Serializable]
public class PlanetData
{
    public int Id;
    public string Name;
    public string Biography;
}
