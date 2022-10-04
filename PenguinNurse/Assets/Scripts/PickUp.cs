using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    public Transform grabDetect;  /* Location of where penguin will be hold */
    public Transform boxHolder;
    public float rayDist;
    
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider .tag == "patient") {
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        } else {
            grabCheck.collider.gameObject.transform.parent = null;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }


    }
}
