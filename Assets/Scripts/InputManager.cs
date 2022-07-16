using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    KeyCode[] letters = new KeyCode[] {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
    [SerializeField] KeyCode[] currentInputs = new KeyCode[3] { KeyCode.Z, KeyCode.X, KeyCode.C };
    List<KeyCode> nextInputs = new List<KeyCode>();
    [SerializeField] TMP_Text[] textInputs;

    void Start()
    {
        SetupNewInputs();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetNewInputs(nextInputs);
        }
    }

    KeyCode[] GetNewInputs(List<KeyCode> inputs) {
        KeyCode[] availabletInputs = letters.Where(letter => !currentInputs.Contains(letter)).ToArray();
        print(availabletInputs.Length);
        KeyCode newInput = availabletInputs[Random.Range(0, availabletInputs.Length)];
        print(newInput.ToString());
        nextInputs.Add(newInput);
        print(nextInputs.Count);
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
