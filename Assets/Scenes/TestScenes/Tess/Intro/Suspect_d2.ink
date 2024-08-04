=== suspect_introduction ===
The villager leads you through a narrow, winding path deeper into the swamp. The air grows cooler and an unnatural silence falls over the surroundings. After several tense minutes, you arrive at the grove. Through the trees, you can make out the old Altar and in the flickering light of several candles, Lena and the mysterious man stand.
+[INTERROGATION]
-> suspect_conclusion

=== suspect_conclusion ===
Did you win the card battle?
+[Yes] 
The robed man falls to his knees as if you have physically exhausted him, though the air still crackles with magical energy - the ritual is not yet broken.

You're confident that he will tell the TRUTH.
-> suspect_conclusion1
+[No]
Though the air still crackles with magical energy, you are exhausted and cannot continue. You can't get a read on this man and your head is swimming with uncertainty, while the ritual is not yet broken. 

The Priest could be LYING.
-> suspect_conclusionA

=== suspect_conclusion1 ===
#speaker:PRIEST 
"Please, don't harm me. The girl wanted to come here."
+[Ask Lena] -> suspect_conclusion2

=== suspect_conclusion2 ===
#speaker:YOU 
To Lena - "Is that true?"
#speaker:LENA 
"..."
#speaker:PRIEST 
"She won't speak to you. The enchantment prevents it and I've tried breaking it already."
+[Continue] -> suspect_conclusion3

=== suspect_conclusion3 ===
#speaker:PRIEST 
"She asked me to help with the spell, but I swear I didn't know what it did."
#speaker:PRIEST 
"I'm a fool, I know."
+[Continue] -> final_conclusion


=== suspect_conclusionA ===
#speaker:PRIEST 
"Don't harm me, please. I was just trying to help the girl."
+[Ask Lena] -> suspect_conclusionB 

=== suspect_conclusionB ===
#speaker:YOU 
To Lena - "Is that true?"
#speaker:LENA 
"..."
#speaker:PRIEST 
"She won't speak to you. The enchantment prevents it and I've tried breaking it already."
+[Continue] -> suspect_conclusionC 

=== suspect_conclusionC ===
#speaker:PRIEST 
"I can't put an end to this, and neither can the girl."
#speaker:PRIEST 
"If you're looking for someone to blame, you might want to look at the wicked creature standing next to you."

The Priest points to the Elder.
-> final_conclusion