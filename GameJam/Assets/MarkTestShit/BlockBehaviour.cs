using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum BlockType{RED, GREEN, BLUE}
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private BlockType _blocktype;
    private Collider _collider;
    private MeshRenderer _meshrenderer;
    private bool _canBeTriggered = false;
    private bool _correctSignal = false;
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

    public void EvaluateInt(int input){        
        if(input == (int)_blocktype){
            _correctSignal = true;
        }
    }

     void OnTriggerEnter(Collider other)
    {
        ///here, we change layer so player and fork can collide
        if(other.CompareTag("Fork") && _canBeTriggered && !_meshrenderer.isVisible && _correctSignal){           
            EnableRenderer();           
        }
    }

    private void OnTriggerExit(Collider other) {
        //here it goes back to normal again.
        if(other.CompareTag("Fork") && _canBeTriggered && _meshrenderer.isVisible){
            DisableRenderer();    
            _canBeTriggered = false;  
            //_correctSignal = false; //Needs to be changed later on. Causes trouble when there are a second signal hits before the first fades.       
        }
    }
    void DisableRenderer(){
        _meshrenderer.enabled = false;
        _collider.isTrigger = true;
    }

    void EnableRenderer(){
        _meshrenderer.enabled = true;
        _collider.isTrigger = false;
        
    }

}
