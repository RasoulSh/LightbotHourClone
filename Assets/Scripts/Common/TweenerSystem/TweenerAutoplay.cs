using Common.CommonEnums;
using LightbotHour.Common.TweenerSystem.Enums;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem
{
    [RequireComponent(typeof(Tweener))]
    public class TweenerAutoplay : MonoBehaviour
    {
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
            var tweener = GetComponent<Tweener>();
            tweener.Play(playOrder, direction);
        }
    }
}