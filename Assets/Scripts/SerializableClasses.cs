using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySerializables
{
    [System.Serializable]
    public struct SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        public SerializableVector3(float rX, float rY, float rZ)
        {
            x = rX;
            y = rY;
            z = rZ;
        }
    }
}


