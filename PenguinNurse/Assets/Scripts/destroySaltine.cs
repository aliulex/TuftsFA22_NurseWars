using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySaltine : MonoBehaviour
{
        /* Function to destroy saltines after 2.5 second of colliding with baby penguin */

        void OnTriggerStay2D(Collider2D other)
        {
                if (other.gameObject.tag == "patient")
                {
                        StartCoroutine(DelayDestroyingSaltines());                
                }
        }

        IEnumerator DelayDestroyingSaltines(){
                yield return new WaitForSeconds(2.5f);
                gameObject.SetActive(false);
        }
}
