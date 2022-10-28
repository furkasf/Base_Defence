using Assets.Scripts.Signals;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ForceFieldController : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] GameObject fiald;

        private const int _price = 50;
        private int _payedAmounth;

        private void Start()
        {
            text.text = _price.ToString();
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Debug.Log("player inside force field");
                _payedAmounth++;
                text.text = (_price - 1).ToString();
                ScoreSignals.Instance.onDecreaseMoney();
                OpenForceField();
            }
        }

        private void OpenForceField()
        {
            if(CheakPaymentDone())
            {
                gameObject.SetActive(false);
                fiald.SetActive(false);
            }
        }

        private bool CheakPaymentDone() => _payedAmounth >= _price;
    }
}