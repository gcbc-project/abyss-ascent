using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public GameObject MovingBlockObj;
    public GameObject MovingBlockObj2;
    [SerializeField] LayerMask PlayerLayer;
    private float _moveToZ = 3.1f;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _startPosition_2;
    private void Start()
    {
        _startPosition = MovingBlockObj.transform.position;
        if (MovingBlockObj2 != null)
        {
            _startPosition_2 = MovingBlockObj2.transform.position;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (MovingBlockObj.transform.position.z < _startPosition.z + _moveToZ)
            {
                MovingBlockObj.transform.position = new Vector3(0, 0, MovingBlockObj.transform.position.z + _moveToZ);
            }
            if (MovingBlockObj2 != null)
            {
                if (MovingBlockObj2.transform.position.z < _startPosition_2.z + _moveToZ)
                {                    
                    MovingBlockObj2.transform.position = new Vector3(0, 0, MovingBlockObj2.transform.position.z + _moveToZ /2);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(1 << other.gameObject.layer == PlayerLayer)
        {
            if (MovingBlockObj.transform.position.z < _startPosition.z + _moveToZ)
            {
                MovingBlockObj.transform.position = new Vector3(0, 0, MovingBlockObj.transform.position.z + _moveToZ);
            }
            if (MovingBlockObj2 != null)
            {
                if (MovingBlockObj2.transform.position.z < _startPosition_2.z + _moveToZ)
                {
                    MovingBlockObj2.transform.position = new Vector3(0, 0, MovingBlockObj2.transform.position.z + _moveToZ / 2);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (1 << other.gameObject.layer == PlayerLayer)
        {
            MovingBlockObj.transform.position = _startPosition;
            if (MovingBlockObj2 != null)
            {
                MovingBlockObj2.transform.position = _startPosition_2;
            }
        }
    }
}
