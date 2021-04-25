using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSubmarineFightController : SeaWarElement
    {
        private void Update()
        {
            //DelayBetweenAttacks();

        }

        
        private void OnTriggerEnter(Collider other)
        {
            GetComponent<SeaWarSubmarineFightView>().enemyCollider = other;
            ActivateAttackModeWhenEnemyIsInRange(other);
        }
        
        public void ActivateAttackModeWhenEnemyIsInRange(Collider other)
        {
            Debug.Log(Application.model.submarineModel.shootableMask);
            
            if (!other.CompareTag(GetComponent<SeaWarSubmarineFightView>().myTag))
            {
                GetComponent<SeaWarSubmarineFightView>().haunting = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(GetComponent<SeaWarSubmarineFightView>().myTag))
            {
                if (other.name == "Submarin" || other.name == "OilTanker" || other.name == "BattleShip" || other.name == "SmallBattleship" || other.name == "MotorBoat")
                {
                    if (other == GetComponent<SeaWarSubmarineFightView>().enemyCollider)
                    {
                        GetComponent<SeaWarSubmarineFightView>().haunting = true;
                        Chase();
                        DelayBetweenAttacks(other);

                    }

                }
            }
        }

        private void Chase()
        {
            GetComponent<SeaWarSubmarineFightView>().isChasing = true;
            if (!gameObject.GetComponent<SeaWarSubmarineView>().submarineRotationAnimator
                .GetBool("isInRotateMod"))
            {
                //Debug.Log(gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineRotationAnimator.GetBool("isInRotateMod"));
                if (GetComponent<SeaWarSubmarineFightView>().haunting)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        new Vector3(GetComponent<SeaWarSubmarineFightView>().enemyCollider.transform.position.x,
                            gameObject.transform.position.y, gameObject.transform.position.z),
                        Time.deltaTime * Application.model.submarineModel.submarineData.movmentSpeed);

                }

                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        GetComponent<SeaWarSubmarineView>().startPosition,
                        Time.deltaTime * Application.model.submarineModel.submarineData.movmentSpeed);
                }

            }
        }

        public void DelayBetweenAttacks(Collider enemyCollider)
        {
            if (GetComponent<SeaWarSubmarineFightView>().haunting)
            {
                SeaWarSubmarineFightView instance = GetComponent<SeaWarSubmarineFightView>();
                if (instance.isAttackTime)
                {
                    Attack(Application.model.submarineModel.submarineData.damage, enemyCollider); 
                    instance.isAttackTime = false;
                }
                
                instance.fireRate -= Time.time;
                
                if (instance.fireRate < 0)
                {
                    instance.fireRate = Application.model.submarineModel.submarineData.fireRate;
                    instance.isAttackTime = true;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other == GetComponent<SeaWarSubmarineFightView>().enemyCollider)
            {
                DeActivateAttackMode(other);
                GetComponent<SeaWarSubmarineFightView>().isChasing = false;

            }
            
        }
        public void DeActivateAttackMode(Collider other)
        {
            GetComponent<SeaWarSubmarineFightView>().haunting = false;
        }
        public void Attack(float damage, Collider enemyCollider)
        {
            enemyCollider.GetComponent<SeaWarSubmarineFightController>().TakeDamage(damage);
        }
        public void TakeDamage(float damage)
        {
            SeaWarSubmarineFightView instance = GetComponent<SeaWarSubmarineFightView>();
            
            if (instance.health > 0)
            {
                instance.health -= damage;
            
            }
            else
            {
                instance.health = 0;
                GetComponent<SeaWarSubmarineFightView>().isChasing = false;
                Destroy(gameObject);
                GetComponent<SeaWarSubmarineFightView>().haunting = false;

            }
            
        }

       
        
       

        private void OnDestroy()
        {
            
        }
    }
}