using System.Collections;
using System.Linq;
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
        public GameObject photoSphere;


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
            initialiseImages();
        }

        public void spawnPlayer()
        {
            GameObject pl = PhotonNetwork.Instantiate(playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
            Debug.Log(spawnPoint.position);
        }

        private void initialiseImages()
        {
        // var images = Resources.LoadAll("Pano", typeof(Texture2D)).Cast<Texture2D>().ToArray();
        //foreach (var i in images)
        //{
        //     Debug.Log(i.name);
           // }
        
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
