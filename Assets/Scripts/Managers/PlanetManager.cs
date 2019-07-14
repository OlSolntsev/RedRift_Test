using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedRift.Test
{
    public class PlanetManager : MonoBehaviour
    {
        // Lazy singletone
        public static PlanetManager SingleTone { get; private set; }

        public PersistentSettings Persistent { get; private set; }

        [SerializeField] private float _gravityCoef;

        [SerializeField] private PlanetGround _ground;
        [SerializeField] private List<Rigidbody2D> _playerObjects;

        private void Awake()
        {
            SingleTone = this;
        }

        private void Start()
        {
            Persistent = FindObjectOfType<PersistentSettings>();
            _ground.Initialize(Persistent.Planet.G, _gravityCoef, _playerObjects);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}