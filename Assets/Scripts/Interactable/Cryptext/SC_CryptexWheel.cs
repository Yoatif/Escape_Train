using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CryptexWheel : C_Interactable
{
    [SerializeField]
    private Rigidbody wheel;
    [SerializeField]
    private GameObject myself;

    private bool rotating;



    private void OnMouseDown()
    {
        Interact();
        Debug.Log("hayaya");
    }


    public override void Interact()
    {
        StartCoroutine(rotateObject(myself, Vector3.up * (360/26), 0.2f));
    }




    IEnumerator rotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Vector3 newRot = gameObjectToMove.transform.localEulerAngles + eulerAngles;

        Vector3 currentRot = gameObjectToMove.transform.localEulerAngles;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.localEulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
}
