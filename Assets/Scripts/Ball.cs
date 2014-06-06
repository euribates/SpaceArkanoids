using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public AudioSource laser_sound;
	public float speed = 120.0f;
	private Vector3 vel;
    ParticleSystem explosion;

	// Use this for initialization
	void Start () {;
        vel = new Vector3(Random.value, 0, Mathf.Abs(Random.value));
        vel.Normalize();
        vel *= speed;
        explosion = GameObject.Find("Explosion").particleSystem;
		// vel = new Vector3 (speed, 0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, vel, Color.red);
		transform.position += vel * Time.deltaTime;
		//transform.rigidbody.AddForce (transform.rigidbody.velocity*Time.deltaTime, ForceMode.VelocityChange);
	}

	void OnCollisionEnter(Collision col) {;
		Vector3 normal = Vector3.zero;
		foreach (ContactPoint contact in col.contacts) {
			normal += contact.normal;
			}
		normal.Normalize();
		vel = Vector3.Reflect (vel, normal);

		}

	void OnCollisionExit(Collision col) {
        if (col.collider.CompareTag("invader") || col.collider.CompareTag("defense")) {
            if (col.collider.CompareTag("invader")) {
                laser_sound.Play();
                ParticleSystem exp = (ParticleSystem) Instantiate(explosion, col.collider.transform.position, Quaternion.identity);
                exp.loop = false;
                exp.Play();
                }
            Destroy (col.collider.gameObject);
            }

        }
}
