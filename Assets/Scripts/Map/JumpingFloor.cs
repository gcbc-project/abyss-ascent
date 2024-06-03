using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingFloor : MonoBehaviour,IJumpingObject
{
    [SerializeField] float _jumpForce;
    [SerializeField] LayerMask _playerLayer;
    public float JumpForce => _jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (1<<collision.gameObject.layer == _playerLayer)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
