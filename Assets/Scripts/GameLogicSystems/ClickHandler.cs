using Assets.Scripts.Circle;
using UnityEngine;

namespace Assets.Scripts.GameLogicSystems
{
    public class ClickHandler : MonoBehaviour
    {
        [SerializeField] private float _zPointPosiztion;
        [SerializeField] private CircleMover _circleMover;
        [SerializeField] private ClickVisualizer _clickVisualizer;

        private Camera _mainCamera;

        public void Init()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                var clickPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = _zPointPosiztion;
                _circleMover.AddPoint(clickPosition);
                _clickVisualizer.Visualize(clickPosition);
            }
        }
    }
}