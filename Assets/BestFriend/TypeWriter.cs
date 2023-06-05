
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Typewriter : AnimatedView
{
    private const char PAUSE_CHAR = '~';

    [SerializeField] private int minDelayMilliseconds = 20, maxDelayMilliseconds = 200, pauseMilliseconds = 500;
    [SerializeField] private TMP_Text textField;

    public async UniTask TypeAsNew(string message) {
        textField.text = string.Empty;
        await Type(message);
    }
    public async UniTask Type(string message) {

        foreach (var character in message) {
            if (character == PAUSE_CHAR) {
                await UniTask.Delay(pauseMilliseconds);
                continue;
            }

            textField.text += character;
            await UniTask.Delay(Random.Range(minDelayMilliseconds, maxDelayMilliseconds));
        }
    }

}
