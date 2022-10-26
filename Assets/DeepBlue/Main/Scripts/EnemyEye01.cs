using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DeepBlue.Engine {
    public class EnemyEye01 : Enemy {

        [SerializeField] public float _speed = 2f;
        [SerializeField] public float _startWaitTime = 1f;
        private float _waitTime;

        [SerializeField] public Transform _movePosition;

        [SerializeField] public Transform _rightUpPos;
        [SerializeField] public Transform _leftDownPos;




        new public void Awake() {
            base.Awake();
        }
        new public void Start() {
            base.Start();

            _waitTime = _startWaitTime;
            _movePosition.position = GetRandomPos();
        }
        new public void Update() {
            base.Update();

            transform.position = Vector2.MoveTowards(transform.position, _movePosition.position, _speed * Time.deltaTime);
            Flip();


            if (Vector2.Distance(transform.position, _movePosition.position) < Mathf.Epsilon) {
                if (_waitTime <= 0) {
                    _movePosition.position = GetRandomPos();
                    _waitTime = _startWaitTime;
                }
                else {
                    _waitTime = _waitTime - Time.deltaTime;
                }
            }
        }

        Vector2 GetRandomPos() {
            return new Vector2(Random.Range(_leftDownPos.position.x, _rightUpPos.position.x), Random.Range(_leftDownPos.position.y, _rightUpPos.position.y));
        }


        private void Flip()
        {
            if ((transform.position.x - _movePosition.position.x) > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if ((transform.position.x - _movePosition.position.x) < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, -180, 0);
            }
        }

    }
}

