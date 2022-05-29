using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private UnityEvent<CoinComponent> OnCoinTrigger;
        [SerializeField] private UnityEvent OnCrossFinish;


        private void OnTriggerEnter(Collider other)
        {
            var coin = other.GetComponent<CoinComponent>();
            if (coin != null)
            {
                OnCoinTrigger?.Invoke(coin);
                return;
            }

            var finish = other.gameObject.GetComponent<FinishLineComponent>();
            if (finish != null)
            {
                OnCrossFinish?.Invoke();
            }
        }
    }
}