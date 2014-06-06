using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    void Update ()
    {
        if (particleSystem != null && particleSystem.particleCount == 0)
            Destroy(gameObject);
    }
}
