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
        private float _timer;

        private void Start()
        {
            text.text = _price.ToString();
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                _timer += Time.smoothDeltaTime;

                if(_timer > 0.1f)
                {
                    _payedAmounth++;
                    text.text = (_price - _payedAmounth).ToString();
                    ScoreSignals.Instance.onDecreaseMoney();
                    OpenForceField();
                    _timer = 0;
                }
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