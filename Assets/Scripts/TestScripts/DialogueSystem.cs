using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace TestScripts
{
    public class DialogueSystem : MonoBehaviour
    {
        public static event Action<Story> OnCreateStory;
        private static DialogueSystem instance;
        
        private DialogueVariables dialogueVariables;
        private InkExternalFunctions inkExternalFunctions;
        
        [Header("Load Globals JSON")]
        [SerializeField] private TextAsset loadGlobalsJSON;
        
        [Header("Dialogue UI")]
		[SerializeField] private GameObject dialoguePanel;
		[SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Animator portraitAnimator;
        [SerializeField] private TextMeshProUGUI displayNameText;
        
        private const string SPEAKER_TAG = "speaker";
        private const string PORTRAIT_TAG = "portrait";

        public bool isDialoguePlaying = true;
	
	    void Awake () {
		    if (instance != null)
		    {
			    Debug.LogWarning("Found more than one Dialogue Manager in the scene");
		    }
		    instance = this;
		    
		    dialogueVariables = new DialogueVariables(loadGlobalsJSON);
		    inkExternalFunctions = new InkExternalFunctions();
		    
		    // Remove the default message
			RemoveChildren();
			StartStory();
		}

	    public static DialogueSystem GetInstance()
	    {
		    return instance;
	    }

	    public void StopStory()
	    {
		    RemoveChildren();
	    }

		// Creates a new Story object with the compiled story which we can then play!
		void StartStory () {
			story = new Story (inkJSONAsset.text);
			
			dialogueVariables.StartListening(story);
			inkExternalFunctions.BindForthcoming(story, new PlayerState());
			
	        if(OnCreateStory != null) OnCreateStory(story);
			RefreshView();
		}
		
		// This is the main function called every time the story changes. It does a few things:
		// Destroys all the old content and choices.
		// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
		void RefreshView () {
			// Remove all the UI on screen
			RemoveChildren ();
			
			// Read all the content until we can't continue any more
			while (story.canContinue) {
				// Continue gets the next line of the story
				string text = story.Continue ();
				// This removes any white space from the text.
				text = text.Trim();
				// Display the text on screen!
				HandleTags(story.currentTags);
				CreateContentView(text);
				
				
				
			}

			// Display all the choices, if there are any!
			if(story.currentChoices.Count > 0) {
				for (int i = 0; i < story.currentChoices.Count; i++) {
					Choice choice = story.currentChoices [i];
					Button button = CreateChoiceView (choice.text.Trim ());
					// Tell the button what to do when we press it
					button.onClick.AddListener (delegate {
						OnClickChoiceButton (choice);
					});
				}
			}
			// If we've read all the content and there's no choices, the story is finished!
			else {
				Button choice = CreateChoiceView("End of story.\nRestart?");
				inkExternalFunctions.UnBind(story);
				choice.onClick.AddListener(delegate{
					StartStory();
				});
			}
		}
		
		private void HandleTags(List<string> currentTags)
		{
			// loop through each tag and handle it accordingly
			foreach (string tag in currentTags) 
			{
				// parse the tag
				string[] splitTag = tag.Split(':');
				if (splitTag.Length != 2) 
				{
					Debug.LogError("Tag could not be appropriately parsed: " + tag);
				}
				string tagKey = splitTag[0].Trim();
				string tagValue = splitTag[1].Trim();
            
				// handle the tag
				switch (tagKey) 
				{
					case SPEAKER_TAG:
						displayNameText.text = tagValue;
						string text = tagValue;
						// This removes any white space from the text.
						text = text.Trim();
						// Display the text on screen!
						CreateContentView(text);
						break;
					case PORTRAIT_TAG:
						portraitAnimator.Play(tagValue);
						break;
					default:
						Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
						break;
				}
			}
		}

		// When we click the choice button, tell the story to choose that choice!
		void OnClickChoiceButton (Choice choice) {
			story.ChooseChoiceIndex (choice.index);
			RefreshView();
		}

		// Creates a textbox showing the the line of text
		void CreateContentView (string text) {
			Text dialogueText = Instantiate (textPrefab) as Text;
			dialogueText.text = text;
			dialogueText.transform.SetParent (canvas.transform, false);
		}


		// Creates a button showing the choice text
		Button CreateChoiceView (string text) {
			// Creates the button from a prefab
			Button choice = Instantiate (buttonPrefab) as Button;
			choice.transform.SetParent (canvas.transform, false);
			
			// Gets the text from the button prefab
			Text choiceText = choice.GetComponentInChildren<Text> ();
			choiceText.text = text;

			// Make the button expand to fit the text
			HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
			layoutGroup.childForceExpandHeight = false;

			return choice;
		}

		// Destroys all the children of this gameobject (all the UI)
		void RemoveChildren () {

			int childCount = canvas.transform.childCount;
			for (int i = childCount - 1; i >= 0; --i) {
				Destroy (canvas.transform.GetChild (i).gameObject);
			}
		}

		[SerializeField]
		private TextAsset inkJSONAsset = null;
		public Story story;

		[SerializeField]
		private Canvas canvas = null;

		// UI Prefabs
		[SerializeField]
		private Text textPrefab = null;
		[SerializeField]
		private Button buttonPrefab = null;
	}
}