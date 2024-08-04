=== witch_introduction ===
As you get to the edge of town, the buildings start to fade away and you're left surrounded by dilapidated huts. The swamp is enshrouded by an otherwordly fog that clings to the ground and hangs in the air, casting a perpetual twilight. The trees are twisted and gnarled, their branches reaching out like skeletal fingers and the air is thick with the scent of damp earth and decaying vegetation.

-> swamp_description


=== swamp_description ===

From the few huts, you spot several which seem to have been broken into, left in a state of disarray.

*The Oracle's Cabin
-> oracle_cabin
*The Alchemist's Workshop
-> alchemist_workshop
*The Summoner's Lair
-> summoners_lair
+[NEW WITNESS: Elder] -> witch_dialogue
    


=== oracle_cabin ===

The workshop is stood above a particularly marshy area, connected to a patch of dry land by a rickety wooden bridge. Wind chimes made from bones and shells hang from the eaves, creating a haunting melody.

You should come back here later to investigate. 

*[Go back]
-> swamp_description

=== alchemist_workshop ===

A ramshacked building created by what seems like salvaged wood and metal, it has several chimneys protruding from it's roof emitting shining and strange coloured smoke. You can peer just inside the window and notice complex mechs and machine dominate the space, with shelves of exotic ingredients lining the walls.

You should come back here later to investigate. 
* [Go back]
-> swamp_description

=== summoners_lair ===

You can see that the hut is made from a much darker wood than any of the other houses, with bones scattered throughout. Throughout the structure, there are charms and protections scratched into the building, practically being cramped in to every possible surface.

You should come back here later to investigate. 
*[Go back]
-> swamp_description
    Finally, in the middle of the swamp you see the Elder's hut standing. It is made from ancient, twisted trees and adorned with powerful wards and charms that you can sense, even from here. Inside, shelves have been overturned, books and scrolls scattered across the floor. The atmosphere is tense and foreboding, as if the very swamp itself holds its breath, waiting for what will happen next.
-> witch_dialogue


=== witch_dialogue ===
As you begin to move closer towards the Elder's hut, you see them emerge and start towards you.
-> witch_dialogue_2


=== witch_dialogue_2 ===
#speaker:ELDER 
"You're new around here..."

The Elder sounds CURIOUS and SECRETIVE. 

+[Comment on mess]
#speaker:YOU 
"Your hut appears to have seen better days."
-> witch_info_right1

*[Ask about Lena]
#speaker:YOU 
"Tell me what you know about the missing girl."
-> witch_info_wrong1



=== witch_info_right1 ===
#speaker:ELDER 
"You just can't get the staff nowadays. Doesn't help that kids just wander around here helping themselves to our things."

+[Kids?]
#speaker:YOU 
"Would one of those kids be Lena, the missing girl?"
-> witch_info2

=== witch_info_wrong1 ===
#speaker:ELDER 
"Who are you? Speak to me with such disrespect again and you will not be welcome here."

The Elder doesn't trust you. Try again. 
*[Confront Elder]
#speaker:YOU 
"Who are you to demand respect? I am trying to help this place."
-> witch_info_wrong2
+[Apologise]
#speaker:YOU 
"I'm sorry if I caused offence. Who caused all this mess?"
-> witch_info_right1

=== witch_info2 ===
#speaker:ELDER 
"She was always snooping where she shouldn't be, and my book went missing the same night she disappeared. But I never thought she'd have the audacity to enter my hut, let alone steal from me."

The Elder seems SYMPATHETIC to Lena.
You should ask about the book. 
{ - witch_conclusion:
    Use your INFLUENCE?
    *[Yes]
    -> influence_witch_yes
    *[No]
    -> influence_witch_no
    
- else:
*[Demand information]
-> witch_info_wrong2
+[Be curious]
-> witch_info_right2
}

=== influence_witch_yes ===
+[Be curious]
-> witch_info_right2

=== influence_witch_no ===
*[Demand information]
-> witch_info_wrong2
+[Be curious]
-> witch_info_right2

=== witch_info_wrong2 ===
 { - witch_info_wrong1:
  
    #speaker:ELDER 
    "You and your questions aren't welcome. You must leave now."

        -> witch_conclusion
    - else:
     
    #speaker:ELDER 
    "Who are you? Speak to me with such disrespect again and you will not be welcome here."
    
    The Elder doesn't trust you. Try again. 
    +[Go back]
        -> witch_info2
    }
    
=== witch_info_right2 === //clue:item
#speaker:ELDER 
"It is a very powerful grimoire. It contains spells that can easily overwhelm someone who doesn't understand their potency."
+[Spells?]
-> witch_info_right2B

=== witch_info_right2B ===
#speaker:ELDER 
"There's a powerful enchantment to summon a protector of the village that she could use to drive out the variants. But there is a cost and she couldn't do it alone..."
+[Who would help?]
-> witch_info_right2C

=== witch_info_right2C === //clue:place
#speaker:ELDER 
"I'm not sure who, but I might know where."
-> witch_conclusion

=== witch_conclusion ===
{ - witch_info_right2C:

#speaker:ELDER 
"There's a grove, not far from here. She used to play there, by the old willow tree. It's a place where the veil between worlds is thin."

You have found 2/2 clues
ITEM: Spell book 
PLACE: Grove

+[NEW PLACE: Grove]
-> villager_introduction
    - else:
     
    You haven't found any clues. Restart the conversation?
    +[Go back]
        -> witch_dialogue
}