using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ShowImageController : MonoBehaviour
{
    public GameObject room;
    private GameObject imageNameText;
    public GameObject layoutCanvas;
    public NetworkInterface networkInterface; 

    void Awake()
    {
    }

    void Update()
    {
    }

    public void DisplayMenu()
    {
        var images = Resources.LoadAll("Pano", typeof(Texture)).Cast<Texture>().ToArray();
        foreach (var i in images)
        {
            Debug.Log(i.name);
            var menuItem = Resources.Load("UI/ImageMenuItem");
            GameObject newMenuItem = Instantiate(menuItem, gameObject.transform) as GameObject;
            imageNameText = newMenuItem.transform.Find("ImageName").gameObject;
            imageNameText.GetComponent<UnityEngine.UI.Text>().text = i.name;
        }
    }

    public void OpenImage(String imageName)
    {
        //print(eventData);
        gameObject.SetActive(false);
        layoutCanvas.GetComponent<Image>().enabled = false;
        networkInterface.ShowPano(imageName);
    }
}