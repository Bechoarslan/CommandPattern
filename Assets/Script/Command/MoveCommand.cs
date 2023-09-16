using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class MoveCommand : Command
    {
        private NavMeshAgent _navMeshAgent;
        private bool _isMoving;
        private int _currentWaypointIndex;
        

        public MoveCommand(bool isReadyToMove, NavMeshAgent navMeshAgent, int currentWaypointIndex)
        {
            _isMoving = isReadyToMove;
            _navMeshAgent = navMeshAgent;
            _currentWaypointIndex = currentWaypointIndex;
        }


        public override void Execute()
        {
            var waypointData = Resources.Load<CD_Hit>("CD_Hit")._data;
            _navMeshAgent.SetDestination(waypointData.ListOfHitPoints[_currentWaypointIndex]);
            if (_currentWaypointIndex >= waypointData.ListOfHitPoints.Count)
            {
                _isMoving = false;
            }







        }

       


        public override void Undo()
        {
            


        }
    }
}