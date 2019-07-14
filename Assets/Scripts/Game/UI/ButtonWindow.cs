using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RedRift.Test
{
    public class ButtonWindow : MonoBehaviour, IPointerClickHandler
    {
        private IEnumerable<IMoveable> _moveableObjects;

        private void Awake()
        {
            _moveableObjects = FindObjectsOfType<PlayerObject>().Cast<PlayerObject>().ToList();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (IMoveable o in _moveableObjects)
            {
                o.ForceTo(mousePosition);
            }
        }
    }
}