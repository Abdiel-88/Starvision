using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel; // Reference to the InfoPanel
    public TextMeshProUGUI planetNameText; // Reference to the planet name text
    public TextMeshProUGUI planetInfoText; // Reference to the planet info text
    public CameraControl cameraControl; // Reference to the CameraControl script

    private DatabaseManager databaseManager;

    private void Start()
    {
        Debug.Log("UIManager Start");

        if (infoPanel == null)
        {
            Debug.LogError("UIManager: Info Panel reference is not set in the Inspector.");
        }
        if (planetNameText == null)
        {
            Debug.LogError("UIManager: Planet Name Text reference is not set in the Inspector.");
        }
        if (planetInfoText == null)
        {
            Debug.LogError("UIManager: Planet Info Text reference is not set in the Inspector.");
        }
        if (cameraControl == null)
        {
            Debug.LogError("UIManager: Camera Control reference is not set in the Inspector.");
        }

        infoPanel.SetActive(false); // Ensure the panel is hidden at the start
        databaseManager = FindObjectOfType<DatabaseManager>();

        if (databaseManager == null)
        {
            Debug.LogError("UIManager: DatabaseManager not found in the scene.");
        }
        else
        {
            Debug.Log("UIManager: DatabaseManager successfully found.");
        }
    }

    public void ShowInfo(string planetName, string planetInfo)
    {
        Debug.Log("Showing info for: " + planetName);
        planetNameText.text = planetName;
        planetInfoText.text = planetInfo;
        Debug.Log("Planet Name Text: " + planetNameText.text);
        Debug.Log("Planet Info Text: " + planetInfoText.text);
        infoPanel.SetActive(true);
        Debug.Log("Info panel set active");
        // Set fixed font size here
        planetInfoText.fontSize = 20; // Change this value to your desired font size
        AdjustRectTransformToFit(planetInfoText);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
        Debug.Log("Info panel hidden");
    }

    public void OnPlanetButtonClicked(GameObject planet)
    {
        Debug.Log("Planet button clicked: " + planet.name);

        if (cameraControl == null)
        {
            Debug.LogError("UIManager: CameraControl reference is not set.");
            return;
        }

        cameraControl.SetTarget(planet.transform);

        if (databaseManager == null)
        {
            Debug.LogError("UIManager: DatabaseManager reference is not set.");
            ShowInfo(planet.name, "Planet data not available.");
            return;
        }

        PlanetData planetData = databaseManager.GetPlanetByName(planet.name);
        if (planetData != null)
        {
            Debug.Log("Planet data found: " + planetData.Name);
            ShowInfo(planetData.Name, planetData.Biography);
        }
        else
        {
            Debug.Log("Planet data not found for: " + planet.name);
            ShowInfo(planet.name, "Planet data not found.");
        }
    }

    public void OnOrbitCameraButtonClicked()
    {
        Debug.Log("Orbit camera button clicked");

        if (cameraControl == null)
        {
            Debug.LogError("UIManager: CameraControl reference is not set.");
            return;
        }

        cameraControl.ResetCamera();
        HideInfo();
    }

    private void AdjustRectTransformToFit(TextMeshProUGUI textMeshProUGUI)
    {
        // Adjust RectTransform to fit the text content
        RectTransform rectTransform = textMeshProUGUI.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, textMeshProUGUI.preferredHeight);
    }
}
