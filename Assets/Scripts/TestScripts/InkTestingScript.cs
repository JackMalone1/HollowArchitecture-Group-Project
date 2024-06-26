using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTestingScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    
    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        Debug.Log(loadStoryChunk() );

        for(int i = 0; i < story.currentChoices.Count; i++)
        {
            Debug.Log(story.currentChoices[i].text);
        }

        story.ChooseChoiceIndex(0);

        Debug.Log(loadStoryChunk() );

        Debug.Log(loadStoryChunk() );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
     }
}
