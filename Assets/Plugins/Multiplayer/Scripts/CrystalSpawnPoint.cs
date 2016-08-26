using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CrystalSpawnPoint : MonoBehaviour
{

#if (UNITY_EDITOR)
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position + Vector3.up * 100, Vector3.down, out hit, 200))
        {
            gameObject.transform.position = hit.point;
            gameObject.transform.position += Vector3.up;
        }
    }
#endif

    // Use this for initialization
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 4);
    }

}
