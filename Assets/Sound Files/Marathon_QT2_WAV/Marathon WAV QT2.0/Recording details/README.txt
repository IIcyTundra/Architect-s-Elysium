These tracks were recorded on an original Mac mini, by playing the QuickTime movies in the Classic environment and recording the audio with Soundflower and Sox.

Software used:

- Mac OS X 10.4 for the host environment
- Mac OS 9.2 for the Classic environment
- QuickTime 2.0 in the Classic environment

- Marathon Music Exploder for extracting movies from the Marathon Music file
http://marathon.bungie.org/story/_files/Marathon_Music_Exploder.sit

- muZak 1.4 for playing the movies in Classic
http://www.umich.edu/~archive/mac/graphics/quicktime/muzak1.4.sit.hqx

- Soundflower for capturing the system audio for recording
http://cycling74.com/products/soundflower/

- Sox for recording the audio to disk
http://sox.sourceforge.net/

muZak was set to "Normal" volume level, and I recorded 16-bit mono audio without dithering. See the "record_music.sh" script to see how this process was automated.

To check the quality of the recordings, I used the included "pop_check.pl" script. This script was good enough to catch the flaws I heard in a play-through, but there's no guarantee these recordings are perfect.

To remove extraneous silence, I used the "trim_wav.pl" script. I found that when QuickTime is in use, the audio isn't perfectly silent; coupled with the particular way muZak uses QuickTime, this enabled me to crop the tracks very close to the original lengths.

The "track_timing.txt" file contains the original movie lengths as reported by QuickTime Player 7. This was helpful to me to set up the recording script, and to check the trimmed tracks. I'm including it here, in case it anyone else finds it useful.

Thanks go to Hamish Sinclair for encouraging this mad experiment, Craig Hardgrove for rekindling interest in the Marathon music, and especially Gregory Smith for advice, ideas, and friendly competition.

- Jeremiah Morris, 17 July 2011


All text read - achievement unlocked!
Bonus content: Matthew Smith's "The MIDI of Roland"

Count Roland processes upon the Macintosh; 
I cannot tell you how he edited it and encoded; 
Yet the drums play not nor cymbals, though it has bass; 
Upward to heaven his eyes roll. 
When the count sees it never will be converted, 
Then to himself right softly he makes moan; 
'Ah, Marathon MIDI file, fair, hallowed, and devote, 
What store of sounds lies in thy tracks of gold!'
