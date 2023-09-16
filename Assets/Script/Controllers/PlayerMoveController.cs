using System;
using System.Collections.Generic;
using Script.Signals;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{

    public class PlayerMoveController : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent _navMeshAgent;
        private Vector3 _playerTransform;
        [SerializeField] private int currentWaypointIndex;
        [SerializeField] private bool isReadyToMove;







        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(1))
            {
                Debug.LogWarning("Pressed Shift + Right Mouse Button");
                var waypointCommand = new WaypointCommand();
                waypointCommand.Execute();
                CoreGameSignals.Instance.onWaypointSettled?.Invoke();
                

            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                CommandManager.Instance.UndoCommand();
                CommandManager.Instance.UndoCommandLineRenderer();
            }

            if (Input.GetMouseButtonDown(0))
            {
                isReadyToMove = true;
                
                
            }
            StartMovePlayer();

        }


        private void StartMovePlayer()
        {
            var waypointData = Resources.Load<CD_Hit>("CD_Hit")._data;
            if (waypointData.ListOfHitPoints.Count <= 0 || waypointData.ListOfHitPoints == null)
            {
                isReadyToMove = false;
                return;
            }
            if (isReadyToMove)
            {
                var command = new MoveCommand(isReadyToMove, _navMeshAgent, currentWaypointIndex);
                command.Execute();
                if ( !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
                {
                    currentWaypointIndex++;
                    
                }

                
            }
            
            if(currentWaypointIndex >= waypointData.ListOfHitPoints.Count)
            {
                isReadyToMove = false;
                currentWaypointIndex = 0;
                waypointData.ListOfHitPoints.Clear();
            }
            
            
        }
    }
}

