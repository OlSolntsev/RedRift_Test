using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedRift.Test
{
    public class PlanetUIManager : MonoBehaviour
    {
        //Lazy singletone
        public static PlanetUIManager SingleTone { get; private set; }
        [SerializeField] private Image _background;

        private void Awake()
        {
            // Here's many way to get this persistent object:
            // 1) From PlanetManager (Write Initialize UI Method with settings parameter)
            // 2) Create singletone in every manager class (Lazy is also works)
            // 3) Don't divie UI and main manager
            // I found this solution is fine (even FindObjectOfType like GetComponent - really bad methods,
            // but in Start/Awake callback it can be allowed.

            //PersistentSettings persistent = FindObjectOfType<PersistentSettings>();
            //SetBackgroundColor(persistent.Planet.PlanetColor);
            SingleTone = this;
        }

        private void Start()
        {
            SetBackgroundColor(PlanetManager.SingleTone.Persistent.Planet.PlanetColor);
        }

        private void SetBackgroundColor(Color color)
        {
            _background.color = color;
        }
    }
}