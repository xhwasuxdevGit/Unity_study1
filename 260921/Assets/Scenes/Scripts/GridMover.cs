using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour
{
   private CommandHistory _history = new CommandHistory();

   private void Update()
   {
      ReadMoveKey();
      ReadHistoryKeys();
   }

   private void ReadMoveKey()
   {
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
         Move(Vector3.right);
      }

      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         Move(Vector3.forward);
      }
   }

   private void ReadHistoryKeys()
   {
      if (Input.GetKeyDown(KeyCode.Z))
      {
         _history.UndoCommand();
         LogPosition("실행 취소");
      }

      if (Input.GetKeyDown(KeyCode.Y))
      {
         _history.RedoCommand();
         LogPosition("다시 실행");
      }
   }

   private void Move(Vector3 step)
   {
      _history.ExecuteCommand(new MoveCommand(transform, step));
      LogPosition("이동");
   }

   private void LogPosition(string action)
   {
      Debug.Log($"GridMover: {action} 뒤 x {transform.position.x}, z {transform.position.z}");
   }
}
