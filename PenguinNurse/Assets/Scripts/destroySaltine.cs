using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySaltine : MonoBehaviour
{
        public GameObject bar;
        private GameObject progress;
        /* Function to destroy saltines after 2.5 second of colliding with baby penguin */

        void OnTriggerEnter2D(Collider2D other)
        {
                if (other.gameObject.tag == "patient")
                {
                        progress = Instantiate(bar, new Vector2(other.transform.position.x, other.transform.position.y - 0.5f), Quaternion.identity);
                        StartCoroutine(DelayDestroyingSaltines(other));                
                }
        }

        void OnTriggerExit2D(Collider2D other)
        {
                if (other.gameObject.tag == "patient")
                {
                        Destroy(progress);
                        StopCoroutine(DelayDestroyingSaltines(other));
                }
        }

        IEnumerator DelayDestroyingSaltines(Collider2D other){
                yield return new WaitForSeconds(5f);
                other.SendMessage("Eaten");
                Destroy(progress);
                gameObject.SetActive(false);
        }
}
