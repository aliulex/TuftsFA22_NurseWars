using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject bar;
    private bool currentSleep = false;
    private GameObject currentBed;
    private GameObject progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] beds = GameObject.FindGameObjectsWithTag("bed");
        for (int i = 0; i < beds.Length; i++) {
            if (transform.position == beds[i].transform.position + new Vector3(0, (float)0.25, 0) && currentSleep == false) {
                currentSleep = true;
                currentBed = beds[i];
                progress = Instantiate(bar, new Vector2(beds[i].transform.position.x, beds[i].transform.position.y - 0.5f), Quaternion.identity);
                StartCoroutine(DelaySleep());
            }
            if (currentBed != null && transform.position != currentBed.transform.position + new Vector3(0, (float)0.25, 0) && currentSleep == true) {
                Destroy(progress);
                currentSleep = false;
            }
        }
            
    }

    IEnumerator DelaySleep() 
    {
        yield return new WaitForSeconds(5f);
        Destroy(progress);
        if (currentSleep == true) {
            gameObject.SendMessage("Slept");
        }
    }
}
