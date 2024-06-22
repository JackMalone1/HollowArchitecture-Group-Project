#nullable enable

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestScripts
{
    public class TestPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        private Rigidbody2D? _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (touchPosition.x < 0)
                {
                    _rigidbody!.AddForce(Vector2.left * moveSpeed);
                }
                else
                {
                    _rigidbody!.AddForce(Vector2.right * moveSpeed);
                }
                
            }
            else
            {
                _rigidbody!.velocity = Vector2.zero;
            }
        }
    }
}