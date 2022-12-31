using Common.CommonEnums;
using LightbotHour.Common.TweenerSystem.Enums;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem
{
    public class TweenerAutoplay : MonoBehaviour
    {
        [SerializeField] private Tweener tweener;
        [SerializeField] private ExecuteOrder executeOrder = ExecuteOrder.None;
        [SerializeField] private TweenerDirection direction = TweenerDirection.Forward;
        [SerializeField] private TweenerPlayOrder playOrder = TweenerPlayOrder.Once;
        
        public ExecuteOrder ExecuteOrder
        {
            get => executeOrder;
            set => executeOrder = value;
        }

        public TweenerDirection Direction
        {
            get => direction;
            set => direction = value;
        }

        public TweenerPlayOrder PlayOrder
        {
            get => playOrder;
            set => playOrder = value;
        }
        
        protected virtual void Awake()
        {
            if (executeOrder == ExecuteOrder.OnAwake)
                Execute();
        }
        
        protected virtual void Start()
        {
            if (executeOrder == ExecuteOrder.OnStart)
                Execute();
        }
        protected virtual void OnEnable()
        {
            if (executeOrder == ExecuteOrder.OnEnable)
                Execute();
        }
        
        private void Execute()
        {
            if (tweener == null)
            {
                tweener = GetComponent<Tweener>();
            }
            if (tweener == null)
            {
                Debug.LogError("There is no tweener to play");
                return;
            }
            tweener.Play(playOrder, direction);
        }
    }
}