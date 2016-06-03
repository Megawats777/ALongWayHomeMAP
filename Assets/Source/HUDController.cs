using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour
{
    /*--References to HUD Components--*/

    [SerializeField]
    private Button closeDescriptionButton;

    [SerializeField]
    private Image descriptionPanel;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Text locationTitle;

    /*--Properties of the class--*/

    // Is a nav point selected
    [HideInInspector]
    public bool isNavPointSelected = false;

    // The selected nav point
    //[HideInInspector]
    public NavPoint selectedNavPoint;

    /*--Description Panel Animation Properties--*/

    // The Description panel position lerp value
    [SerializeField, Range(0.0f, 1.0f)]
    private float panelPositionLerpValue = 0.0f;

    // The starting Y position for the description panel
    private float panelStartYPosition;

    // The starting X position for the description panel
    private float panelStartXPosition;

    // The ending X position for the description panel
    [SerializeField]
    private float panelEndXPosition;

    // The new X position for the description panel
    private float panelNewXPosition;

    // Panel animation rate
    [SerializeField, Range(0.0f, 250)]
    private float panelAnimationRate = 1.0f;

    // Is the description panel opening
    public bool isPanelClosing = false;

    // Use this for initialization
    void Start ()
    {
        // Hide the close description button
        closeDescriptionButton.gameObject.SetActive(false);

        // Set the start X position for the description panel
        panelStartXPosition = descriptionPanel.transform.position.x;

        // Set the start Y position for the description panel
        panelStartYPosition = descriptionPanel.transform.position.y;

        // Set the content of the description text and location title to null
        locationTitle.text = null;
        descriptionText.text = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Control the animation of the description panel
        controlPanelAnimation();

	}

    // Control the animation of the description panel
    private void controlPanelAnimation()
    {
        // If the descriptionPanel is closing decrease the position lerp value
        if (isPanelClosing == true)
        {
            // Decrease the panel position lerp value
            panelPositionLerpValue = Mathf.Clamp(panelPositionLerpValue - 0.01f * panelAnimationRate * Time.deltaTime, 0.0f, 1.0f);
        }

        // If the descriptionPanel is not closing increase the position lerp value
        if (isPanelClosing == false)
        {
            // Increase the panel position lerp value
            panelPositionLerpValue = Mathf.Clamp(panelPositionLerpValue + 0.01f * panelAnimationRate * Time.deltaTime, 0.0f, 1.0f);
        }

        // Set the new position variable the new position
        panelNewXPosition = Mathf.Lerp(panelStartXPosition, panelEndXPosition, panelPositionLerpValue);

        // Set the new X position of the descriptionPanel
        descriptionPanel.transform.position = new Vector3(panelNewXPosition, panelStartYPosition, 0.0f);
    }

    // Show the description
    public void showDescription(GameObject navPointObject)
    {
        isNavPointSelected = true;

        // Get the nav point object
        selectedNavPoint = navPointObject.GetComponent<NavPoint>();
        
        // Set the content of the description panel
        descriptionText.text = selectedNavPoint.locationDescription;

        // Set the content of the location title
        locationTitle.text = selectedNavPoint.locationName;

        // Show the description panel
        isPanelClosing = false;

        // Show the close description panel
        closeDescriptionButton.gameObject.SetActive(true);
    }

    // Hide the description
    public void hideDescription()
    {
        isNavPointSelected = false;

        // Hide the selected nav point location text
        selectedNavPoint.locationText.gameObject.SetActive(false);

        // Remove the nav point reference
        selectedNavPoint = null;

        // Hide the description Panel
        isPanelClosing = true;

        // Hide the close description button
        closeDescriptionButton.gameObject.SetActive(false);
    }
    
    // Exit the App
    public void exitApp()
    {
        Application.Quit();
        print("App Closed");
    }
}
