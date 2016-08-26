using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);

    }

}
