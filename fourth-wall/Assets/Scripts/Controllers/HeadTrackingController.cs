using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracking : MonoBehaviour {

    public Transform CopyTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(0f, CopyTransform.localEulerAngles.y, 0f);
    }
}
