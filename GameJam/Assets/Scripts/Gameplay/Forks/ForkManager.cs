using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForkManager : MonoBehaviour
{
    //Side note, we might want to have scriptable objects that devine all the things in the level so we don't have to set a new prefabs with inventory per level.^^

    [SerializeField] private ForkInventory _inventory = null;
    [SerializeField] private ForkPrefabInventory _prefabs = null;
    
    private ForkType _currentFork = ForkType.Red;
    private ForkThrow _forkThrow = null;

    // Start is called before the first frame update
    void Start()
    {
        _inventory.ResetInventory();
        _forkThrow = GetComponent<ForkThrow>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(EnoughAmmo()){
                _forkThrow.Throw(GetPrefab());
                ManageInventory();
            }            
        }

        if(Input.GetKeyDown(KeyCode.E)){           
            _currentFork = (int)_currentFork < (int)ForkType.Length-1? ++_currentFork : 0;            
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            _currentFork = (int)_currentFork > 0? --_currentFork : ForkType.Length-1;
        }
    }

    private bool EnoughAmmo(){
       switch(_currentFork){
           case ForkType.Red:
            return _inventory.red.forksLeft > 0;
           case ForkType.Green:
            return _inventory.green.forksLeft > 0;
           case ForkType.Blue:
            return _inventory.blue.forksLeft > 0;
           default:
            return false;
       }
        
    }

    private GameObject GetPrefab(){
       switch(_currentFork){
            case ForkType.Red:
                return _prefabs.red.prefab;
            case ForkType.Green:
                return _prefabs.green.prefab;
            case ForkType.Blue:
                return _prefabs.blue.prefab;
            default:
                print("No correct type for some reason...");
                return null;
       }         
    }

    private void ManageInventory(){
        switch(_currentFork){
            case ForkType.Red:
                _inventory.red.forksLeft--;
                break;
            case ForkType.Green:
                _inventory.green.forksLeft--;
                break;
            case ForkType.Blue:
                _inventory.blue.forksLeft--;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Method to be called by the eventlistener to restore the right forks.
    /// </summary>
    /// <param name="restoredFork"></param>
    public void RestoreFork(int restoredFork){
        switch(restoredFork){
            case (int)ForkType.Red:
                _inventory.red.forksLeft++;
                break;
            case (int)ForkType.Green:
                _inventory.green.forksLeft++;
                break;
            case (int)ForkType.Blue:
                _inventory.blue.forksLeft++;
                break;
        }
    }
}
