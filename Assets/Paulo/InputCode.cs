using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputCode : MonoBehaviour
{
    [SerializeField] private TMP_Text _codeText;
    [SerializeField] private char _emptyChar = '_';
    [SerializeField] private string _code = "12345";
    
    [Header("Events")]
    [SerializeField] private UnityEvent _onCorrectCode = new();
    [SerializeField] private UnityEvent _onIncorrectCode = new();
    [SerializeField] private UnityEvent _onStop = new();
    
    private bool _inputEnabled = false;
    private bool _canEscape = false;
    private string _inputCode = "";

    [ContextMenu("Enable Input")]
    public void EnableInput()
    {
        _inputEnabled = true;
        _canEscape = true;
    }
    
    [ContextMenu("Disable Input")]
    public void DisableInput()
    {
        _inputEnabled = false;
    }

    private void OnEnable()
    {
        _inputCode = "";
        UpdateCodeText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableInput();
            _canEscape = false;
            _onStop.Invoke();
        }
        if (!_inputEnabled) return;
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RemoveNumberFromCode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            AddCharToCode('0');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            AddCharToCode('1');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            AddCharToCode('2');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            AddCharToCode('3');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            AddCharToCode('4');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            AddCharToCode('5');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            AddCharToCode('6');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            AddCharToCode('7');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            AddCharToCode('8');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            AddCharToCode('9');
        }
    }
    
    private void AddCharToCode(char value)
    {
        // Add the number to the code
        _inputCode += value;
        
        // Update the code text
        UpdateCodeText();
        
        if (_inputCode.Length == _code.Length)
        {
            CheckCode();
        }
    }
    
    private void RemoveNumberFromCode()
    {
        if (string.IsNullOrEmpty(_inputCode)) return;
        
        // Remove the last number from the code
        _inputCode = _inputCode[..^1];
        
        // Update the code text
        UpdateCodeText();
    }
    
    private void UpdateCodeText()
    {
        // Update the code text
        var text = _inputCode;
        
        // Add empty characters to the code text
        for (var i = 0; i < _code.Length - _inputCode.Length; i++)
        {
            text += _emptyChar;
        }
        
        _codeText.text = text;
    }
    
    private void CheckCode()
    {
        if (_inputCode == _code)
        {
            Debug.Log("Code is correct!");
            _onCorrectCode.Invoke();
        }
        else
        {
            Debug.Log("Code is incorrect!");
            _onIncorrectCode.Invoke();
        }
        
        // Reset the input code
        _inputCode = "";
        _inputEnabled = false;
        UpdateCodeText();
    }
}