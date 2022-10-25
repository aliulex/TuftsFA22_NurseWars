using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject bubble;
    // Start is called before the first frame update
    public GameObject bubbleAbove;
    private float offset = 0.1f;
    void Start()
    {
        bubbleAbove = Instantiate(bubble, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + offset), Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bubbleAbove.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + offset);
        
    }
}
