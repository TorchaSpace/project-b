using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateController
{
    

    public class StateMachine
    {
        private ICurrentStateHolder currentStateHolder;
        public StateMachine(ICurrentStateHolder h)
        {
            currentStateHolder = h;
        }
        
        
        
        private IState currentState;
   
        private Dictionary<Type, List<StateTransition>> _transitions = new Dictionary<Type,List<StateTransition>>();
        private List<StateTransition> _currentTransitions = new List<StateTransition>();
        private List<StateTransition> _anyTransitions = new List<StateTransition>();
   
        private static List<StateTransition> EmptyTransitions = new List<StateTransition>(0);

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);
      
            currentState?.Tick();
        }
        
        
        public void SetState(IState state)
        {
            if (state == currentState)
                return;
            currentState?.OnExit();
            currentState = state;
            currentStateHolder.CurrentState = currentState;
            _transitions.TryGetValue(currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = EmptyTransitions;
      
            currentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<StateTransition>();
                _transitions[from.GetType()] = transitions;
            }
      
            transitions.Add(new StateTransition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            _anyTransitions.Add(new StateTransition(state, predicate));
        }
        
        
        
        private StateTransition GetTransition()
        {
            foreach(var transition in _anyTransitions)
                if (transition.Condition() && transition.To != currentState)
                {
                    return transition;
                }
                    
      
            foreach (var transition in _currentTransitions)
                if (transition.Condition() && transition.To != currentState)
                    return transition;

            return null;
        }
    }
    
    
    public class StateTransition
    {
        public Func<bool> Condition {get; }
        public IState To { get; }

        public StateTransition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }
    
    
}
