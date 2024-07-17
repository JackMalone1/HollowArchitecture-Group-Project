Your first witness sits with their scrawny limbs gaggling all over the stool, staring at you with great, bulbous eyes. Their voice is soft, like pine needles dropping into a still pond. Meanwhile, your translation pad beeps loudly as it types out their rippling words into a language you can understand. You should introduce yourself. 
*[Kind introduction]
->Intro1
*[Assertive introduction]
->Intro2


== Intro1 ==
#speaker:You
Your parent asked me to help find out what happened to your friend, but I'm new in town and I don't know everyone yet. What's your name?
->Introtruth

== Introtruth ==
#speaker:Witness
I'm Ype. But Enge has been gone for weeks, I don't think you'll find them. 
->When

== Intro2 ==
#speaker:You
I'm here to help find out what happened to your friend, but I can't do that unless you answer my questions. Can you do that for me?
->IntroLie

== IntroLie ==
#speaker:Witness
I'm not sure...I don't think I know anything that can help you find Enge. 
->When

== When ==
*[You might know more than you think...]
-> When1
*[Enge might be in danger...]
-> When2

== When1 ==
#speaker:You
It sounds like you two were really good friends. Can you tell me about the last time you saw Enge? 
-> WhenTruth

== When2 ==
#speaker:You
It's really important that we find them as soon as possible so they don't get in any trouble. Can you tell me about the last time you saw Enge?
-> WhenLie

== WhenLie ==
#speaker:Witness
I already told everyone, we were playing by the lake and then we went home together...  
-> Who

== WhenTruth ==
#speaker:Witness
I left Enge in the lake. I don't know if they can swim. 
-> Who

== Who ==
*[I think you're lying to me.]
-> WhoTruth
*[Did you see anyone else?]
->WhoLie

== WhoLie ==
#speaker:You
Were any of your other friends there?
#speaker:Witness
Geir was hanging around with us, but we don't like him. He smells like burned corn and he's got this weird looking leg.
-> END

== WhoTruth ==
#speaker:You
Are you being truthful with me? Did you see anyone else? 
#speaker:Witness
Well...I did see Weir on the way home. He didn't see me because I hid in the reeds, but he was carrying something heavy on his shoulder.
-> END

== SummaryEnd ==
-> END


//Ending - variables to say how many clues you discovered and gives a summary of info gathered. 