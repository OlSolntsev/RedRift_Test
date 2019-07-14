using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedRift.Test
{
    [CreateAssetMenu(fileName = "New Settings", menuName = "Planet")]
    public class PlanetSettings : ScriptableObject
    {
        public float G;
        public Color PlanetColor;
    }
}