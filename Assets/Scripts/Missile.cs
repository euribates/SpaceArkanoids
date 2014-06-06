using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public AudioSource space_sound;
    bool engine_on;
    Game.Game game;

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
        Debug.Log("OnTriggerEnter starts");
        if (collider.CompareTag("defense")) {
            space_sound.Play();
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        } else if (collider.CompareTag("ship")) {
            Game.Game.remove_live();

        }
    }
}
