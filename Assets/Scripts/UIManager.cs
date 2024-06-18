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
        if (infoPanel == null || planetNameText == null || planetInfoText == null || cameraControl == null)
        {
            Debug.LogError("UIManager: One or more references are not set in the Inspector.");
            return;
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
        planetNameText.text = planetName;
        planetInfoText.text = planetInfo;
        infoPanel.SetActive(true);
        // Set fixed font size here
        planetInfoText.fontSize = 20; // Change this value to your desired font size
        AdjustRectTransformToFit(planetInfoText);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
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
            ShowInfo(planetData.Name, planetData.Biography);
        }
        else
        {
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
