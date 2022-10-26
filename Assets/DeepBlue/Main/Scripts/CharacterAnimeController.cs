using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeepBlue.Tool;
using Random = UnityEngine.Random;


namespace DeepBlue.Engine {
    [SelectionBase]
    [AddComponentMenu("BaseRes/Scripts/CharacterAnimeController")]

    public class CharacterAnimeController : MonoBehaviour {
        
        private Rigidbody2D _rigidbody2D;
        public Animator _animator;


        private void Awake() {
            _rigidbody2D = GetComponentInParent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
        }

        private void Flip() {
            bool hasSpeedX = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
            if (hasSpeedX) {
                if (_rigidbody2D.velocity.x > 0.1f) {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (_rigidbody2D.velocity.x < -0.1f) {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                }
            }
        }

        private void Anime() {
            float walkSpeed = GetComponentInParent<CharacterController2D>().walkSpeed;
            float runSpeed = GetComponentInParent<CharacterController2D>().runSpeed;

            bool IsIdle = Mathf.Abs(_rigidbody2D.velocity.x) < Mathf.Epsilon;
            bool IsWalk = (Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon) && (Mathf.Abs(_rigidbody2D.velocity.x) <= walkSpeed) || (Mathf.Abs(_rigidbody2D.velocity.y) > Mathf.Epsilon) && (Mathf.Abs(_rigidbody2D.velocity.y) <= walkSpeed);
            bool IsRun = (Mathf.Abs(_rigidbody2D.velocity.x) > walkSpeed) && (Mathf.Abs(_rigidbody2D.velocity.x) <= runSpeed) || (Mathf.Abs(_rigidbody2D.velocity.y) > walkSpeed) && (Mathf.Abs(_rigidbody2D.velocity.y) <= runSpeed);
            bool IsDodge = GetComponentInParent<CharacterController2D>().isDodgeButtonDown;

            _animator.SetBool("IsIdle", IsIdle);
            _animator.SetBool("IsWalk", IsWalk);
            _animator.SetBool("IsRun", IsRun);
            _animator.SetBool("IsDodge", IsDodge);
            
        }

        private void Update() {
            Flip();
            Anime();

        }
    }
}
