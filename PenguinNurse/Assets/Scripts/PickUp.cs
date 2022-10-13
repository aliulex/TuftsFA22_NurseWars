using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform holdSpot;  /* Location where penguin will be hold */
    public LayerMask pickUpMask;

    private GameObject itemHolding;     /* Having private means when we have it pick up, we store it in this variable. When we want to drop it, we can just access this variable again */ 

    public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */

    public GameObject place;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {  /* Check for key input */

            if (itemHolding) {  /* If player is currently holding item, drop the item */

                if (Vector3.Distance (place.transform.position, transform.position) < 1.5) { /* If player is near a place (bed/stool), drop the item on the place */
                    itemHolding.transform.position = place.transform.position;
                    itemHolding.transform.parent = place.transform;
                } else {
                    itemHolding.transform.position = transform.position + Direction;     /* Change the positon of the item so that when the item is drop, it dropped right infront of the player */
                    itemHolding.transform.parent = null;   /* Get the item off the player head */
                }

                if (itemHolding.GetComponent<Rigidbody2D>()) {
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;  /* Check to make sure that the object stop following the player */
                }

                itemHolding = null; /* Set to null because item is no longer being held */




        } else {    /* If player is not currently holding an item, pick the item up */
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .8f, pickUpMask);   /* pickUpMask will only allow player to get item that can be picked up */

                if (pickUpItem) {   /* If there's an item that can be picked up */
                    itemHolding = pickUpItem.gameObject;    /* store game object into itemHolding */
                    itemHolding.transform.position = holdSpot.position;     /* Change the positon of the item to the holding spot position */
                    itemHolding.transform.parent = transform;   /* Set the parent of the item to the player so that the item follows the player */

                    if (itemHolding.GetComponent<Rigidbody2D>()) {
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;  /* Check to make sure that the object follows the player */
                    }

                }

            }
        }

    }
}
