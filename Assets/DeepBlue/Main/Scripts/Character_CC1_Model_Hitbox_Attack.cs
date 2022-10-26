using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeepBlue.Engine {
    public class Character_CC1_Model_Hitbox_Attack : MonoBehaviour
    {
        private int _damage;

        void Update()
        {
            _damage = GetComponentInParent<CharacterAttack>()._damage;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(_damage);
            }
        }
    }
}

