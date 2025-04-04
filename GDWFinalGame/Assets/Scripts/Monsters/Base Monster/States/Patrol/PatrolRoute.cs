using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PatrolRoute : MonoBehaviour
{
   [SerializeField] List<WayPoint> waypoints = new List<WayPoint>();
   [SerializeField]  Monster monster;
   [SerializeField] private float coolDownTimer;
   private bool cd = false;
   private int currentWayPointIndex = 0;//holds which waypoint the monster is currently at
   
   /// <summary>
   /// Updates the currentWayPointIndex if the monster is close to the desired 
   /// </summary>
   public void SetMonsterCurrentWayPoint()
   {
       //sets the monster to go back to the original wayPoint
       if (currentWayPointIndex == waypoints.Count)
       {
           currentWayPointIndex = 0;
       }
       
       if (Vector3.Distance(monster.transform.position, waypoints[currentWayPointIndex].transform.position) < 1f)
       {
           if (cd == false)
           {
               currentWayPointIndex++;
               cd = true;
           }
           
           Invoke(nameof(ResetCoolDown), coolDownTimer);
       }

   }

   public Vector3 GetCurrentWayPoint()
   {
       return waypoints[currentWayPointIndex].transform.position;
   }

   public bool GetCoolDown()
   {
       return cd;
   }

   void ResetCoolDown()
   {
       cd = false;
   }
   
}
