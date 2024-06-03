using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour, IProjectileObject
{
    [SerializeField] float ObjMoveSpeed;
    private Vector3 _direction;
    [SerializeField] LayerMask _playerLayerMask;

    #region testCode
    [SerializeField] Transform player;
    private void Start()
    {
        //temp
        player = TestShoot.Instance.Player;
    }
    #endregion

    public float MoveSpeed => ObjMoveSpeed;
    
    public void SetDirection(Vector3 direction)
    {

        _direction = direction.normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * ObjMoveSpeed * Time.deltaTime);


        DestoryProjectileObj();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(1 << other.gameObject.layer == _playerLayerMask)
        {
            other.GetComponent<Health>().Modify(-10);
        }
    }
    void DestoryProjectileObj()
    {
        if (Vector3.Distance(gameObject.transform.position, player.position) > 10)
        {
            ObjectPoolManager.Instance.ReturnPool("ProjectileObj", gameObject);
        }
    }
    
}
