using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeepBlue.Engine {

    public abstract class Enemy : MonoBehaviour {
        [Header("Enemy Setting")]

        [SerializeField] public int _health;
        [SerializeField] public int _damage;
        [SerializeField] public Color _damageFlashColor = Color.red;
        [SerializeField] public float _damageFlashTime = 0.25f;
        [SerializeField] public GameObject _bloodEffect;

        private SpriteRenderer _SpriteRenderer;
        private Color _orgColor;
        //private Rigidbody2D _rigidbody2D;
        private CharacterHealth _characterHealth;



        public void Awake() {
            _SpriteRenderer = GetComponent<SpriteRenderer>();
            _orgColor = _SpriteRenderer.color;

            _characterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();

            //_rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        public void Start(){
        }

        protected void Update() {




            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage) {
            FlashColor(_damageFlashTime);
            Instantiate(_bloodEffect, transform.position, Quaternion.identity);
            
            _health = _health - damage;
        }

        void FlashColor(float time) {
            _SpriteRenderer.color = _damageFlashColor;
            Invoke(nameof(ResetColor), time);
        }

        void ResetColor()
        {
            _SpriteRenderer.color = _orgColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D") {
                if (_characterHealth != null) {
                    _characterHealth.DamageCharacter(_damage);  
                }
                
            }
        }

        
    }


}
