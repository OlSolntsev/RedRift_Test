using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedRift.Test
{
    public class PlanetPanel : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();    
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            _sprite.color = Random.ColorHSV();
        }
    }
}