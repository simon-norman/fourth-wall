using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : Photon.MonoBehaviour
{
    public UnityEngine.UI.Button selectImage;
    public GameObject imageSelectionGrid;
    public ShowImageController showImageController;
    public GameObject layoutCanvas;
    private bool menuGenerated = false; 

    // Use this for initialization
    void Start () {
        //next, any of these will work:
        selectImage.onClick.AddListener(OpenImageMenu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OpenImageMenu()
    {
        layoutCanvas.GetComponent<Image>().enabled = true;
        imageSelectionGrid.SetActive(true);
        if(menuGenerated == false)
        {
            showImageController.DisplayMenu();
            menuGenerated = true;
        }

    }
}
