using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Ship.OnTriggerEnter");
        Game.Game.remove_live();
    }
}
