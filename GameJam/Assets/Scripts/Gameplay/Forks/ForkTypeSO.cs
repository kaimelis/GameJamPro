using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ForkType{Alpha, Beta, Gamma};

public class ForkTypeSO : ScriptableObject
{
    //[SerializeField] private WaveEffect _effect;

    [SerializeField] private ForkType _wavetype;
    public float radius = 0;
    public float weight = 0;

    //The rate at which the radius deminishes in unit/s.
    public float fadeRate = 0.5f;
    public void EmitWave(){

    }
}
