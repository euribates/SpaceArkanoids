using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    bool engine_on;

	// Use this for initialization
	void Start () {
        engine_on = true;
	}

    void Play() {
        engine_on = true;
        }
	
	// Update is called once per frame
	void Update () {
        if (engine_on) {
            transform.position += Vector3.back * 25f * Time.deltaTime;
            }	
        }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("defense")) {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        } else if (collider.CompareTag("ship")) {
            // Lives++
        }
    }
}
