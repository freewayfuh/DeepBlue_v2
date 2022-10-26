using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeepBlue.Engine {
    public class CharacterHealth : MonoBehaviour
    {
        [Header("Character Setting")]
        [SerializeField] public int _health;

        [Header("Blinks Setting")]
        [SerializeField] public int _numBlinks;
        [SerializeField] public float _secBlinks;


        private SpriteRenderer _SpriteRenderer;


        public void Awake() {
            _SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void DamageCharacter(int damage) {
            _health = _health - damage;
            if (_health <= 0) {
                Destroy(gameObject);
            }
            BlinkCharacter(_numBlinks, _secBlinks);
        }

        void BlinkCharacter(int numBlinks, float seconds) {
            StartCoroutine(DoBlinks(numBlinks, seconds));
        }

        IEnumerator DoBlinks(int numBlinks, float seconds) {
            for (int i = 0; i < numBlinks * 2; i++) {
                _SpriteRenderer.enabled = !_SpriteRenderer.enabled;
                yield return new WaitForSeconds(seconds);
            }
            _SpriteRenderer.enabled = true;
        }

    }

}

