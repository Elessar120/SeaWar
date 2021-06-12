using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarHealthController : MonoBehaviour
    {
        public void TakeDamage(float damage)
        {
            if (GetComponent<SeaWarRadioActiveTowerView>().health > 0)
            {
                GetComponent<SeaWarRadioActiveTowerView>().health -= damage;
            }
            else
            {
                GetComponent<SeaWarRadioActiveTowerView>().health = 0f;
                Death();
      
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}