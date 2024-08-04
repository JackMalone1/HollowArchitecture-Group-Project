=== mutant_introduction ===
You go back outside. The village is even more deserted than when you arrived. 
The VARIANT is still standing where you left them, eyes gazing at nothing in particular. With a vacant expression like that, surely they can't be intelligent enough to be involved in the kidnapping...can they?
+[Hey, can I ask you some questions?]
-> mutant_dialogue


=== mutant_dialogue ===
#speaker:YOU
"Can I ask you a few questions about the girl that's recently gone missing around here?"
#speaker:VARIANT
"Are you working with the people from the town so you can drive the rest of us out of here?"
The Variant seems CONFIDENT and HOSTILE.
+[Be friendly]
-> variant_info_right
+[Be accusatory]
-> variant_info_wrong

=== variant_info_right === //clue:witness
#speaker:YOU
"I have no judgements about this place and I'm not trying to pin this on you."
#speaker:VARIANT
"You'd be the first. The town has been trying to get rid of us forever, but this is our home too so we're just doing what we can to survive. That girl and her witch friends didn't like us much either."
+[Witches?]
-> variant_info_2

== variant_info_wrong ===
#speaker:YOU 
"The townspeople seem to think you could have something to do with the missing girl."
#speaker:VARIANT 
"Look at you, coming in all guns blazing. You know nothing about this place."

The Variant doesn't trust you. Try again. 
+[Back off]
-> variant_info_right
+[Stand your ground]
#speaker:YOU 
"The townspeople are terrified of you, they must have a good reason to be."
#speaker:VARIANT 
"They're just afraid of what they don't understand. Like you."
-> variant_conclusion

=== variant_info_2 ===
#speaker:VARIANT 
"A cult, more like. They're the ones stealing children."

*[Stealing children?] -> variant_info_2A

=== variant_info_2A ===
#speaker:VARIANT 
"Whatever, it's just a rumour. Go ask them about it - they live in the swamp like real savages. At least I have a proper house."

-> variant_conclusion

=== variant_conclusion ===
All these people hating each other and still living so close together. Was Lena really taken, or did she leave of her own accord?
   { - variant_info_right:
  
    Sounds like the witches at the edge of town could have seen her recently.
    
    You have found 1/1 clue: 
    PLACE: Swamp
    +[NEW PLACE: Swamp]
        -> witch_introduction
    - else:
    This Variant doesn't want to talk to you anymore. 
    
    You haven't found any clues. Restart the conversation? 
    +[Go back]
        -> mutant_dialogue
    }
    