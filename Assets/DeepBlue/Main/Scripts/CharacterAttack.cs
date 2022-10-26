using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeepBlue.Engine {
    public class CharacterAttack : MonoBehaviour
    {
        [Header("Attack Setting")]

        [Tooltip("")]
        [SerializeField] public int _damage;

        [Tooltip("")]
        [SerializeField] public float _attackWaitTime;

        [Tooltip("")]
        [SerializeField] public GameObject hitboxAttack_01;

        [Tooltip("")]
        [SerializeField] public GameObject hitboxAttack_02;


        private Animator _animator;
        private PolygonCollider2D _PolygonC_Attack_01;
        private PolygonCollider2D _PolygonC_Attack_02;
        private bool _isAttacking;


        void Start() {
            //_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            _animator = GetComponent<Animator>();

            //_PolygonCollider2D = GetComponent<PolygonCollider2D>();
            _PolygonC_Attack_01 = hitboxAttack_01.GetComponent<PolygonCollider2D>();
            _PolygonC_Attack_02 = hitboxAttack_02.GetComponent<PolygonCollider2D>();

            _isAttacking = false;
        }


        void Update() {
            Attack_01();
            Attack_02();

        }

        void Attack_01() {
            if (Input.GetKeyDown(KeyCode.J)) {
                _animator.SetTrigger("IsAttack_01");
            }
        }

        void Attack_02() {
            if (Input.GetKeyDown(KeyCode.K)) {
                _animator.SetTrigger("IsAttack_02");
            }
        }

        void Start_Attack_01_Hitbox() {
            _PolygonC_Attack_01.enabled = true;
        }

        void Finish_Attack_01_Hitbox()
        {
            _PolygonC_Attack_01.enabled = false;
        }

        void Start_Attack_02_Hitbox()
        {
            _PolygonC_Attack_02.enabled = true;
        }

        void Finish_Attack_02_Hitbox()
        {
            _PolygonC_Attack_02.enabled = false;
        }


        


        IEnumerator DisableHitBox() {
            yield return new WaitForSeconds(_attackWaitTime);
            //_PolygonCollider2D.enabled = false;
        }
    }
}

