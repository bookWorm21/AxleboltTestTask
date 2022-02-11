using Assets.Scripts.Circle;
using Assets.Scripts.GameLogicSystems;
using Assets.Scripts.Ui;
using UnityEngine;

namespace Assets.Scripts
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private CircleMover _circleMover;
        [SerializeField] private ClickHandler _clickHandler;
        [SerializeField] private ChangingSpeedSlider _changingSpeedSlider;
        [SerializeField] private ClickVisualizer _clickVisualizer;

        private void Start()
        {
            _circleMover.Init();
            _clickHandler.Init();
            _changingSpeedSlider.Init();
            _clickVisualizer.Init();
        }
    }
}