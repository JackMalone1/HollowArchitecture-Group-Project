using System.Reflection;
using Ink.Runtime;

namespace TestScripts
{
    public class InkExternalFunctions
    {
        
        public void BindForthcoming(Story story, PlayerState state)
        {
            story.BindExternalFunction("changeForthcoming", (int amount) => state.Forthcoming += amount);
        }
        
        public void UnBind(Story story)
        {
            story?.UnbindExternalFunction("changeForthcoming");
        }
    }
}