//This class sets up the 'room' - IE the online multiplayer room that the Gear VR phones and the PC will connect to for the PC to send commands to show images to the Gear VRs
using System.Collections;
using System.Linq;
using UnityEngine;

//Uses Photon.MonoBehaviour - Photon is the online service that provides the room and the connectivity between the PC and phones
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

    //Start runs when the app loads - it connects to our Photon account
    void Start()
        {
            Debug.Log("Start");
            PhotonNetwork.ConnectUsingSettings(verNum);
            Debug.Log("Starting Connection");
        }

    //Once connected to the Photon account, attempts to join the room (see above for room name)
        public void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
            Debug.Log("Starting Server!");
        }

    //Once joined room, creates a new object in the scene - the 'player' object. This is primarily to enable PC users to look around
    // the scene with a mouse
        public void OnJoinedRoom()
        {
            isConnected = true;
            GameObject pl = PhotonNetwork.Instantiate(playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
            Debug.Log(spawnPoint.position);
    }
}
