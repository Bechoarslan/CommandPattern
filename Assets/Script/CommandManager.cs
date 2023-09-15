using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class CommandManager : MonoBehaviour
    {
        public static CommandManager Instance;
        private Stack<Command> _command = new Stack<Command>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }


        public void AddComand(Command command)
        {
            _command.Push(command);
    
            
        }


        public void UndoCommand()
        {
            if (_command.Count == 0) return;
            var lastCommand = _command.Pop();
            lastCommand.Undo();
            

        }
    }
}