using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform holdSpot;  /* Location where penguin will be hold */
    public LayerMask pickUpMask;

    private GameObject itemHolding;     /* Having private means when we have it pick up, we store it in this variable. When we want to drop it, we can just access this variable again */ 

    public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */
    
    public Sprite checkMark;
    public GameObject exit;
    public GameHandler gameHandlerObj;

    void Start() {
        if (GameObject.FindWithTag("GameHandler") != null) {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {  /* Check for key input */

            if (itemHolding) {  /* If player is currently holding item, drop the item */

                GameObject[] beds = GameObject.FindGameObjectsWithTag("bed");
                GameObject[] stools = GameObject.FindGameObjectsWithTag("stool");
                GameObject place = null;
                bool canplacebed = false;
                bool canplacestool = false;
                bool canexit = false;
                int checkCount = 0;
 
                for (int i = 0; i < beds.Length; i++) {
                    if (Vector3.Distance(transform.position, beds[i].transform.position) <= 1.5) {
                        if (beds[i].transform.childCount == 0) {
                            place = beds[i];
                            canplacebed = true;
                        }
                    }
                }

                for (int i = 0; i < stools.Length; i++) {
                    if (Vector3.Distance(transform.position, stools[i].transform.position) <= 1.5) {
                        if (stools[i].transform.childCount == 0) {
                            place = stools[i];
                            canplacestool = true;
                        }
                    }
                }

                if (Vector3.Distance(transform.position, exit.transform.position) <= 1.5) {
                    for (int i = 0; i < itemHolding.GetComponent<ThoughtBubbles>().needs.Length; i++) {
                        if (itemHolding.GetComponent<ThoughtBubbles>().icons[i].GetComponent<SpriteRenderer>().sprite == checkMark) {
                            checkCount++;
                        }
                    }
                    if (checkCount == itemHolding.GetComponent<ThoughtBubbles>().needs.Length) {
                        canexit = true;
                    }
                }

                if (canexit) {
                    for (int i = 0; i < itemHolding.GetComponent<ThoughtBubbles>().needs.Length; i++) {
                        itemHolding.GetComponent<ThoughtBubbles>().icons[i].GetComponent<Renderer>().enabled = false;
                    }
                    itemHolding.GetComponent<Bubble>().bubbleAbove.GetComponent<Renderer>().enabled = false;
                    Destroy(itemHolding);
                    gameHandlerObj.AddScore(1);
                } else if (canplacebed) { /* If player is near a place (bed/stool), drop the item on the place */
                    itemHolding.transform.position = place.transform.position + new Vector3(0, (float)0.25, 0);
                    itemHolding.transform.parent = place.transform;
                } else if (canplacestool) {
                    itemHolding.transform.position = place.transform.position + new Vector3(0, (float)0.9, 0);
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
