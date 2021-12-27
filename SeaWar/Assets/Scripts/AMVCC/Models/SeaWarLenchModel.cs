using UnityEngine;
using UnityEngine.Serialization;

namespace AMVCC.Models
{
    public class SeaWarLenchModel : MonoBehaviour
    {
        public Unit lenchData;
        public float health;
        public float fireRate;
        public float sightRange;
        public float costWithOil;
        public int upgradeCost;
        public float damage;
        public float speed;
        public float cost;

        private void Awake()
        {
            damage = lenchData.damage;
            speed = lenchData.movmentSpeed;
            health = lenchData.health;
            fireRate = lenchData.fireRate;
            sightRange = lenchData.sightRange;
            costWithOil = lenchData.costWithOil;
            upgradeCost = lenchData.upgradeCardsNeed;
            cost = lenchData.costWithOil;

        }
    }
}