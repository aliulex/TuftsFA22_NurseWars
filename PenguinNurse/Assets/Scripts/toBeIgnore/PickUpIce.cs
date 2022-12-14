using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpIce : MonoBehaviour
{
        public Transform holdSpot;  /* Location where penguin will be hold */
        public LayerMask pickUpMask;

        private GameObject itemHolding;     /* Having private means when we have it pick up, we store it in this variable. When we want to drop it, we can just access this variable again */ 

        public GameObject babyPenguin;

        public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */

        void Update()
        {

                if (Input.GetKeyDown(KeyCode.T)) {  /* Check for key input */

                        Debug.Log("Outside item holding");

                        if (itemHolding) {  /* If player is currently holding item, drop the item */

                                Debug.Log("Under item holding");

                                itemHolding.transform.position = transform.position + Direction;     /* Change the positon of the item so that when the item is drop, it dropped right infront of the player */
                                itemHolding.transform.parent = null;   /* Get the item off the player head */

                                if (itemHolding.GetComponent<Rigidbody2D>()) {
                                        itemHolding.GetComponent<Rigidbody2D>().simulated = true;  /* Check to make sure that the object stop following the player */
                                }



                                /********************** WHY IS THIS PART NOT WORKING*/
                                float distant_ice_from_baby_penguin = Vector3.Distance (babyPenguin.transform.position, itemHolding.transform.position);
                                Debug.Log(distant_ice_from_baby_penguin);
                                if(distant_ice_from_baby_penguin <= 2) {
                                        itemHolding.SetActive(false);
                                        itemHolding = null; /* Set to null because item is no longer being held */
                                }
                                /***********************/







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

        void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.tag == "patient")
                {
                    Destroy (gameObject);
                    //or gameObject.SetActive(false);
                }
        }

}
