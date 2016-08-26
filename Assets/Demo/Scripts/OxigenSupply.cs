using UnityEngine;
using System.Collections;

public class OxigenSupply : MonoBehaviour
{
    public float chargeSpeed = 0.5f;
    private Player player;

    public void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
    }

    public void OnTriggerExit(Collider other)
    {
        player = null;
    }

    public void OnTriggerStay(Collider other)
    {
        if (player != null && player.oxigenSlider.value < 1f)
        {
            player.oxigen += chargeSpeed * Time.deltaTime;
        }
    }

}
