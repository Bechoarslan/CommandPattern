using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
   
   public class PlayerMoveController : MonoBehaviour
   {
       
     [SerializeField] private NavMeshAgent _navMeshAgent;
     private Vector3 _playerTransform;
     


     private void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             var command = new MoveCommand(_navMeshAgent,_playerTransform);
             command.Execute();
         }

         if (Input.GetMouseButtonDown(1))
         {
             CommandManager.Instance.UndoCommand();
         }
     }

    

  
   }

   
}
