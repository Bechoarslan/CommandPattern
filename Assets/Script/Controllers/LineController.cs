using Script.Signals;
using UnityEngine;

namespace Script
{
    public class LineController : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform playerTransform;
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onWaypointSettled += OnWaypointSettled;
        }

        private void OnWaypointSettled()
        {
            var lineCommand = new LineCommand(lineRenderer,playerTransform);
            lineCommand.Execute();
        }

        private void OnDisable()
        {
            UnSubscribeEvent();
        }

        private void UnSubscribeEvent()
        {
            CoreGameSignals.Instance.onWaypointSettled -= OnWaypointSettled;
        }
    }
}