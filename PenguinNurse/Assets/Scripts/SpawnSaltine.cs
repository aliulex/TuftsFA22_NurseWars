using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSaltine : MonoBehaviour
{


        /* NOTE: transform.position will get the position of the object in which the script is apply to */

        public GameObject objToSpawn;   /* Game Object to Spawn */


        public Transform saltineLocation;  /* Location where saltine will be dispense */

        public GameObject penguin; /* Penguin Player */

        public GameObject saltine;  /* Game object for the saltine itself */

        public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */

        public GameObject bar;

        void Update()
        {
                float distant_from_saltineMachine = Vector3.Distance (penguin.transform.position, transform.position);  /* Get the position between the penguin and the saltine-machine  */
                float saltineBlockLocation = Vector3.Distance (saltine.transform.position, saltineLocation.position);       /* Get the position between the spawned saltine and the location where saltine will depense */

                /* If player is close enough to the saltine machine */
                if(distant_from_saltineMachine <= 1.5) {

                        /* If "P" is pressed and the location of a spawned saltine is not at the spawn location. Essentially mean, only spawn saltine when a button is press and when there's no saltine at the spawn-saltine location */
                        if(Input.GetKeyDown(KeyCode.P) && saltineBlockLocation > 1) {
                                // StopCoroutine(DelayTreeAway());
                                // StartCoroutine(DelayTreeAway());
                                spawnOnPress();
                        }
                }

        }

        // /* Wait a couple second before saltine is spawned */
        // IEnumerator DelayTreeAway(){
        //         GameObject progress = Instantiate(bar, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        //         yield return new WaitForSeconds(5f);

        //         spawnOnPress();
        //         Destroy(progress);

        // }

        /* Function to spawn an saltine */
        void spawnOnPress() {

                /* For checking to make sure that saltine doesn't get spawn if there's already an saltine at the location */
                saltine = Instantiate(objToSpawn, saltineLocation.position, Quaternion.identity);
        }


}
