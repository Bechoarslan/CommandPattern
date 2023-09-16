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
        private Stack<Command> _hitPointCommand = new Stack<Command>();
        private Stack<Command> _lineRendererCommand = new Stack<Command>();
       

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
            _hitPointCommand.Push(command);
            
    
            
        }

        public void AddLineRendererCommand(Command command)
        {
            _lineRendererCommand.Push(command);
        }
        public void UndoCommand()
        {
            if (_hitPointCommand.Count == 0) return;
           
            var hitPointCommand = _hitPointCommand.Pop();
            
            hitPointCommand.Undo();
            
        }
        public void UndoCommandLineRenderer()
        {
            if (_lineRendererCommand.Count == 0) return;
           
            var lineRendererComand = _lineRendererCommand.Pop();
            
            lineRendererComand.Undo();
            
        }

       
        
    }
}