using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBandaid : MonoBehaviour
{


        /* NOTE: transform.position will get the position of the object in which the script is apply to */

        public GameObject objToSpawn;   /* Game Object to Spawn */


        public Transform bandaidLocation;  /* Location where bandaid will be dispense */

        public GameObject penguin; /* Penguin Player */

        public GameObject bandaid;  /* Game object for the bandaid itself */

        public Vector3 Direction {get; set; }  /* Pick Up Logic: Need to know which direction the nurse penguin is facing. Get from movement scipt */

        public GameObject bar;

        void Update()
        {
                float distant_from_bandaidMachine = Vector3.Distance (penguin.transform.position, transform.position);  /* Get the position between the penguin and the bandaid-machine  */
                float bandaidBlockLocation = Vector3.Distance (bandaid.transform.position, bandaidLocation.position);       /* Get the position between the spawned bandaid and the location where bandaid will depense */

                /* If player is close enough to the bandaid machine */
                if(distant_from_bandaidMachine <= 1.5) {

                        /* If "u" is pressed and the location of a spawned bandaid is not at the spawn location. Essentially mean, only spawn bandaid when a button is press and when there's no bandaid at the spawn-bandaid location */
                        if(Input.GetKeyDown(KeyCode.P) && bandaidBlockLocation > 1) {
                                StopCoroutine(DelayTreeAway());
                                StartCoroutine(DelayTreeAway());
                        }
                }

        }

        /* Wait a couple second before bandaid is spawned */
        IEnumerator DelayTreeAway(){
                GameObject progress = Instantiate(bar, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                yield return new WaitForSeconds(5f);

                spawnOnPress();
                Destroy(progress);

        }

        /* Function to spawn an bandaid */
        void spawnOnPress() {

                /* For checking to make sure that bandaid doesn't get spawn if there's already an bandaid at the location */
                bandaid = Instantiate(objToSpawn, bandaidLocation.position, Quaternion.identity);
        }


}
