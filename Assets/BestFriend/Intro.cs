using Cysharp.Threading.Tasks;
using UnityEngine;

public class Intro : MonoBehaviour
{
   // [Header("AI Messages")]
    [TextArea] [SerializeField]
    private string greetings, wannaBeFriends, askName, askAge, askGender;

    [SerializeField] private Typewriter typewriter;
    [SerializeField] private PlayerInput nameField;

    private void Awake() {
        nameField.gameObject.SetActive( false);
    }

    private async void Start() {
        await typewriter.TypeAsNew(greetings);
        await UniTask.Delay(2000);
        typewriter.Close();
      
        await UniTask.Delay(1000);
        
        typewriter.Open();
        await typewriter.TypeAsNew(wannaBeFriends);
        await UniTask.Delay(2000);
        typewriter.Close();
        
        await UniTask.Delay(1000);
        
        typewriter.Open();
        await typewriter.TypeAsNew(askName);
        
        nameField.Open();
        var playerName = await nameField.AwaitEnter();
        nameField.Close();
        typewriter.Close();

        await UniTask.Delay(1000);
        typewriter.Open();
        await typewriter.TypeAsNew(askAge.Replace("#name",playerName ));
        await nameField.AwaitEnter();
    }
}
