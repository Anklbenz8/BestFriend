
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerInput : AnimatedView
{
   [SerializeField] private TMP_InputField inputField;
   [SerializeField] private TMP_Text placeholderText;
   [SerializeField] private string placeholderMessage;

   private UniTaskCompletionSource<string> _inputCompletionSource;

   private void Awake() {
       inputField.onSubmit.AddListener(OnEndEdit);
       placeholderText.text = placeholderMessage;
   }
   
   public async UniTask<string> AwaitEnter() {
      _inputCompletionSource = new UniTaskCompletionSource<string>();

     return await _inputCompletionSource.Task;
   }

   private void OnEndEdit(string playerInputText) {
       _inputCompletionSource.TrySetResult(playerInputText);
   }
   
}
