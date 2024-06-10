using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedInvoke : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _delaySeconds = 1;
    [SerializeField] private UnityEvent _onEnableEvent = new();
    
    private void OnEnable()
    {
        StartCoroutine(DelayedInvokeEvent());
    }
    
    private IEnumerator DelayedInvokeEvent()
    {
        if (_delaySeconds > 0)
        {
            yield return new WaitForSeconds(_delaySeconds);
        }
        
        _onEnableEvent.Invoke();
    }
}
