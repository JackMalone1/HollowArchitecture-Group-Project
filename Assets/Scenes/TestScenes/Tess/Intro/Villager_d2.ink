=== villager_introduction ===
The swamp seemed even more foreboding as you and the Elder make your way throught he mist, guided by a small light spell that she conjured. The trees loom overhead. Suddenly, you spot a the faint outline of a villager ahead, and a lantern softly glowing.
+[NEW WITNESS: villager]
#speaker:YOU 
"Have you seen a young girl come by here in the last few days?"
-> villager_dialogue

=== villager_dialogue ===
#speaker:VILLAGER 
"I saw her pass by with a stranger earlier."

The villager seems SCARED and WARY. 

+[Ask for more info]
#speaker:YOU 
"What did the stranger look like?"
-> villager_info_wrong1
+[Let the Elder speak]
#speaker:ELDER
"It's alright, I'll protect you. Against this outsider as well."

They both glance at you. 
-> villager_info_right1


=== villager_info_wrong1 ===
#speaker:VILLAGER 
"Look, I don't know you. If that kid's in danger, you could be it."

The villager doesn't trust you. Try again.
{ - villager_info_right1:
+[Back off] 
#speaker:YOU 
"You're right to be mistrustful. You'll have to decide if you think me or that stranger is the bigger threat to Lena, but time is not on our side."
-> villager_info_right2
+[Be defensive] 
#speaker:YOU 
"You people are infuriating! I don't know how to get you to trust me, but you have to if we want to have any chance of finding Lena."
-> villager_info_wrong2
    - else:
+[Share your motivations] 
#speaker:YOU 
"I'm doing this as a favour for Lena's mother because she has some information I need. If I harm anyone, I'm not getting that info."
-> villager_info_right1
+[Stress urgency] 
#speaker:YOU 
"I don't know how to get you to trust me, but you have to if we want to have any chance of finding Lena. We don't have time for this!"
-> villager_info_wrong2
}


=== villager_info_right1 === //clue:SUSPECT
#speaker:VILLAGER 
"It was a man, dressed in dark robes and whispering in her ear. He appeared out of nowhere and I swear his eyes were glowing..."
+[Where did they go?]
-> villager_info2


=== villager_info_wrong2 ===
#speaker:VILLAGER 
"Forget it, you could be one of them for all I know."
-> villager_conclusion


=== villager_info2 ===
The villager looks at the Elder.
#speaker:VILLAGER
"Do you trust this outsider?"

{ - villager_info_wrong1:
+[Let the Elder speak] 
#speaker:ELDER 
"They have shown no ill intent so far. I cannot speak for their intelligence, though."
-> villager_info_right2
+[Prove yourself] 
#speaker:YOU 
"I have done nothing to warrant such suspicion! The girl is in danger - her mother asked me to help!"
-> villager_info_wrong2
    - else:
+[Let the Elder speak]
#speaker:ELDER 
"They have shown no ill intent so far. I cannot speak for their intelligence, though."
-> villager_info_right2
+[Prove yourself] 
#speaker:YOU 
"I have done nothing to warrant such suspicion! The girl is in danger - her mother asked me to help!"
-> villager_info_wrong1
}


=== villager_info_right2 === //clue:PLACE
#speaker:VILLAGER 
"Well honestly, I'm glad you came. I tried to follow them but the mist has become so thick I lost them and then I lost myself."
#speaker:ELDER 
"This is the path to the Altar. The ancient power surrounding it may be allowing them to hide within the mist..."
-> villager_conclusion

=== villager_conclusion ===
{ - villager_info_right2:
You have found 3/3 clues
WITNESS: Villager
SUSPECT: Robed Man 
PLACE: Altar

+[NEW PLACE: Altar] -> suspect_introduction

    - else: 
    You haven't found any clues. Restart the conversation? 
+[Go Back] -> villager_introduction

}
    