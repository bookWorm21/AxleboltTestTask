using Assets.Scripts.Circle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
    public class ChangingSpeedSlider : MonoBehaviour
    {
        [SerializeField] private CircleMover _circleMover;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _speedLabel;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnSpeedSliderValueChanged);  

        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSpeedSliderValueChanged);
        }

        public void Init()
        {
            _slider.value = (_circleMover.CurrentSpeed - _circleMover.MinSpeed) / (_circleMover.MaxSpeed - _circleMover.MinSpeed);
            _speedLabel.text = _circleMover.CurrentSpeed.ToString();
        }

        private void OnSpeedSliderValueChanged(float value)
        {
            float speed = _circleMover.MinSpeed + value * (_circleMover.MaxSpeed - _circleMover.MinSpeed);
            _circleMover.SetSpeed(speed);
            _speedLabel.text = Mathf.RoundToInt(_circleMover.CurrentSpeed).ToString();
        }
    }
}