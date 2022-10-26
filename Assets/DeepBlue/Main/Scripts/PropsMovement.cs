using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DeepBlue.Engine
{

    public class PropsMovement : MonoBehaviour {

        public float movementSpeed = 0.0000001f;
        public Vector3 moveUpDirection = new Vector3(0f, 1f);
        public Vector3 moveDownDirection = new Vector3(0f, -1f);

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            //_characterBase = GetComponent<CharacterBase>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        
        private void Update()
        {
            MovePropsUp();
            MovePropsDown();
        }

        private void MovePropsUp() {
            
            _rigidbody2D.velocity = moveUpDirection * movementSpeed;
        }
        private void MovePropsDown(){
            
            _rigidbody2D.velocity = moveDownDirection * movementSpeed;
        }
    }

}