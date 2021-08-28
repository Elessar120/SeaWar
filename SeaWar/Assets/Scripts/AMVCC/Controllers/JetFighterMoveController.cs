using UnityEngine;
using AMVCC.Views;


namespace AMVCC.Controllers
{
    public class JetFighterMoveController : SeaWarElement
    
    {
        private float speed;

        private void Start()
        {
            speed = GetComponent<SeaWarAttackView>().speed;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
   
  }
}