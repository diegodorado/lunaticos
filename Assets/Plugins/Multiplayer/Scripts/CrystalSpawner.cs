using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CrystalSpawner : NetworkBehaviour
{
    public GameObject[] crystals;
    public Text statsText;
    public static int total;
    public static int remaining;
    public static int grabbed;
    public override void OnStartServer()
    {
        CrystalSpawnPoint[] points = FindObjectsOfType<CrystalSpawnPoint>();
        for (int i = 0; i < points.Length; i++)
        {
            GameObject crystal = (GameObject)Instantiate(crystals[Random.Range(0, crystals.Length)], points[i].transform.position, Quaternion.identity);
            NetworkServer.Spawn(crystal);
        }
    }
    void FixedUpdate()
    {
        statsText.text = string.Format("Cristales: {0}/{1}  ({2})", grabbed, remaining, total);

    }

}
