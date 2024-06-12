using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrophyPiece : MonoBehaviour, IPointerClickHandler
{
    private Vector3 _initialWorldPosition;
    private Vector3 _initialWorldRotation;
    private Trophy _trophy;
    
    private Coroutine _moveCoroutine;

    private void Awake()
    {
        var t = transform;
        _initialWorldPosition = t.position;
        _initialWorldRotation = t.eulerAngles;
    }
    
    public void SetupTrophy(Trophy trophy)
    {
        _trophy = trophy;
    }
    
    public void MoveTransform(Transform target)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
        
        _moveCoroutine = StartCoroutine(MoveToPosition(target.position, target.eulerAngles, 0.25f));
        
        return;
        var t = transform;
        t.position = target.position;
        t.eulerAngles = target.eulerAngles;
    }
    
    public void ResetTransform()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
        
        _moveCoroutine = StartCoroutine(MoveToPosition(_initialWorldPosition, _initialWorldRotation, 0.25f));
        
        return;
        var t = transform;
        t.position = _initialWorldPosition;
        t.eulerAngles = _initialWorldRotation;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _trophy.InteractWithPiece(this);
    }
    
    private IEnumerator MoveToPosition(Vector3 position, Vector3 rotation, float duration)
    {
        var t = transform;
        var startPosition = t.position;
        var startRotation = t.eulerAngles;
        
        var time = 0f;
        while (time < duration)
        {
            t.position = Vector3.Lerp(startPosition, position, time / duration);
            t.eulerAngles = Vector3.Lerp(startRotation, rotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        t.position = position;
        t.eulerAngles = rotation;
    }
}