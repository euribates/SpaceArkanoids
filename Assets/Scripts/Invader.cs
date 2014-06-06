using UnityEngine;
using System.Collections;
using Game;

public class Invader : MonoBehaviour {

    public GameObject weapon;
	static int direction = 1;
	// Use this for initialization



	// Update is called once per frame
	void Update () {
		if (transform.position.x > 188) {
			direction = -1;
		} else if (transform.position.x < 10) {
			direction = 1;
		}
		transform.position += Vector3.right * Time.deltaTime * 10 * direction + Vector3.back * Time.deltaTime * 0.5f;
	}
}
