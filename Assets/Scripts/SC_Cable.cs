using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SC_Cable : C_Interactable
{

 
    public bool isPicked = false;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    public float smoothSpeed;
    public string tagObjectCollider;

    public int holdLayerNumber;

    private Vector3 initialPosition;
    private Vector3 newPosition;

    private Rigidbody myRigidBody;

    void Start()
    {

        myRigidBody = GetComponent<Rigidbody>();
        initialPosition = gameObject.transform.position;
    }

    /*private void OnMouseDown()
    {
        if (isPicked)
        {
            Debug.Log("isPicked");
            PickUpObject(gameObject);
            MoveObjectWithMouse();
        }
        else
        {
            
            Debug.Log("released");
            ReleaseObject();
        }
    }
    /*Following the mouvement of the mouse*/
    void MoveObjectWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Vector3.Distance(Camera.main.transform.position, transform.position);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 newPosition = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
    }

    //catching the onject
    void PickUpObject(GameObject gameObject)
    {
        isPicked = true;
        newPosition = gameObject.transform.position;

        myRigidBody.isKinematic = true;
        myRigidBody.detectCollisions = false;
        MoveObjectWithMouse();
    }

    // free the objet at the new position
    public void ReleaseObject()
    {
        isPicked = false;
        transform.position = newPosition;

        myRigidBody.isKinematic = false;
        myRigidBody.detectCollisions = true;
    }
    
    //verify if the object is at the center of the screen
    

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

