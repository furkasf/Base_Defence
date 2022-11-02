using UnityEngine.AI;

namespace Assets.Scripts.Extentions
{
    public static class NavmeshAgentExtentions
    {
        public static bool AgentReachTheTarget(this NavMeshAgent agent)
        {
            if (!agent.pathPending)
            {
                var distance = agent.remainingDistance;
                if (distance <= agent.stoppingDistance || distance + 0.5f <= agent.stoppingDistance) // if navmesh land on target well
                {
                    agent.ResetPath();
                    return true;
                }
              
            }
           
            return false;
        }
    }
}