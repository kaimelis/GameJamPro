using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForkInventory", menuName = "SO/ForkInventory", order = 0)]
public class ForkInventory : ScriptableObject {
    public fSet red = new fSet{type=ForkType.Red};
    public fSet green= new fSet{type=ForkType.Green};
    public fSet blue= new fSet{type=ForkType.Blue};  

    public void ResetInventory(){
        red.forksLeft = red.available;
        green.forksLeft = green.available;
        blue.forksLeft = blue.available;
    } 
}

[CreateAssetMenu(fileName = "ForkPrefabInventory", menuName = "SO/ForkPrefabInventory", order = 0)]
public class ForkPrefabInventory : ScriptableObject {
    public fpSet red = new fpSet{type=ForkType.Red};
    public fpSet green= new fpSet{type=ForkType.Green};
    public fpSet blue= new fpSet{type=ForkType.Blue};  
}

[System.Serializable]
    public struct fSet{
    [System.NonSerialized]
    public ForkType type;
    public int available;
    [System.NonSerialized]
    public int forksLeft;
}

[System.Serializable]
public struct fpSet{
    [System.NonSerialized]
    public ForkType type;
    public GameObject prefab;
}