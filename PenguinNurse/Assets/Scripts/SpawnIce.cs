using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{

        /* Game Object to Spawn */
        public GameObject objToSpawn;

        public Transform iceLocation;  /* Location where ice will be dispense */


        /* Timer */
        public float timeLeft, originalTime;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                /* Tick down timer */
                timeLeft -= Time.deltaTime;
                if(timeLeft <= 0) {
                        timeLeft = originalTime;
                }


                if(Input.GetKeyDown(KeyCode.P)) {
                        spawnOnPress();
                }

        }

        void spawnOnPress() {
                Instantiate(objToSpawn, iceLocation.position, Quaternion.identity);
        }
}
