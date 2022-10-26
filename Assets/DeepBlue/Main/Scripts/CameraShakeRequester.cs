using UnityEngine;


namespace DeepBlue.Engine {
    public class CameraShakeRequester : MonoBehaviour
    {
        [SerializeField] private float _ShakeAmount;

        [SerializeField] float _ShakeTime;

        [SerializeField] CameraShake _shaker;

        public void RequestShake() {
            _shaker.RequestShake(_ShakeAmount, _ShakeTime);
        }
    }
}

