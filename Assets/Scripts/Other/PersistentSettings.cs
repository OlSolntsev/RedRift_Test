using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedRift.Test
{
    public class PersistentSettings : MonoBehaviour
    {
        public PlanetSettings Planet { get; private set; }
        public int Hits { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Hits = 0;
        }

        public void SetPlanet(PlanetSettings s) => Planet = s;
        public void Hit()
        {
            Hits++;
            Debug.Log("HIT!");
        }
    }
}