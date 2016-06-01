using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavPoint : MonoBehaviour
{
    /*--Properties of the class--*/

    // The location of the nav point
    [SerializeField]
    private string locationName;

    // Reference to the text of the Nav point
    [SerializeField]
    private Text locationText;

    // Is the point selected?
    private bool isPointSelected = false;

    // Reference to the HUDController
    private HUDController hudController;

    // Use this for initialization
    void Start()
    {
        // Get the HUDController
        hudController = FindObjectOfType<HUDController>();

        // Set the text of the location
        locationText.text = locationName;

        // Disable the text component
        locationText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When this nav point is clicked
    private void OnMouseDown()
    {
        print("Nav Point Selected");

        isPointSelected = true;
    }

    // When the nav point is hovered show the location text
    private void OnMouseEnter()
    {
        locationText.gameObject.SetActive(true);
    }

    // When the mouse stops hovering the nav point
    private void OnMouseExit()
    {
        // If the point is not selected then hide the location text
        if (isPointSelected == false)
        {
            locationText.gameObject.SetActive(false);
        }
    }
}
