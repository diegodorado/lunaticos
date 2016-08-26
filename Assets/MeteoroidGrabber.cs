using UnityEngine;
using System.Collections;

public class MeteoroidGrabber : MonoBehaviour {
    public GameObject[] sounds;

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
