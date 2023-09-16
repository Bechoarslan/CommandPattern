using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class WaypointCommand : Command
    {
       
        public override void Execute()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.SphereCast(ray, 0.5f, out RaycastHit hit)) ;
            {
                var listOfWaypoint = Resources.Load<CD_Hit>("CD_Hit")._data;
                listOfWaypoint.ListOfHitPoints.Add(hit.point);
                CommandManager.Instance.AddComand(this);
                

            }
        }

        

        public override void Undo()
        {
            
            var listOfWaypoint = Resources.Load<CD_Hit>("CD_Hit")._data;
            if(listOfWaypoint.ListOfHitPoints.Count <=0 || listOfWaypoint.ListOfHitPoints == null)
                return;
            listOfWaypoint.ListOfHitPoints.RemoveAt(listOfWaypoint.ListOfHitPoints.Count - 1);
        }
    }
}