using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBandaid : MonoBehaviour
{
        /* Function to destroy bandaid after 2.5 second of colliding with baby penguin */
        void OnTriggerStay2D(Collider2D other)
        {

                if (other.gameObject.tag == "patient")
                {
                        StartCoroutine(DelayDestroyingBandaid());                
                }
        }

        IEnumerator DelayDestroyingBandaid(){
                yield return new WaitForSeconds(2.5f);
                gameObject.SetActive(false);
        }
}
