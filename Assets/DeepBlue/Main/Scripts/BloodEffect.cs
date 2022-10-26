using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeepBlue.Engine {
    public class BloodEffect : MonoBehaviour
    {
        [SerializeField] public float _destroyTime = 1f;


        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, _destroyTime);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

