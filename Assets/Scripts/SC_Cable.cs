using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SC_Cable : C_Interactable
{

 
    public bool isPicked = false;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    public Transform holdPos;
    public GameObject myself;
    public float smoothSpeed;
    public string tagObjectCollider;
    public GameObject player;

    private Vector3 initialPosition;
    private Vector3 newPosition;

    private Rigidbody myRigidBody;
    private Transform myTransform;

    private void Start()
    {
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    void Update()
    {
        if (isPicked)
        {
            Debug.Log("PickUp");
            myself.transform.position = holdPos.transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                DropObject();
            }
        }
    }

    //Fonction d'interaction
    public override void Interact()
    {
        isPicked = true;
        //myselfRigidbody.isKinematic = true;
        myself.transform.rotation = Camera.main.transform.rotation;
        myself.transform.Rotate(0, 180, 0);
        myself.transform.parent = holdPos.transform;
        myself.transform.position = holdPos.transform.position;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }

    //Fonction pour lâcher l'objet
    void DropObject()
    {
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
    }
    

    public string GetTagObjectCollider()
    {
        return tagObjectCollider;
    }

    // return the initial position
    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    /*return the object at his initial position*/
    public void ReturnToInitialPosition()
    {
        gameObject.transform.position = initialPosition;
    }
}

