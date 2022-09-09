using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PoolTest
{
    public class BulletTest : MonoBehaviour
    {
        GameObject bulletPrefab;


        private GameObject BulletFactoryMethod()
        {
            return Instantiate(bulletPrefab);
        }

        private void TurnOnBullet(GameObject bullet)
        {
            bullet.gameObject.SetActive(true);
        }
        private void TurnOffBullet(GameObject bullet)
        {
            bullet.gameObject.SetActive(false);
        }
    }
}