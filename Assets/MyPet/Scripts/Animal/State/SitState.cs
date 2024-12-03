using UnityEngine;

namespace MyPet.AI
{
    public class SitState : State<AnimalController>
    {
        #region Variables

        private Animator animator;
        //private CharacterController characterController;
        //private NavMeshAgent agent;
        protected int isSitHash = Animator.StringToHash("IsSit");
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
            animator.SetBool(isSitHash, true);
        }

        public override void Update(float deltaTime)
        {

        }

        public override void OnExit()
        {
            animator.SetBool(isSitHash, false);
        }
    }
}