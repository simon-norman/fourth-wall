using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimate : MonoBehaviour {

    static Animator anim;
    public PhotonView graphicsPV;

    public Rigidbody rb;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsStandard_idle", true);

    }
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.magnitude > 0.5)
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsStandard_idle", false);
            // graphicsPV.RPC("playAnimPV", PhotonTargets.All, "running");
        }
        else
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsStandard_idle", true);
            //graphicsPV.RPC("playAnimPV", PhotonTargets.All, "standard_idle");
        }

    }

}
