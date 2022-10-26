using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeepBlue.Engine {
    public class Teleportation : MonoBehaviour
    {

        void Start()
        {

        }


        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                print("Enter");
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                print("Exit");
            }
        }
    }

}
