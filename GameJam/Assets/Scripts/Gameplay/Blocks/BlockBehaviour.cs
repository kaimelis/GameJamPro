using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockBehaviour : MonoBehaviour, IPlatform
{ 
    private Collider _collider;
    private MeshRenderer _meshrenderer;
    private bool _canBeTriggered = false;
   
    [SerializeField] private ForkType _triggeredByForkTpe = ForkType.Red;

    void Start()
    {
        _meshrenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }


    public bool canBeTriggered{
        get{
            return _canBeTriggered;
        }
        set{
            _canBeTriggered = value;
        }
    }
/*      void OnTriggerEnter(Collider other)
    {
        ///here, we change layer so player and fork can collide
        if(other.CompareTag("Fork") && _canBeTriggered && !_meshrenderer.isVisible){           
            EnableRenderer();           
        }
    }

    private void OnTriggerExit(Collider other) {
        //here it goes back to normal again.
        if(other.CompareTag("Fork") && _canBeTriggered && _meshrenderer.isVisible){
            DisableRenderer();    
            _canBeTriggered = false;             
        }
    } */
    void DisableRenderer(){
        _meshrenderer.enabled = false;
        _collider.isTrigger = true;
    }

    void EnableRenderer(){
        _meshrenderer.enabled = true;
        _collider.isTrigger = false;
        
    }

    public void Activate(ForkType type){
        if(type == _triggeredByForkTpe){
            EnableRenderer();
        }
    }

    public void DeActivate(ForkType type){
         
    }

    public void Activate(){

    }

    public void DeActivate(){
         DisableRenderer();    
        _canBeTriggered = false; 
    }
}
