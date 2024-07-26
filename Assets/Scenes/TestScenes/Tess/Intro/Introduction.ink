=== introduction ===
You finally finish the 7-day trek through the woods to find yourself in front of the forgotten, dilapidated village. This village has been lost to time by the rest of the world; the people don't seem interested in interacting with the rest of the world. There seems to be nothing left of the simple life and joy that you were told existed here. The abominations have been too regular as of late it seems.
*[Continue]
-> describe_villagers

=== describe_villagers ===
The few villagers that are left appear to be living in a life of squalor.
Everyone ignores your gaze as you attempt to find the person that had asked you here in the first place. 
*[Look around]

->describe_villagers_2
=== describe_villagers_2 ===
As you get to the town hall, you see someone. Not quite human, yet not too different either...
*[Approach them]
 -> info_from_mother


=== info_from_mother ===
You go to approach the stranger, but there is a sudden tight grip on your arm. A haggard woman has rushed over to you, and she yanks you into the crumbling yet imposing town hall.
-> info_from_mother_2
//added a new page here to stop above reprinting every time
=== info_from_mother_2 ===
#speaker:WOMAN
"You don't want to stay out in the town for too long, we can't have the person who's supposed to be finding my daughter getting snatched by a variant, can we?"
She sounds DISTRESSED and SUSPICIOUS. 
Choose your next words wisely to gain her trust and valuable clues.
+[Ask for more info]
-> info_from_mother_wrong
+[Be confident]
"I'm here to help you. Tell me about your daughter."
-> info_from_mother_right

=== info_from_mother_wrong ===
#speaker:YOU
"Wait, who are you?"
#speaker:WOMAN
"I thought you were...wait..."

The witness doesn't trust you, try again. 
+[I'm here to help you.]
#speaker:YOU
"I'm here to help you. Tell me about Lena."
#speaker:WOMAN 
"So they did send you!"
-> info_from_mother_right
+[Don't worry about who I am.]
-> mother_conclusion

=== info_from_mother_right ===

#speaker:WOMAN
"You don't want to stay around those VARIANTS for long. For all we know, that one you were gawking at took my Lena away from me."

+[Variants?]
-> info_from_mother_3

=== info_from_mother_3 ===
#speaker:WOMAN 
"Those kinds are sneaky. It's far too easy for them to have stolen her away from me in the night. If it was up to us, they would have been driven out of here long ago."
+[Continue]
-> mother_conclusion

=== mother_conclusion ===
You get the sense that there is a lot of hostility in this town.
   { - info_from_mother_right:
  
    You don't know if you can trust that this Variant had anything to do with the missing girl, but it's the only lead you have for now.
    
    +[NEW WITNESS: Variant]
        -> mutant_introduction
    - else:
    #speaker:WOMAN
    "Actually, I'm not sure I should be speaking to you..."
    
    The woman hasn't been very forthcoming with you. Restart the conversation? 
    +[Go back]
        -> info_from_mother
    }
    