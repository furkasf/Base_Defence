using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Commannds
{
    public class LevelLoaderCommand 
    {
        /// <summary>
        /// first async level load prototype
        /// <returns></returns>


        public async void LevelLoadAsync(int _levelID, Transform levelHolder, CancellationTokenSource cancellationTokenSource)
        {

            GameObject level = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {_levelID}"), levelHolder) as GameObject;

            try
            {
                Debug.Log("Level Is loaded Succesfully");

            }
            catch when (cancellationTokenSource.Token.IsCancellationRequested)
            {
                Debug.Log("level load task Canceled");
            }
            finally

            {
                if(cancellationTokenSource.Token.IsCancellationRequested)
                {
                    GameObject.Destroy(level);
                    await Task.Yield();
                    cancellationTokenSource = new CancellationTokenSource();
                }
            }
        }
    }
}