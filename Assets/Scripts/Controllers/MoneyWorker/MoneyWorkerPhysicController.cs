using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Controllers.MoneyWorker
{
    public class MoneyWorkerPhysicController : MonoBehaviour
    {
        [SerializeField] private MoneyWorkerManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Money") && !manager.CheackMoneyIsTaken())
            {
                Debug.Log("money is found");
                manager.GetExistedMoney(other.transform);
            }
            if (other.CompareTag("Base"))
            {
                manager.RemoveMoneyFromStack();
            }
        }
    }
}