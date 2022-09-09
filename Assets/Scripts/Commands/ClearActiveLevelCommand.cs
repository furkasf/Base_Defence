using System.Threading.Tasks;
using UnityEngine;

namespace Controllers
{
    public class ClearActiveLevelCommand
    {
        public static async void ClearActiveLevelAsync(Transform levelHolder)
        {
            GameObject.Destroy(levelHolder.GetChild(0).gameObject);
            await Task.CompletedTask;
        }
    }
}