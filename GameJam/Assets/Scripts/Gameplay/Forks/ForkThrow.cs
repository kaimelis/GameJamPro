using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkThrow : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField]private float _force = 5.0f;
    [SerializeField]private GameObject _forkToSpawn = null;
    [SerializeField]private Transform _spawnPoint = null;
     
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Camera cam = Camera.main;
            Vector3 recalculatedMousePosition = Input.mousePosition  - cam.WorldToScreenPoint(transform.position);
          
            Vector3 throwDirection = (recalculatedMousePosition - transform.position).normalized;
            //TODO: nigga it's easy, just change this.
            _direction = new Vector3(0 , throwDirection.y, throwDirection.x);
            GameObject fork = GameObject.Instantiate(_forkToSpawn,_spawnPoint.position, Quaternion.identity);
            fork.GetComponent<Rigidbody>().AddForce(_direction *_force, ForceMode.VelocityChange);            
        }
    }
}
