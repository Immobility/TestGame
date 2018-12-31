using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private cameraMovement cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main.GetComponent<cameraMovement>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
