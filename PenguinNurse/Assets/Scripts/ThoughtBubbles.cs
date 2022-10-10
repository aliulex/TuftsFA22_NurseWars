using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubbles : MonoBehaviour
{
    public GameObject[] needs;
    // Start is called before the first frame update
    private GameObject[] icons = new GameObject[3];
    void Start()
    {
        for (int i = 0; i < needs.Length; i++) {
            icons[i] = Instantiate(needs[i], new Vector2(gameObject.transform.position.x - 1 + i, gameObject.transform.position.y + 1), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < needs.Length; i++) {
            icons[i].transform.position = new Vector2(gameObject.transform.position.x - 1 + i, gameObject.transform.position.y + 1);
        }
        
    }
}
