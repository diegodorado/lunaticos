using UnityEngine;
using System.Collections;

public class GrabCrystalSFX : MonoBehaviour
{

    private AudioSource ambient;
    private float targetPitch;
    private float lerpSpeed;

    void Start()
    {
        ambient = GameObject.Find("Atmosphere").GetComponent<AudioSource>();
        targetPitch = Random.Range(0.3f, 0.9f);
        lerpSpeed = Random.Range(1f, 10f);
    }

    void Update()
    {
        ambient.pitch = Mathf.Lerp(ambient.pitch, targetPitch, lerpSpeed * Time.deltaTime);
    }
}
