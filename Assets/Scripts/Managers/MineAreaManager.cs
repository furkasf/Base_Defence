using Data.ValueObject;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class MineAreaManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> Minepositions;
        [SerializeField] private List<Transform> miners;
        [SerializeField] private Transform mineStorage;
        [SerializeField] private Transform mineWagon;
        [SerializeField] private TMP_Text text;

        private MineBaseData data;

        private void GetMiner(Transform miner)
        {
            if (!miners.Contains(miner) && data.CurrentWorkerNumber <= data.MaxWorkerNumber)
            {
                miners.Add(miner);
                data.CurrentWorkerNumber += 1;
                text.text = data.MaxWorkerNumber.ToString() + " / " + data.CurrentWorkerNumber.ToString();
            }
        }

        private void AsignMinerToMine()
        {
            for (int i = 0; i < Minepositions.Count; i++)
            {
                if (i >= miners.Count)
                {
                    break;
                }
                miners[i] = Minepositions[i];
            }
        }
    }
}