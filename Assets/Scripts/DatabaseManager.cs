using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    private List<PlanetData> planets;

    void Awake()
    {
        StartCoroutine(LoadJsonData());
    }

    private IEnumerator LoadJsonData()
    {
        string filePath = Application.streamingAssetsPath + "/planetinfo.json";
        Debug.Log("Loading JSON file from path: " + filePath);

        UnityWebRequest request;
        #if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL requires a different path handling
            request = UnityWebRequest.Get(filePath);
        #else
            // Editor and standalone use file:// prefix
            request = UnityWebRequest.Get("file://" + filePath);
        #endif

        Debug.Log("Request URL: " + request.url);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("DatabaseManager: JSON file not found or error in request at " + filePath + " - " + request.error);
        }
        else
        {
            string dataAsJson = request.downloadHandler.text;
            Debug.Log("DatabaseManager: JSON data successfully loaded.");
            Debug.Log("JSON Data: " + dataAsJson);

            try
            {
                PlanetList loadedData = JsonUtility.FromJson<PlanetList>(dataAsJson);
                planets = loadedData.planets;

                if (planets != null)
                {
                    Debug.Log("DatabaseManager: Loaded " + planets.Count + " planets.");
                    foreach (var planet in planets)
                    {
                        Debug.Log("Planet: " + planet.Name + ", Biography: " + planet.Biography);
                    }
                }
                else
                {
                    Debug.LogError("DatabaseManager: Failed to load planets from JSON.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DatabaseManager: Exception while parsing JSON - " + ex.Message);
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
