using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{


        /* NOTE: transform.position will get the position of the object in which the script is apply to */

        public GameObject objToSpawn;   /* Game Object to Spawn */


        public Transform iceLocation;  /* Location where ice will be dispense */

        public GameObject penguin; /* Penguin Player */

        public GameObject ice;  /* Game object for the ice itself */

        public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */

        public GameObject bar;

        void Update()
        {
                float distant_from_iceMachine = Vector3.Distance (penguin.transform.position, transform.position);  /* Get the position between the penguin and the ice-machine  */
                float iceBlockLocation = Vector3.Distance (ice.transform.position, iceLocation.position);       /* Get the position between the spawned ice and the location where ice will depense */

                /* If player is close enough to the ice machine */
                if(distant_from_iceMachine <= 2) {

                        /* If "P" is pressed and the location of a spawned ice is not at the spawn location. Essentially mean, only spawn ice when a button is press and when there's no ice at the spawn-ice location */
                        if(Input.GetKeyDown(KeyCode.P) && iceBlockLocation > 1) {
                                StopCoroutine(DelayTreeAway());
                                StartCoroutine(DelayTreeAway());
                        }
                }

        }

        /* Wait a couple second before ice is spawned */
        IEnumerator DelayTreeAway(){
                GameObject progress = Instantiate(bar, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                yield return new WaitForSeconds(5f);

                spawnOnPress();
                Destroy(progress);

        }

        /* Function to spawn an ice */
        void spawnOnPress() {

                /* For checking to make sure that ice doesn't get spawn if there's already an ice at the location */
                ice = Instantiate(objToSpawn, iceLocation.position, Quaternion.identity);
        }


}