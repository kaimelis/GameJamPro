using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;    
    [SerializeField] private ForkTypeSO _forkType;    
    private SphereCollider _WaveCollider;
    private bool _activated = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _WaveCollider = GetComponent<SphereCollider>();
    }
    
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(!_activated && !other.gameObject.CompareTag("Player")){            
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            // start emiting waves
            _WaveCollider.radius = _forkType.radius;
            _WaveCollider.enabled = true;
            _activated = true;

            StartCoroutine("ShrinkRadius");
        }       
    }

    IEnumerator ShrinkRadius(){
        while(_WaveCollider.radius > 0f){
            _WaveCollider.radius -= _forkType.fadeRate*Time.deltaTime;    
            yield return null;
        }

        _WaveCollider.enabled = false;
    }
}
