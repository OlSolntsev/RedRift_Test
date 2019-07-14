using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedRift.Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerObject : MonoBehaviour, IMoveable
    {
        public Rigidbody2D Physics { get; private set; }

        public float LeanSpeed => _leanSpeed;
        [SerializeField] private float _leanSpeed;

        private void Awake()
        {
            Physics = GetComponent<Rigidbody2D>();
        }

        public void ForceTo(Vector2 targetPosition)
        {
            Physics.velocity = new Vector2(0, Physics.velocity.y);
            targetPosition = new Vector2(targetPosition.x, Physics.position.y);
            Vector2 direction = (targetPosition - Physics.position).normalized;
            Physics.AddForce(direction * _leanSpeed);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            PlanetManager.SingleTone.Persistent.Hit();
        }
    }
}