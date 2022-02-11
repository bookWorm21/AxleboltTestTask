using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClickVisualizer : MonoBehaviour
    {
        [SerializeField] private float _visualizeTime;
        [SerializeField] private GameObject _rootModel;

        private WaitForSeconds _waiting;

        public void Init()
        {
            _waiting = new WaitForSeconds(_visualizeTime);
            _rootModel.SetActive(false);
        }

        public void Visualize(Vector3 position)
        {
            transform.position = position;
            _rootModel.SetActive(true);
            StartCoroutine(DisableWithDelay());
        }

        private IEnumerator DisableWithDelay()
        {
            yield return _waiting;
            _rootModel.SetActive(false);
        }
    }
}