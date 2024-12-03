using UnityEngine;
using UnityEngine.AI;

namespace MyPet.AI
{
    [System.Serializable]
    public class IdleState : State<AnimalController>
    {
        #region Variables

        private Animator animator;
        //private CharacterController characterController;
        //private NavMeshAgent agent;

        #endregion

        public override void OnInitialize()
        {
            //ÂüÁ¶
            animator = context.GetComponent<Animator>();
            //characterController = context.GetComponent<CharacterController>();
            //agent = context.GetComponent<NavMeshAgent>();
        }

        public override void OnEnter()
        {
            
        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void OnExit()
        {

        }
    }
}