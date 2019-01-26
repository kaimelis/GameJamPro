using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeForkType
{
    [MenuItem("Assets/Create/SO/ForkType")]
    public static void CreateForkType(){
        ForkTypeSO asset = ScriptableObject.CreateInstance<ForkTypeSO>();

        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/NewForkType.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
