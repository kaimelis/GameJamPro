using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameJam
{
    public class LayerDatabse : MonoBehaviour
    {   
        [Serializable]
        public struct ObjectInfo
        {
            public GameObject[] redObjects;
            public GameObject[] blueObjects;
            public GameObject[] greenObjects;
        };

        public ObjectInfo objectInfo;


    }
}
