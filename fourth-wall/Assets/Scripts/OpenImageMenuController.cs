using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenImageMenuController : Photon.MonoBehaviour
{
    public UnityEngine.UI.Button setHostButton;
    public GameObject imageSelectionGrid;
    public SelectionGridManager selectionGridManager;

    // Use this for initialization
    void Start () {
        //next, any of these will work:
        setHostButton.onClick.AddListener(OpenImageMenu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OpenImageMenu()
    {
        imageSelectionGrid.SetActive(true);
        selectionGridManager.DisplayMenu();
    }
}
