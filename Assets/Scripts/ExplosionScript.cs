using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public static int direction = 1;

    void Start() {
        Debug.Log("Explosion Start starts");
        particleSystem.Play();
        Destroy(this.gameObject, 5.0f);
        }

    public void set_direcion(int d) {
        direction = d;
        }

    void Update ()
    {
        transform.position += Vector3.right * Time.deltaTime * 10 * direction;
    }
}
