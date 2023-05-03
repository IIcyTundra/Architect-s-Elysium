#!/usr/bin/perl

binmode STDIN;
my ($chunk, $data);
my $null = chr(0) x 2;

# skip header
read STDIN, $chunk, 44 or die;
while (read STDIN, $chunk, 4096) { $data .= $chunk; };

my $start = 0;
while (substr($data, $start, 2) eq $null) { $start += 2; };

my $end = length($data);
while (substr($data, $end - 2, 2) eq $null) { $end -= 2; };

if ($end <= $start)
{
  print STDERR "No audio data found in recording\n";
  exit 1;
}


binmode STDOUT;

my $channels = 1;
my $rate = 44100;
my $bytes_sample = 2;

my $data_size = $end - $start;

# Thanks to: https://ccrma.stanford.edu/courses/422/projects/WaveFormat/

print "RIFF";                  # ChunkID
print pack('V', 36 + $data_size);  # ChunkSize
print "WAVE";                   # Format

print "fmt ";                   # Subchunk1ID
print pack('V', 16);            # Subchunk1Size
print pack('v', 1);             # AudioFormat
print pack('v', $channels);     # NumChannels
print pack('V', $rate);         # SampleRate
print pack('V', $rate * $channels * $bytes_sample);   # ByteRate
print pack('v', $channels * $bytes_sample);           # BlockAlign
print pack('v', $bytes_sample * 8);                   # BitsPerSample

print "data";                   # Subchunk2ID
print pack('V', $data_size);    # Subchunk2Size

print substr($data, $start, $data_size);
