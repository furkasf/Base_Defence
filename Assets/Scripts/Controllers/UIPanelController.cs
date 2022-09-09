using Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> panels;

        #endregion Serialized Variables

        #endregion Self Variables


        public void OpenPanel(UIPanels panelParam)
        {
            panels[(int)panelParam].SetActive(true);
        }

        public void ClosePanel(UIPanels panelParam)
        {
            panels[(int)panelParam].SetActive(false);
        }
    }
}