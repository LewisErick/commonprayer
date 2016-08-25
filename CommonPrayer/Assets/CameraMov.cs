using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	public float smooth = 1.5f;         // The relative speed at which the camera will catch up.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SmoothLookAt (GameObject.Find("Player").transform);
	}

	void SmoothLookAt (Transform target)
    {
        // Create a vector from the camera towards the player.
        Vector3 relPlayerPosition = target.position - transform.position;
        
        // Create a rotation based on the relative position of the player being the forward vector.
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        
        // Lerp the camera's rotation between it's current rotation and the rotation that looks at the player.
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
    }
}
