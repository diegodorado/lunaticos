using UnityEngine;
using System.Collections;

public class MeteoroidGrabber : MonoBehaviour {
    public GameObject[] sounds;


    void Awake()
    {
        //randomize a little
        var autoSpin = GetComponent<AutoSpinObject>();
        transform.position += Vector3.up * Random.Range(-1f, 0.2f);
        transform.localScale = Vector3.one * Random.Range(0.6f, 1f);

        autoSpin.spinVector = Random.onUnitSphere;
        autoSpin.speed = Random.Range(10, 60);
        autoSpin.direction = Random.Range(-1, 1);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();

        if (player!=null)
        {
            var go = Instantiate(sounds[Random.Range(0, sounds.Length)], transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(go, 3f);
            player.meteoroidsCount++;
        }
    }

}
