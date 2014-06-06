using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		transform.LookAt (target);
	}

}
