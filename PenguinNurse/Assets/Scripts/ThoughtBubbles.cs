using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubbles : MonoBehaviour
{
    public GameObject[] needs;
	public AudioSource task_doneSFX; // finished task sfx
    // Start is called before the first frame update
    private GameObject[] icons = new GameObject[3];
    public Sprite newSprite;
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

    void Slept()
    {
        for (int i = 0; i < needs.Length; i++) {
            if (icons[i].tag == "needbed") {
                icons[i].GetComponent<SpriteRenderer>().sprite = newSprite;
				task_doneSFX.Play();
            }
        }
    }

    void Eaten()
    {
        for (int i = 0; i < needs.Length; i++) {
            if (icons[i].tag == "needsaltine") {
                icons[i].GetComponent<SpriteRenderer>().sprite = newSprite;
				task_doneSFX.Play();
            }
        }
    }

    void Patched()
    {
        for (int i = 0; i < needs.Length; i++) {
            if (icons[i].tag == "needbandaid") {
                icons[i].GetComponent<SpriteRenderer>().sprite = newSprite;
				task_doneSFX.Play();
            }
        }
    }

    void Iced()
    {
        for (int i = 0; i < needs.Length; i++) {
            if (icons[i].tag == "needice") {
                icons[i].GetComponent<SpriteRenderer>().sprite = newSprite;
				task_doneSFX.Play();
            }
        }
    }
}
