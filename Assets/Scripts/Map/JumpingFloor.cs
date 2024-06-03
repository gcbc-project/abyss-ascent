using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingFloor : MonoBehaviour,IJumpingObject
{
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask playerLayer;
    public float JumpForce => jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (1<<collision.gameObject.layer == playerLayer)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
