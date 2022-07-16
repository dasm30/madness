using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    KeyCode[] letters = new KeyCode[] {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
    [SerializeField] KeyCode[] currentInputs = new KeyCode[3] { KeyCode.Z, KeyCode.X, KeyCode.C };
    KeyCode[] availableInputs = new KeyCode[23];
    List<KeyCode> nextInputs = new List<KeyCode>();
    [SerializeField] TMP_Text[] textInputs;

    public bool Kick { get; set; }
    public bool Punch { get; set; }
    public bool DiveKick { get; set; }

    public bool Jump { get; set; }

    void Awake() {
         if (Instance != null && Instance != this) { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 
    }

    void Start()
    {
        SetupNewInputs();
        EventManager.TimedEvent += GetNewInputsEvent;
    }

    void OnDisable() {
        EventManager.TimedEvent -= GetNewInputsEvent;
    }

    void Update()
    {
        Punch = Input.GetKeyDown(currentInputs[0]);
        Kick = Input.GetKeyDown(currentInputs[1]);
        DiveKick = Input.GetKeyDown(currentInputs[2]);
        Jump = Input.GetKeyDown(KeyCode.Space);
    }

    void GetNewInputsEvent() {
        GetNewInputs(nextInputs);
    }

    void SetAvailableInputs() {
        availableInputs = letters.Where(letter => !currentInputs.Concat(nextInputs).Contains(letter)).ToArray();
    }

    KeyCode[] GetNewInputs(List<KeyCode> inputs) {
        SetAvailableInputs();
        KeyCode newInput = availableInputs[Random.Range(0, availableInputs.Length)];
        nextInputs.Add(newInput);
        if (nextInputs.Count < 3) {
            nextInputs = GetNewInputs(nextInputs).ToList();
        }
        currentInputs = nextInputs.ToArray();
        nextInputs = new List<KeyCode>();
        SetupNewInputs();
        return currentInputs;
    }

    void SetupNewInputs() {
        for(int i = 0; i < textInputs.Length; i++) {
            textInputs[i].text = currentInputs[i].ToString();
        }
    }
}
