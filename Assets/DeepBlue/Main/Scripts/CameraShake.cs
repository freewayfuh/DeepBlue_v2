using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

namespace DeepBlue.Engine {
    public class CameraShake : MonoBehaviour {
        private readonly List<ShakeRequest> _requests = new();
        private CinemachineBasicMultiChannelPerlin _noise;

        [SerializeField] private float _shakeDecreaseAmount = 10f;

        private void Awake() {
            _noise = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update() {
            if (_requests.Count == 0) {
                _noise.m_AmplitudeGain = 0;
                return;
            }

            var strongestShake = _requests.Max(shake => shake.ShakeAmount);
            _noise.m_AmplitudeGain = strongestShake;

            for (var i = _requests.Count - 1; i >= 0; i--) {
                var requeat = _requests[i];
                requeat.ShakeTime -= Time.deltaTime;

                if (requeat.ShakeTime <= 0) {
                    requeat.ShakeAmount = Mathf.Max(0, requeat.ShakeAmount - Time.deltaTime * _shakeDecreaseAmount);
                }

                if (requeat.ShakeAmount == 0) _requests.Remove(requeat);
            }
        }

        public void RequestShake(float amount, float time) {
            _requests.Add(new ShakeRequest { 
                ShakeAmount = amount,
                ShakeTime = time
            });
        }

        private class ShakeRequest {
            public float ShakeAmount { get; set; }
            public float ShakeTime { get; set; }

        }
}
}

