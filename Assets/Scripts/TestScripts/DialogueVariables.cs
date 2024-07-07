using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using Object = Ink.Runtime.Object;

namespace TestScripts
{
    public class DialogueVariables
    {
        public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

        private Story globalVariablesStory;

        public DialogueVariables(TextAsset loadGlobalsJSON)
        {
            globalVariablesStory = new Story(loadGlobalsJSON.text);

            variables = new Dictionary<string, Object>();

            foreach (string name in globalVariablesStory.variablesState)
            {
                Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
                variables.Add(name, value);
            }
        }
        
        public void StartListening(Story story) 
        {
            // it's important that VariablesToStory is before assigning the listener!
            VariablesToStory(story);
            story.variablesState.variableChangedEvent += VariableChanged;
        }

        public void StopListening(Story story) 
        {
            story.variablesState.variableChangedEvent -= VariableChanged;
        }

        private void VariableChanged(string name, Ink.Runtime.Object value) 
        {
            // only maintain variables that were initialized from the globals ink file
            if (variables.ContainsKey(name)) 
            {
                variables.Remove(name);
                variables.Add(name, value);
            }
        }

        private void VariablesToStory(Story story) 
        {
            foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables) 
            {
                story.variablesState.SetGlobal(variable.Key, variable.Value);
            }
        }
    }
}