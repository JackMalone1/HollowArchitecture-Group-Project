Your first witness sits with their scrawny limbs gaggling all over the stool. Their voice is soft, like pine needles dropping into a still pond. Meanwhile, your translation pad beeps loudly as it types out their rippling words into a language you can understand. You should introduce yourself. 
*[Kind introduction]
->Intro1
*[Assertive introduction]
->Intro2


== Intro1 ==
Your parent asked me to help find out what happened to your friend, but I'm new in town and I don't know everyone yet. What's your name? #speaker:Player
->Introtruth

== Introtruth ==
I'm Ype. But Enge has been gone for weeks, I don't think you'll find them. 
->When

== Intro2 ==
Player: I'm here to help find out what happened to your friend, but I can't do that unless you answer my questions. Can you do that for me?
->IntroLie

== IntroLie ==
Witness: I'm not sure...I don't think I know anything that can help you find Enge. 
->When

== When ==
*[You might know more than you think...]
-> When1
*[Enge might be in danger...]
-> When2

== When1 ==
Player: It sounds like you two were really good friends. Can you tell me about the last time you saw Enge? 
-> WhenTruth

== When2 ==
Player: It's really important that we find them as soon as possible so they don't get in any trouble. Can you tell me about the last time you saw Enge?
-> WhenLie

== WhenLie ==
Witness: I already told everyone, we were playing by the lake and then we both went home.  
-> Who

== WhenTruth ==
Witness: We were playing by the lake. I told everyone that we went home together, but we had an argument and Enge went in the lake and I just ran back...
-> Who

== Who ==
*[Did Enge have any enemies?]
-> WhoLie
*[Did you see anyone else?]
->WhoTruth

== WhoLie ==
Witness: Geir was always hanging around with us, but we don't like him. He smells like burned corn and I don't like looking at his weird leg.
-> END

== WhoTruth ==
Witness: Well...I did see Weir on the way home. He didn't see me because I hid in the reeds, but he was carrying something heavy on his shoulder.
-> END

//Ending - variables to say how many clues you discovered and gives a summary of info gathered. 