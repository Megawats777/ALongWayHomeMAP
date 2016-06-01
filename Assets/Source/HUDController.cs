using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour
{
    /*--References to HUD Components--*/

    [SerializeField]
    private Button closeDescriptionButton;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Show the description
    public void showDescription()
    {
        // Get the description from the nav point

        // Set the content of the description panel

        // Show the description panel

        // Show the close description panel
        closeDescriptionButton.gameObject.SetActive(true);
    }

    // Hide the description
    public void hideDescription()
    {
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
