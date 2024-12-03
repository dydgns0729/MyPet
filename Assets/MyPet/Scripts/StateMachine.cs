using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    /// <summary>
    /// <T>�� ���¸� �����ϴ� Ŭ����
    /// </summary>
    [System.Serializable]
    public abstract class State<T>
    {
        #region Variables

        protected StateMachine<T> stateMachine; //�� State�� ��ϵ��ִ� Machine
        protected T context;                    //stateMachine�� ������ �ִ� ��ü

        #endregion

        public State() { }                      //������

        public void SetMachineAndContext(StateMachine<T> stateMachine, T context)
        {
            this.stateMachine = stateMachine;
            this.context = context;

            OnInitialize();                     //�ʱⰪ ����
        }

        public virtual void OnInitialize() { }          //������ 1ȸ ����, �ʱⰪ ����

        public virtual void OnEnter() { }               //���� ��ȯ�� ���·� ���ö� 1ȸ ����

        public abstract void Update(float deltaTime);   //���� �������϶� ����

        public virtual void OnExit() { }                //���� ��ȯ�� ���¸� ������ 1ȸ ����

    }

    /// <summary>
    /// <T>�� State���� �����ϴ� Ŭ����
    /// </summary>
    public class StateMachine<T>
    {
        #region Variables
        private T context;                              //StateMachine�� ������ �ִ� ��ü

        private State<T> currentState;                  //���� ����
        public State<T> CurrentState => currentState;

        private State<T> previousState;
        public State<T> PreviousState => previousState;

        private float elapsedTimeInState = 0.0f;        //���� ���� ���� �ð�
        public float ElapsedTimeInState => elapsedTimeInState;

        //��ϵ� ���¸�, ������ Ÿ���� Ű������ �����Ѵ�
        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();
        #endregion

        //������
        public StateMachine(T context, State<T> initialState)
        {
            this.context = context;

            AddState(initialState);
            currentState = initialState;
            currentState.OnEnter();
        }

        //StateMachine�� State ���
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, this.context);
            states[state.GetType()] = state;
        }

        //StateMachine���� State�� ������Ʈ ����
        public void Update(float deltaTime)
        {
            //���ӽð� ����
            elapsedTimeInState += deltaTime;

            currentState.Update(deltaTime);
        }

        //currentState�� ���� �ٲٱ�
        public R ChangeState<R>() where R : State<T>
        {
            //�����¿� ���ο� ���� ��
            var newType = typeof(R);
            if (currentState.GetType() == newType)
            {
                return currentState as R;
            }

            //���°� ����Ǳ����� OnExit ���� / previousState (��������) �� �����ϴ� ������ ������� ����
            if (currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;

            //���º���
            currentState = states[newType];
            currentState.OnEnter();
            elapsedTimeInState = 0.0f;

            return currentState as R;
        }
    }
}