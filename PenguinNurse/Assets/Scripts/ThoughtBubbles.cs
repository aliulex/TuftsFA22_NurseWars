using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubbles : MonoBehaviour
{
    public GameObject[] needs;
    // Start is called before the first frame update
    private GameObject[] icons = new GameObject[10];
    void Start()
    {
        icons[0] = Instantiate(needs[0], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1), Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        icons[0].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
    }
}
