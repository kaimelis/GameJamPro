﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody = null;    
    [SerializeField] private ForkTypeSO _forkType = null;    
    private SphereCollider _WaveCollider;
    private bool _activated = false;  
    private ScannerEffectDemo mainCamera = null;

    [SerializeField] private GameEvent _forkDestroyEvent = null;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _WaveCollider = GetComponent<SphereCollider>();
        mainCamera = Camera.main.GetComponent<ScannerEffectDemo>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(!_activated && !other.gameObject.CompareTag("Player")){            
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            // start emiting waves
            _WaveCollider.radius = _forkType.radius;
            _WaveCollider.enabled = true;
            _activated = true;              
            if(mainCamera)
            {
                mainCamera.ScannerOrigin = gameObject.transform;
                mainCamera?.StartScanning();
            }
            StartCoroutine("ShrinkRadius");
        }       
    }

    private void OnCollisionExit(Collision other) {
        DestroyFork();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BlockBehaviour>()){
            BlockBehaviour behaviour = other.GetComponent<BlockBehaviour>();
            behaviour.Activate(_forkType.type);
        }
    }

    private void OnTriggerExit(Collider other) {
         if(other.GetComponent<BlockBehaviour>()){
            BlockBehaviour behaviour = other.GetComponent<BlockBehaviour>();
            behaviour.DeActivate();
        }
    }

    IEnumerator ShrinkRadius(){
        while(_WaveCollider.radius > 0f){
            _WaveCollider.radius -= _forkType.fadeRate*Time.deltaTime;    

            yield return null;
        }

        _WaveCollider.enabled = false;
       //  mainCamera.StopScanning();

        DestroyFork();
    }
    void DestroyFork(){  
        _forkDestroyEvent.Raise();      
        Destroy(gameObject);
    }
}
