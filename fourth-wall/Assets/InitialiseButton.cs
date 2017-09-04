using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseButton : Photon.MonoBehaviour
{
    public UnityEngine.UI.Button loadPanoButton;
    public Material pano;

    // Use this for initialization
    void Start () {
        //next, any of these will work:
        loadPanoButton.onClick.AddListener(LoadPano);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadPano()
    {
        print("LOAD PANO!");
        //  pano = (Material)Resources.Load("360material", typeof(Material)) as Material;
        // RenderSettings.skybox = pano;
        photonView.RPC("LoadPano", PhotonTargets.All, (string)"360material");
    }

    // defining a method that can be called by other clients:
    [PunRPC]
    public void LoadPano(string panoName)
    {
        pano = (Material)Resources.Load(panoName, typeof(Material)) as Material;
        RenderSettings.skybox = pano;
        //Debug.Log(string.Format("RPC: 'OnAwakeRPC' Parameter: {0} PhotonView: {1}", myParameter, this.photonView));
    }
}
