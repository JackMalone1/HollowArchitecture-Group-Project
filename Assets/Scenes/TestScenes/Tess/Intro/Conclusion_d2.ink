=== final_conclusion ===
The Elder begins to chant a warbling incantation, attempting to break the spell. 
+[Continue] -> final_conclusion1

=== final_conclusion1 ===
The Elder's chant reaches a crescendo and a brilliant light burst from her staff, enveloping the altar and the stranger. The ritual shatters.
+[Continue] -> final_conclusion2

=== final_conclusion2 ===
Lena drops the grimoire, frozen as she realises in horror where she is. She appears to finally be free from whatever spell she was under.
+[Continue] 

-> final_conclusion_allclues


=== final_conclusion_allclues ===
Suddenly, the ground beneath you turns over itself, yielding to your boots. Everyone finds themselves sinking rapidly, though Lena and the villager are smaller and lighter, and manage to start sprinting back through the trees.
The Elder and the Priest are being pulled under by the heaviness of their robes; You only have time to help one of them. 
Quickly, review your evidence and make a decision about who to reach for!
{ - suspect_conclusion3:
You found 7/7 clues
- else:
You found 6/7 clues
}
+[WITNESS: Variant] -> clue_variant
+[WITNESS: Elder] -> clue_elder
+[WITNESS: Villager] -> clue_villager 
+[ITEM: Spell book] -> clue_book
+[PLACE: Grove/Altar] -> clue_altar
+[PLACE: Elders' Swamp] -> clue_swamp
{ - suspect_conclusion3:
+[SUSPECT: Priest] -> clue_priest
+[Continue] -> make_decision
- else:
+[Continue] -> make_decision
-> END
}

=== make_decision ===
+[Save Elder] 
You barely know the Priest, and there's no denying the fact that he was the one who brought Lena here. You grab the Elder's hand.
-> ending
+[Save Priest] 
Whether he knew what he was doing or not, the Priest didn't deserve to die here. The Elder could probably save herself with magic but he seemed completely helpless. You grab the Priest's hand.
-> ending

=== ending ===
You sprint away as best you can with the mulch sucking on your boots and don't look back. 
You're not sure how much you've helped the town here, but at least Lena is safe and you can return to her mother for the information about your missing partner.
-> END

=== clue_variant ===
The townspeople, including Lena, really doesn't like Variants. Although the one you met seemed pretty harmless. They told you that Lena had been friends with the "witches", also known as "Elders".
+[Back] -> final_conclusion_allclues

=== clue_elder ===
The Elder told you that Lena stole the spell book, but wouldn't have known enough about it to use it alone.
+[Back] -> final_conclusion_allclues

=== clue_villager ===
The villager you met in the swamp saw the priest whispering to Lena as they headed towards the Altar, but couldn't hear what he was saying. 
+[Back] -> final_conclusion_allclues

=== clue_book ===
The spell book belongs to the Elder. Lena was holding it when you found her at the Altar.
+[Back] -> final_conclusion_allclues

=== clue_altar ===
The Altar is a place of strong magical power. It might even have sentience of its own. The Elder seems to have some knowledge about it.
+[Back] -> final_conclusion_allclues

=== clue_swamp ===
The swamp contains the Altar as well as the Elders' village.
+[Back] -> final_conclusion_allclues

=== clue_priest ===
The priest told you he didn't know what the spell did, and that his intention was just to help Lena. You believe he is telling the truth. 
+[Back] -> final_conclusion_allclues
