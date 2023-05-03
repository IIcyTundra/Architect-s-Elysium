#!/bin/bash
INPUT="$HOME/Desktop/Marathon/Music"
OUTPUT="/Volumes/Scratch/Music"

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/00.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 32 -s -c 1 -D $OUTPUT/00.wav trim 0 2:40

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/01.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/01.wav trim 0 3:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/02.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/02.wav trim 0 2:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/03.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/03.wav trim 0 2:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/04.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/04.wav trim 0 3:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/05.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/05.wav trim 0 3:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/06.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/06.wav trim 0 2:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/07.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/07.wav trim 0 4:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/08.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/08.wav trim 0 4:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/09.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/09.wav trim 0 2:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/10.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/10.wav trim 0 3:40

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/11.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/11.wav trim 0 2:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/12.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/12.wav trim 0 2:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/13.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/13.wav trim 0 6:30

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/14.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/14.wav trim 0 3:00

killall TruBlueEnvironment; sleep 10
open -a "Classic Startup"; sleep 30
bash -c 'sleep 15; open -a muZak '"$INPUT"'/15.mov' &
/usr/local/bin/sox --buffer 524288 -d -b 16 -c 1 -D $OUTPUT/15.wav trim 0 3:30
