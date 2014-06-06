using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {

	public Light left_light;
	public Light right_light;

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (transform.position.x > 7.5f) {
				left_light.enabled = true;
				transform.position += Vector3.left * 45 * Time.deltaTime;
				}
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.position.x < 188f) {
                right_light.enabled = true;
				transform.position += Vector3.right * 45 * Time.deltaTime;
				}
		} else {
			left_light.enabled = false;
			right_light.enabled = false;
			}
		}

  
}
