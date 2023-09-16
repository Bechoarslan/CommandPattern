using System;
using Script.Signals;
using TMPro;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;


namespace Script
{
    public class LineCommand : Command
    {
        private LineRenderer _lineRenderer;
        private Transform _playerTransform;
        public LineCommand(LineRenderer lineRenderer, Transform playerTransform)
        {
            _lineRenderer = lineRenderer;
            _playerTransform = playerTransform;
        }

        public override void Execute()
        {
            var waypointData = Resources.Load<CD_Hit>("CD_Hit")._data.ListOfHitPoints;
            _lineRenderer.gameObject.SetActive(true);

            _lineRenderer.positionCount = 1;
            _lineRenderer.SetPosition(0, _playerTransform.position);
            
                for (int i = 0; i < waypointData.Count ; i++)
                {

                    _lineRenderer.positionCount = waypointData.Count + 1;
                    _lineRenderer.SetPosition(i+1,waypointData[i]);
                    
                    
                    CommandManager.Instance.AddLineRendererCommand(this);
                    
                }
            

        }

        
        public override void Undo()
        {
            _lineRenderer.positionCount -= 1;
        }
    }
}