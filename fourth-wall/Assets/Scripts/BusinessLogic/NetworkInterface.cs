using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInterface : Photon.MonoBehaviour
{
    private GameObject photoSphere;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowPano(string imagename)
    {
        print("LOAD PANO!");
        photonView.RPC("LoadPano", PhotonTargets.All, (string)imagename);
    }

    // defining a method that can be called by other clients:
    [PunRPC]
    public void LoadPano(string panoName)
    {
        photoSphere = GameObject.Find("PhotoSphere");
        Texture panoTexture = (Texture)Resources.Load("Pano/" + panoName, typeof(Texture)) as Texture;
        photoSphere.GetComponent<Renderer>().material.mainTexture = panoTexture;
    }
}
