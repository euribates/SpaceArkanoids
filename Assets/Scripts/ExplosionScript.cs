using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public int direction = 1;

    void Start() {
        particleSystem.Play();
        Destroy(this.gameObject, 5.0f);
        }

    public void swith_direcion() {
        Debug.Log("ExplosionScrit.swith_direction starts");
        direction = -direction;
        }

    void Update ()
    {
        transform.position += Vector3.right * Time.deltaTime * 10 * direction;
    }
}
