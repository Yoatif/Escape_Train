using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Cube : C_Interactable
{
    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public float throwForce = 500f;
    public SC_PickUp pickUpScript;

    private float rotationSensitivity = 1f;
    private Rigidbody myselfRigidbody;
    private int LayerNumber;




    private void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
    }

    void Update()
    {
        if (isPicked)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {

                DropObject();
                MoveObject();
                StopClipping();


            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                ThrowObject();
                StopClipping();

            }
            RotateObject();
            
        }
           
    }

    public override void Interact( )
    {
            isPicked = true;
            myselfRigidbody.isKinematic = true;
            myself.transform.parent = holdPos.transform;
            myself.layer = LayerNumber;

            Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        


    }

    void MoveObject()
    {

        myself.transform.position = holdPos.transform.position;
    }

    void StopClipping()     //On empeche le clipping de l'objet tenu
    {
        var clipRange = Vector3.Distance(myself.transform.position, transform.position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {

            myself.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);

        }
    }

    //Fonction pour lâcher l'objet
    void DropObject()
    {
        isPicked=false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        
    }

    //Fonction pour lancer l'objet
    void ThrowObject()
    {
        isPicked = false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        myselfRigidbody.AddForce(transform.forward * throwForce);
        pickUpScript.canInteract=true;
        
    }


    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;

            myself.transform.Rotate(Vector3.down, XaxisRotation);
            myself.transform.Rotate(Vector3.right, YaxisRotation);
        }
       
    }
}
