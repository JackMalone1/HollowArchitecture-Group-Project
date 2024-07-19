=== introduction ===
You finally finish the 7-day trek through the woods to find yourself in front of the forgotten, dilapidated village. This
village has been lost to time by the rest of the world; the village doesn't seem interested in interacting with the rest
of the world. There seems to be nothing left of the simple life and joy that you were told existed here. The abominations have been too
regular as of late it seems.
-> describe_villagers

VAR DESCRIBE_VILLAGERS = 3
=== describe_villagers ===
* [{The few villagers that are left appear to be living in a life of squalar.|Everyone ignores your gaze as you attempt to find the person that had asked you here in the first place.|As you get to the town hall, you see what you can only presume is some cross between a human and an alien of some kind. Not quite human, yet not too different either.}]
    {
    - DESCRIBE_VILLAGERS <= 0:
        -> info_from_mother
    - else:
        ~DESCRIBE_VILLAGERS = DESCRIBE_VILLAGERS - 1
        -> describe_villagers
    }
    
VAR MISSION_INFO_DUMP = 5
=== info_from_mother ===
As you're about to approach them, a haggard woman rushes over to you, grabs your arm just a bit too tight and rushes you into the 
crumbling and imposing building, which at closer inspection can only be the local town hall.
*[{You don't want to stay out in the town for too long, we can't have the person who's supposed to be finding my daughter getting snatched by a variant can we?|(This wasn't the best introduction that you could have had, but I guess you had to meet that kids mother eventually. They did warn us that they were a piece of work to deal with.)|You don't want to stay around those variants for long, for all we know, that one that you were gawking at earlier was in on taking my Lena away from me.|You better see what they know about what happened, those kinds are always never too far away at night, it's far too easy for them to have stolen her from me while I wasn't looking. If it was up to us, they would have been driven out of here long ago.|(You get the sense that there is a lot of hostility in this town. You don't know if you can trust if this variant had anything to do with, but they're  your only lead for now, so it's better than nothing.)}]
    {
    - MISSION_INFO_DUMP <= 0:
        -> mutant_introduction
    - else:
        ~MISSION_INFO_DUMP = MISSION_INFO_DUMP - 1
        -> info_from_mother
    }
    