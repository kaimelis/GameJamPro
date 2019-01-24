using System;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "SO/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        // Value of the float. Modifications are saved in the object.
        public float Value;

        // RuntimeValue used for runtime modifications. 
        // We need the NonSerialized tag so that it does not save its state in the ScriptableObject.
        [NonSerialized]
        public float RuntimeValue;

        public void SetValue(float value)
        {
           RuntimeValue = value;
        }

        public void ApplyChange(float amount)
        {
           RuntimeValue += amount;
        }

        // public void ApplyChange(FloatVariable amount)
        // {
        //    RuntimeValue += amount.Value;
        // }
    }
}

