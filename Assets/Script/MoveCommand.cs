using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class MoveCommand : Command
    {
        
        private NavMeshAgent _navMeshAgent;
        private Vector3 playerPosition;
        public MoveCommand(NavMeshAgent navMeshAgent, Vector3 playerTransform)
        {
            playerPosition = playerTransform;
            _navMeshAgent = navMeshAgent;
        }


        public override void Execute()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                _navMeshAgent.SetDestination(hit.point);
                playerPosition = _navMeshAgent.transform.position;
                Debug.Log(playerPosition);
                
                CommandManager.Instance.AddComand(this);
            }




        }

        

        public override void Undo()
        {
            _navMeshAgent.SetDestination(playerPosition);


        }
    }
}