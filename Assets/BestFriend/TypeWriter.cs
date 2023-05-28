using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public static class TypeWriterExtensions
{
   public static async UniTask TypeWithDelay(this TMP_Text textField, string message, int durationMilliseconds) {
      foreach (var character in message) {
         textField.text += character;
         await UniTask.Delay(durationMilliseconds);
      }
   }

   public static async UniTask TypeWithRandomDelay(this TMP_Text textField, string message, int minMilliseconds, int maxMilliseconds) {
      foreach (var character in message) {
         textField.text += character;
         await UniTask.Delay(Random.Range(minMilliseconds, maxMilliseconds));
      }
   }
}
