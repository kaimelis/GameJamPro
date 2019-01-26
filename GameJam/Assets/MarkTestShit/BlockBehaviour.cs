using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private Collider _collider;
    [SerializeField]private LayerMask _mask;
    [SerializeField]private LayerMask _defaultMask;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

   /// <summary>
   /// OnTriggerEnter is called when the Collider other enters the trigger.
   /// </summary>
   /// <param name="other">The other Collider involved in this collision.</param>
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Fork")){
           //Do fancy shit
           gameObject.layer = _mask;
           print("Enabled");
       }
   }

   private void OnTriggerExit(Collider other) {
      gameObject.layer = _defaultMask;
      print("disabled");
   }
}
