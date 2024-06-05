using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObject : MonoBehaviour, IDamageObject
{
    [SerializeField] int SpikeDamage;
    [SerializeField] float SpikeShowTime;
    [SerializeField] LayerMask PlayerLayerMask;
    private GameObject _player;
    private bool _isPlayerDamage = false;
    private Animator _spikeAnim;
    public int Damage => SpikeDamage;
    public float ShowTime => SpikeShowTime;
    private void Start()
    {
        _spikeAnim = GetComponent<Animator>();
        StartCoroutine(SpikeUp());
    }

    IEnumerator SpikeUp()
    {
        while (true)
        {
            _spikeAnim.SetTrigger("ShowSpike");
            yield return new WaitForSeconds(SpikeShowTime);
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (1<< collision.gameObject.layer == PlayerLayerMask)
        { 
            _player = collision.gameObject;
            _isPlayerDamage = true;
        }
    }

    public void CheckPlayer()
    {
        if (_isPlayerDamage == true)
        {
            _player.GetComponent<Health>().Modify(-SpikeDamage);            
        }
        _isPlayerDamage = false;
    }
    public void AnimStart()
    {
        _isPlayerDamage = false;
    }
}
