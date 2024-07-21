=== witch_introduction ===
As you get to the edge of town, the buildings start to fade away and you're left surrounded by dilapidated huts. The swamp is enshrouded by an otherwordly fog that clings to the ground and hangs in the air, casting a perpetual twilight. The trees are twisted and gnarled, their branches reaching out like skeletal fingers and the air is thick with the scent of damp earth and decaying vegetation.
-> swamp_description


=== swamp_description ===
From the few huts, you spot several which seem to have been broken into, left in a state of disarray.
* The Oracle's Cabin: The workshop is stood above a particularly marshy area, connected to a patch of dry land by a rickety wooden bridge. Wind chimes made from bones and shells hang from the eaves, creating a haunting melody.
** The Alchemist's Workshop: A ramshacked building created by what seems like salvaged wood and metal, it has several chimneys protruding from it's roof emitting shining and strange coloured smoke. You can peer just inside the window and notice complex mechs and machine dominate the space, with shelves of exotic ingredients lining the walls.
*** The summonser's lair: You can see that the hut is made from a much darker wood than any of the other houses, with bones scattered throughout. Throughout the structure, there are charms and protections scratched into the building, practically being cramped in to every possible surface.
    Finally, in the middle of the swamp you see the Elder's hut standing. It is made from ancient, twisted trees and adorned with powerful wards and charms that you can sense, even from here. Inside, shelves have been overturned, books and scrolls scattered across the floor. The atmosphere is tense and foreboding, as if the very swamp itself holds its breath, waiting for what will happen next.
-> witch_dialogue

VAR WITCH_DIALOGUE = 9
=== witch_dialogue ===
As you begin to move closer towards the Elder's hut, you see them emerge and start towards you.
-> witch_dialogue_2
=== witch_dialogue_2 ===
+[{'Your hut appears to have seen better days, do you know what happened? I'm trying to find the young girl, Lena, who went missing somewhere around here a few days ago''|'I've seen her around here a few times before, always wandering where she shouldn't be. My hut was broken into the same night that she disappeared, I never thought that she'd have the audacity to enter my hut, let alone steal from it.'|'Do you happen to know what exactly she took yet?'|'She took a book, a very powerful grimoire. It contains spells that can easily overwhelm someone who doesn't understand their potency. I think she's close to doing something unwittingly that could put her in some serious danger.'|'What kind of spells are we talking about here? Summoning, curses, transformations?'|'I know she wanted to do anything she could  to try and prove herself to the village. There's a powerful spell to summon a protector of the village that she'd possibly use to drive out the variants. Although she isn't aware of what the spell requires to be given up in order to use it....'|'... she can't do this spell alone either, there must be someone that she's trying to help to be able to fully complete this spell.'|'Do you know any place that she might have gone with this person to try and complete the spell? Maybe a favourite spot around here, somewhere that's more remote for them to be able to complete the spell?'|'There's a grove, not far from here. She used to play there, by the old willow tree. It's a place where the veil between worlds is thin.'}]
{
    - WITCH_DIALOGUE <= 1:
        -> villager_introduction
    - else:
        ~WITCH_DIALOGUE = WITCH_DIALOGUE - 1
        -> witch_dialogue_2
}
    