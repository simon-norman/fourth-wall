using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class RigidbodyFPSController : MonoBehaviour
{

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    private bool stationary = true;
    public GameObject fpsCam;
    public GameObject character;
    public Material pano;


    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void LoadPano()
    {
        pano = (Material)Resources.Load("360material", typeof(Material)) as Material;
        RenderSettings.skybox = pano;
    }

    void Update()
    {

        if (Input.GetButton("Fire1") & stationary == true)
        {
            
            // Do something if tap starts
            //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * 7, ForceMode.VelocityChange);
            stationary = false;
        }

        else if (Input.GetButtonUp("Fire1") & stationary == false)
        {
            // Do something if tap ends
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            stationary = true;
        }

        //if (Input.GetKey("Up"))
        //{
        //    GetComponent<Rigidbody>().AddForce(transform.forward * 1, ForceMode.VelocityChange);
        //}

        //if (grounded)
       // {
            // Calculate how fast we should be moving
            //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
          //  targetVelocity = transform.TransformDirection(targetVelocity);
           // targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
           // Vector3 velocity = GetComponent<Rigidbody>().velocity;
          //  Vector3 velocityChange = (targetVelocity - velocity);
           // velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
           // velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
          //  velocityChange.y = 0;
          //  GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
         //   GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.VelocityChange);

        //    // Jump
        //    if (canJump && Input.GetButton("Jump"))
        //    {
        //        GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
        //    }
        //}

        //// We apply gravity manually for more tuning control
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}