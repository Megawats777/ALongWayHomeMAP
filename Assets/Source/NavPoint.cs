using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavPoint : MonoBehaviour
{
    /*--Properties of the class--*/

    // The location of the nav point
    public string locationName;

    // The description for this location
    public string locationDescription;

    // Reference to the text of the Nav point
    [HideInInspector]
    public Text locationText;

    // Reference to the NavPoint mesh
    [SerializeField]
    private GameObject navPointMesh;

    // Can the NavPointMesh rotate
    [HideInInspector]
    public bool canNavPointMeshRotate;

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
        // Rotate the NavPointMesh
        rotateNavPointMesh();
    }

    // Rotate the NavPointMesh
    private void rotateNavPointMesh()
    {
        // If the nav point mesh can rotate
        if (canNavPointMeshRotate == true)
        {
            // If the nav mesh point has been set
            if (navPointMesh)
            {
                navPointMesh.transform.Rotate(transform.forward * 75.0f * Time.deltaTime);
            }
        }
    }

    // When this nav point is clicked
    private void OnMouseDown()
    {
        // If a nav point is not currently selected then select this nav point
        if (hudController.isNavPointSelected == false)
        {
            print("Nav Point Selected");
            hudController.isNavPointSelected = true;
            hudController.showDescription(gameObject);
        }
    }

    // When the nav point is hovered show the location text
    private void OnMouseEnter()
    {
        // If no nav point is currently selected then show the name of this area
        if (hudController.isNavPointSelected == false)
        {
            locationText.gameObject.SetActive(true);

            // Let the nav point mesh rotate
            canNavPointMeshRotate = true;
        }
    }

    // When the mouse stops hovering the nav point
    private void OnMouseExit()
    {
        if (hudController.isNavPointSelected == false)
        {
            locationText.gameObject.SetActive(false);

            // Do not let the nav point mesh rotate
            canNavPointMeshRotate = false;
        }
    }
}
