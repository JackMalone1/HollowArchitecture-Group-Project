=== villager_introduction ===
The swamp seemed even more foreboding as you and the Elder make your way throught he mist, guided by a small light spell that she conjured. The trees loom overhead. Suddenly, you spot a the faint outline of a villager ahead, their lantern softly glowing. You approach the villager to see if you can get any information out of them.
-> villager_dialogue

=== villager_dialogue ===
VAR VILLAGER_INTRODUCTION = 4
+[{'Have you seen a young girl come by here in the last few days?'|'Earlier, I saw her pass by with a stranger. A man dressed in dark robes, whispering to her. I didn't catch much, only that they're planning on heading to the old altar in the grove.'|(Elder)'That altar hasn't been used in centuries, it's a place of ancient power. Did you notice anything else about this man?'|'I couldn't properly see him, he appeared out of nowhere, but there was something off about him. His eyes glowed in the dark. I was only able to track him for a time before the mist thickened too much.'}]
{
- VILLAGER_INTRODUCTION <= 1:
        -> villager_ending
- else:
        ~VILLAGER_INTRODUCTION = VILLAGER_INTRODUCTION - 1
        -> villager_dialogue
}

=== villager_ending ===
The villager leads you through a narrow, winding path deeper into the swamp. The air grew cooler and an unnatural silence fell over the surroundings. After several tense minutes, you arrive at the grove. Through the trees, you can make out the old altar and in the flickering light of several candles, stood Lena and the mysterious man.
-> conclusion