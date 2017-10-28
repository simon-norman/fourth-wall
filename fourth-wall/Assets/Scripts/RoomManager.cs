using System.Collections;
using System.Linq;
using UnityEngine;

    public class RoomManager : Photon.MonoBehaviour
    {
        public string verNum = "0.1";
        public string roomName = "room01";
        public Transform spawnPoint;
        public GameObject playerPref;
        public bool isConnected = false;
        public Shader panoShader;
        public Material pano;
        public GameObject photoSphere;
        public Texture2D[] loadedPanos;


    IEnumerator Start()
        {
            Debug.Log("Start");
            PhotonNetwork.ConnectUsingSettings(verNum);
            Debug.Log("Starting Connection");
            print("Starting download");
            string imageLocation = "https://www.flickr.com/photos/britishlibrary/11133167035/";
            WWW www = new WWW(imageLocation);
            yield return www;
            //print("Completing download");
            //photoSphere = GameObject.Find("PhotoSphere");
            //photoSphere.GetComponent<Renderer>().material.mainTexture = www.texture;
        }

        public void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
            Debug.Log("Starting Server!");
        }

        public void OnJoinedRoom()
        {
            isConnected = true;
            SpawnPlayer();
        }

        public void SpawnPlayer()
        {
            GameObject pl = PhotonNetwork.Instantiate(playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
            Debug.Log(spawnPoint.position);
        }
}
