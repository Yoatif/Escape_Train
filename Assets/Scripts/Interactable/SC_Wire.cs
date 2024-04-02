using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SC_Wire : C_Interactable
{
    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    public float smoothSpeed;
    public string tagObjectCollider;
    public float throwForce = 0.0f;
    public bool puzzleIsGood = false;
    


    [SerializeField]
    private float angleX, angleY, angleZ;


    private Rigidbody myselfRigidbody;
    private int LayerNumber;
    // Start is called before the first frame update
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                DropObject();
                FollowingCamera();
            }

        }
    }

    public override void Interact()
    {
        isPicked = true;
        myselfRigidbody.isKinematic = true;
        //myself.transform.Rotate(0, 0, 0, Space.World);
        myself.transform.parent = holdPos.transform;


        myself.layer = LayerNumber;

        //Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }

    void FollowingCamera()
    {
        Vector3 objectPosition = transform.position;
        Vector3 cameraPosition = holdPos.position;

        objectPosition.x = Mathf.Lerp(objectPosition.x, cameraPosition.x, smoothSpeed);
        objectPosition.y = Mathf.Lerp(objectPosition.y, cameraPosition.y, smoothSpeed);

        transform.position = objectPosition;
    }


    
    /*public void OnCollisionEnter(Collision collision)
    {
        if (isPicked == false)
        {
            if (collision.gameObject.tag == tagObjectCollider)
            {
                Debug.Log("le bon est dedans !");
                myselfRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                puzzleIsGood = true;
            }
            else
            {

            }
        }
        
    }*/
    
    void DropObject()
    {
        isPicked = false;
        //Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
    }

    public string Color()
    {
        return tagObjectCollider;
    }
}
