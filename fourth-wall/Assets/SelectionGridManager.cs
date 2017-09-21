using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionGridManager : MonoBehaviour {

    public GameObject room;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayMenu()
    {
        var images = Resources.LoadAll("Pano", typeof(Texture)).Cast<Texture>().ToArray();
        foreach (var i in images)
        {
            Debug.Log(i.name);
            var menuItem = Resources.Load("UI/ImageMenuItem");
            GameObject newMenuItem = Instantiate(menuItem, gameObject.transform) as GameObject;
            ShowImageController showImageController = newMenuItem.GetComponent(typeof (ShowImageController)) as ShowImageController;
            room = GameObject.Find("Room");
            showImageController.appManager = room.GetComponent("AppManager") as AppManager;
            showImageController.setMenuItemName(i.name);
        }
    }
}
