using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedRift.Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlanetGround : MonoBehaviour
    {
        private float _g;
        private float _gravityCoef;

        private bool _initialized = false;

        private Rigidbody2D _rigidBody;
        private IEnumerable<Rigidbody2D> _affectedObjects;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(float g, float c, List<Rigidbody2D> ao)
        {
            _g = g;
            _gravityCoef = c;
            _affectedObjects = ao;
            _initialized = true;
        }

        private void FixedUpdate()
        {
            if (_initialized)
            {
                foreach (Rigidbody2D r in _affectedObjects)
                {
                    Attract(r);
                }
            }
        }

        public void Attract(Rigidbody2D affectedObject)
        {
            Vector2 direction = Vector2.down;

            float forceMagnitude = _g * _rigidBody.mass * _gravityCoef;
            Vector2 force = direction.normalized * forceMagnitude;

            affectedObject.AddForce(force);
        }
    }
}