using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Trophy : MonoBehaviour
{
    [SerializeField] private List<TrophyPiece> _correctPieceOrder = new();
    
    [FormerlySerializedAs("_finalPositions")]
    [Tooltip("Must be the same size as the correct piece order")]
    [SerializeField] private List<Transform> _finalTransforms = new();
    
    [SerializeField] private bool _startEnabled = false;
    
    [Header("Events")]
    [SerializeField] private UnityEvent _onCorrectTrophy = new();
    [SerializeField] private UnityEvent _onStop = new();
    
    private bool _canInteract = false;
    private bool _canEscape = false;
    private List<TrophyPiece> _placedPieces = new();

    private void OnValidate()
    {
        if (_correctPieceOrder.Count != _finalTransforms.Count)
        {
            Debug.LogError("The correct piece order and final positions must have the same size");
        }
        if (_correctPieceOrder.Contains(null))
        {
            Debug.LogError("The correct piece order cannot have null elements");
        }
        if (_finalTransforms.Contains(null))
        {
            Debug.LogError("The final positions cannot have null elements");
        }
    }
    
    private void Start()
    {
        foreach (var piece in _correctPieceOrder)
        {
            piece.SetupTrophy(this);
        }
        
        if (_startEnabled)
        {
            EnableInteractions();
        }
    }

    private void Update()
    {
        if (_canEscape && Input.GetKeyDown(KeyCode.Escape))
        {
            DisableInteractions();
            _canEscape = false;
            _onStop.Invoke();
        }
    }

    [ContextMenu("Enable Interactions")]
    public void EnableInteractions()
    {
        _canInteract = true;
        _canEscape = true;
    }
    
    [ContextMenu("Disable Interactions")]
    public void DisableInteractions()
    {
        _canInteract = false;
    }

    public void InteractWithPiece(TrophyPiece piece)
    {
        if (!_canInteract) return;
        
        if (_placedPieces.Contains(piece))
        {
            RemovePiece(piece);
        }
        else
        {
            PlacePiece(piece);
        }
    }

    private void PlacePiece(TrophyPiece piece)
    {
        if (_placedPieces.Contains(piece)) return;
        
        piece.MoveTransform(_finalTransforms[_placedPieces.Count]);
        _placedPieces.Add(piece);
        
        CheckTrophy();
    }
    
    private void RemovePiece(TrophyPiece piece)
    {
        if (!_placedPieces.Contains(piece)) return;
        
        piece.ResetTransform();
        var index = _placedPieces.IndexOf(piece);
        _placedPieces.Remove(piece);
        
        // move all the pieces above the removed piece down
        for (var i = index; i < _placedPieces.Count; i++)
        {
            _placedPieces[i].MoveTransform(_finalTransforms[i]);
        }
    }
    
    private void CheckTrophy()
    {
        if (_placedPieces.Count != _correctPieceOrder.Count) return;
        
        for (var i = 0; i < _correctPieceOrder.Count; i++)
        {
            if (_correctPieceOrder[i] != _placedPieces[i])
            {
                return;
            }
        }
        
        Debug.Log("Trophy is correct!");
        _canInteract = false;
        _onCorrectTrophy.Invoke();
    }

    [ContextMenu("Get Trophy Pieces From Children")]
    private void GetTrophyPiecesFromChildren()
    {
        _correctPieceOrder.Clear();
        _finalTransforms.Clear();
        
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out TrophyPiece piece))
            {
                _correctPieceOrder.Add(piece);
                _finalTransforms.Add(null);
            }
        }
    }
}
