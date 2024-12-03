using UnityEngine;

namespace MyPet.AI
{
    public class DrinkState : State<AnimalController>
    {
        #region Variables

        private Animator animator;

        //animator parameter
        protected int isDrinkHash = Animator.StringToHash("IsDrink");

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
            animator.SetBool(isDrinkHash, true);

        }

        public override void Update(float deltaTime)
        {

        }

        public override void OnExit()
        {
            animator.SetBool(isDrinkHash, false);
        }
    }
}