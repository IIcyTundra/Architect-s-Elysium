#!/usr/bin/perl
use List::Util;

binmode STDIN;
# my $peak = 0;
# my $peak_offset = -1;
# my $diff = 0;
# my $diff_offset = -1;
# my $prev = 0;
# my $prev2 = 0;
# my $prev_diff = 0;
# my $prev_diff2 = 0;
my $offset = 0;
# my $pops = 0;
# 

my $pop_threshold = 2048;

my @prev_v = (0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
my @prev_d = (0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

my $sample;
# skip wav header
read(STDIN, $sample, 44);

while (read(STDIN, $sample, 2))
{
  my $val = unpack('s<', $sample);
  my $diff = abs($val - $prev_v[-1]);
  push(@prev_v, $val);
  push(@prev_d, $diff);
  
  if (abs($val) > 22000)
  {
    my $secs = sprintf("%.1f", $offset / 88200);
    print "High volume $val at $offset ($secs seconds)\n";
  }
  
#   if ($diff > 2048)
#   {
#     my $secs = sprintf("%.1f", $offset / 88200);
#     print "Big difference $diff at $offset ($secs seconds)\n";
#   }
    
  # look for pop a few samples back
  my $max_surround = List::Util::max(@prev_d[0..4], @prev_d[6..10]);
  my $candidate = $prev_d[5];
  
  if ($candidate > $pop_threshold &&
      $candidate > 1.1*$max_surround)
  {
    my $off = $offset - 10;
    my $secs = sprintf("%.1f", $off / 88200);
    print "Pop detected ($candidate, $max_surround) at $off ($secs seconds)\n";
  }
  
  shift(@prev_v);
  shift(@prev_d);
  $offset += 2;
}

print <<END;
Examined $offset samples
END
