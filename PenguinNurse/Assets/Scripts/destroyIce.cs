using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyIce : MonoBehaviour
{
        /* Function to destroy ice instantly when collide with baby penguin */
        void OnTriggerStay2D(Collider2D other)
        {
                if (other.gameObject.tag == "patient")
                {
                    gameObject.SetActive(false);
                }
        }
}
