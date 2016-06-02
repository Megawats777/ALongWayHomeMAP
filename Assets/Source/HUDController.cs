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

    /*--Properties of the class--*/

    // Is a nav point selected
    [HideInInspector]
    public bool isNavPointSelected = false;

    // The selected nav point
    //[HideInInspector]
    public NavPoint selectedNavPoint;

    // Use this for initialization
    void Start ()
    {
        // Hide the close description button
        closeDescriptionButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Show the description
    public void showDescription(GameObject navPointObject)
    {
        isNavPointSelected = true;

        // Get the nav point object
        selectedNavPoint = navPointObject.GetComponent<NavPoint>();
        
        // Set the content of the description panel
        descriptionText.text = selectedNavPoint.locationDescription;

        // Show the description panel


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
