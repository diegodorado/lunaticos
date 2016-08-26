using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{
    public GameObject[] sounds;

    void Start()
    {
        CrystalSpawner.total++;
        CrystalSpawner.remaining++;
    }

    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            var go = Instantiate(sounds[Random.Range(0, sounds.Length)], transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(go, 3f);
            if(player.isLocalPlayer)
                CrystalSpawner.grabbed++;
        }
    }

    void OnDestroy()
    {
        CrystalSpawner.remaining--;
    }
}
