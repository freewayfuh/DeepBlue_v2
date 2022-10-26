using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeepBlue.Tool;
using Random = UnityEngine.Random;

namespace DeepBlue.Engine {

    [SelectionBase]
    [AddComponentMenu("BaseRes/Scripts/CharacterController2D")]

    public class CharacterController2D : MonoBehaviour {

        //State enum
        private enum State
        {
            Idle,
            Walking,
            Running,
            Dodgeing,
        }




        [Header("Movement Setting")]        // [SerializeField] 

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public float movementSpeed;

        [Tooltip("")]
        //[HideInInspector]
        [SerializeField] public float walkSpeed = 7.5f;

        [Tooltip("")]
        //[HideInInspector]
        [SerializeField] public float runSpeed = 10f;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public Vector3 moveDirection;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public Vector3 dodgeDirection;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public Vector3 lastMoveDirection;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public bool isDashButtonDown;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public bool isRunButtonDown;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public bool isDodgeButtonDown;
        
        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public bool isAttackButtonDown;




        [Header("Dash Setting")]

        [Tooltip("")]
        public float dashAmout = 2.5f;

        [Tooltip("")]
        [SerializeField] private LayerMask dashLayerMask;

        [Header("Dodge Setting")]


        [Tooltip("")]
        [SerializeField] public float dodgeSpeedInit = 17.5f;

        [ReadOnly]
        [Tooltip("")]
        [SerializeField] public float dodgeSpeed;

        [Tooltip("dodgeSpeedDropMultiplier * deltaTime(0.02)")]
        [SerializeField] public float dodgeSpeedDropMultiplier = 35f;

        [Tooltip("")]
        [SerializeField] public float dodgeSpeedMinimum = 7.5f;



        [Header("Character Anime Controller Setting")]
        [SerializeField] public Component CharacterAnimeController;



        //private CharacterBase _characterBase;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private State state;
        

        private void Awake() {
            //_characterBase = GetComponent<CharacterBase>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = CharacterAnimeController.GetComponent<Animator>();

            // init statement
            state = State.Idle;
        }

        private void Update() {

            Move();
            Dash();
            Run();
            Dodge();


        }

        private void FixedUpdate() {


            _rigidbody2D.velocity = moveDirection * movementSpeed;
            if (isRunButtonDown) {
                movementSpeed = runSpeed;
            }
            else {
                movementSpeed = walkSpeed;
            }


            if (isDashButtonDown) {

                Vector3 dashPosition = transform.position + lastMoveDirection * dashAmout;

                RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDirection, dashAmout, dashLayerMask);
                if (raycastHit2d.collider != null) {
                    dashPosition = raycastHit2d.point;
                }

                _rigidbody2D.MovePosition(dashPosition);
                isDashButtonDown = false;
            }

            if (isDodgeButtonDown) {
                _rigidbody2D.velocity = dodgeDirection * dodgeSpeed;

                dodgeSpeed = (dodgeSpeed - dodgeSpeedDropMultiplier * Time.deltaTime);
                if (dodgeSpeed <= dodgeSpeedMinimum) {
                    isDodgeButtonDown = false;
                }
                        
            }

                    

        }

        void Move() {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W)) { moveY = +1f; }
            if (Input.GetKey(KeyCode.S)) { moveY = -1f; }
            if (Input.GetKey(KeyCode.A)) { moveX = -1f; }
            if (Input.GetKey(KeyCode.D)) { moveX = +1f; }

            moveDirection = new Vector3(moveX, moveY).normalized;
            if (moveX != 0 || moveY != 0)
            {
                // Not idle
                lastMoveDirection = moveDirection;
            }
        }

        void Dash() {
            // isDashButtonDown (Disabled)
            if (Input.GetKeyDown(KeyCode.F) && false)
            {
                isDashButtonDown = true;
            }
        }

        void Run() {
            // isRunButtonDown
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunButtonDown = true;
            }
            else
            {
                isRunButtonDown = false;
            }
        }

        void Dodge() {
            // isDodgeButtonDown
            if (Input.GetKeyDown(KeyCode.Space) && (!isDodgeButtonDown))
            {
                isDodgeButtonDown = true;
                dodgeSpeed = dodgeSpeedInit;
            }
            if (isDodgeButtonDown)
            {
                dodgeDirection = lastMoveDirection;
            }
        }
        



    }

}
