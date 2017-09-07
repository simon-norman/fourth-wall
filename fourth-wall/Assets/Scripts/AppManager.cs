using System.Collections;
using UnityEngine;

    public class AppManager : Photon.MonoBehaviour
    {
        public string verNum = "0.1";
        public string roomName = "room01";
        public Transform spawnPoint;
        public GameObject playerPref;
        public bool isConnected = false;
        public Shader panoShader;
        public Material pano;


        void Start()
        {
            Debug.Log("Start");
            
            PhotonNetwork.ConnectUsingSettings(verNum);
            Debug.Log("Starting Connection");
        }

        public void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
            Debug.Log("Starting Server!");
        }

        public void OnJoinedRoom()
        {
            isConnected = true;
            spawnPlayer();
        }

        public void spawnPlayer()
        {
            GameObject pl = PhotonNetwork.Instantiate(playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
        }

        public void ShowPano(string imagename)
        {
            print("LOAD PANO!");
            //  pano = (Material)Resources.Load("360material", typeof(Material)) as Material;
            // RenderSettings.skybox = pano;
            photonView.RPC("LoadPano", PhotonTargets.All, (string)imagename);
        }

        // defining a method that can be called by other clients:
        [PunRPC]
        public void LoadPano(string panoName)
        {
            pano = (Material)Resources.Load("Pano/360material", typeof(Material)) as Material;
            Texture panoTexture = (Texture)Resources.Load("Pano/" + panoName, typeof(Texture)) as Texture;
            print(panoTexture.name);
            pano.SetTexture("_Tex", panoTexture);
            RenderSettings.skybox = pano;
          //  RenderSettings.skybox = (Material)Resources.Load("Pano/360material", typeof(Material)) as Material;
        //Debug.Log(string.Format("RPC: 'OnAwakeRPC' Parameter: {0} PhotonView: {1}", myParameter, this.photonView));
    }
}
