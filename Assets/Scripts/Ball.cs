using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public AudioSource laser_sound;
	public float speed = 120.0f;
	private Vector3 vel;
    public GameObject explosion;

	// Use this for initialization
	void Start () {;
        vel = new Vector3(Random.value, 0, Mathf.Abs(Random.value));
        //vel = new Vector3(0, 0, 1);
        vel.Normalize();
        vel *= speed;
		// vel = new Vector3 (speed, 0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position;
        v += vel * Time.deltaTime;
        v.y = 2.5f;
        transform.position = v;
		Debug.DrawRay (transform.position, vel, Color.red);
		//transform.rigidbody.AddForce (transform.rigidbody.velocity*Time.deltaTime, ForceMode.VelocityChange);
	}

	void OnCollisionEnter(Collision col) {
        if (col.collider.CompareTag("ship")) {
            float x_ship = col.collider.transform.position.x;
            float x_ball = transform.position.x;
            float delta = Mathf.PI/2 + ((x_ship - x_ball) / 10f) * Mathf.PI/4;
            vel = new Vector3(Mathf.Cos(delta), 0, Mathf.Sin(delta));
            vel *= speed;
        } else {
	    	Vector3 normal = Vector3.zero;
		    foreach (ContactPoint contact in col.contacts) {
			    normal += contact.normal;
			    }
		    normal.Normalize();
		    vel = Vector3.Reflect (vel, normal);

		    }
        }

	void OnCollisionExit(Collision col) {
        if (col.collider.CompareTag("invader")){
             laser_sound.Play();
             GameObject exp_clone = Instantiate(
                 explosion, 
                 col.collider.transform.position, 
                 Quaternion.identity) as GameObject;
             if (col.collider.GetComponent<Invader>().get_direction() == -1) {
                    ExplosionScript s = exp_clone.GetComponent<ExplosionScript>() as ExplosionScript;
                    s.swith_direcion();
                    }
            Destroy (col.collider.gameObject);
            Debug.Log("40");
            Game.Game.add_score(1);
            }

        }
}
