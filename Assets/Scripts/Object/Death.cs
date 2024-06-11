using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (1 << collision.gameObject.layer == PlayerLayerMask)
        {
            collision.gameObject.GetComponent<Health>().Modify(-100);
        }
    }
}
