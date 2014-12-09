pseudo-code algo 5:
List differences = getDifferences with localhistogram
lower treshold = mean of differences * 1.5
higher treshold = mean of differences + 2.0 * standard deviation of differences

for (every frame in the movie){ //iterate over the difference list
  get the difference with the next frame by looking in the difference list
  if (difference >= high  treshold){
    cut detected
  }
  else if (difference >= low treshold && difference < high treshold){
    //start possible gradual transition
    
    while (difference >= lower treshold && difference < high treshold){
	iterate over all differences until difference < lower treshold or a hard cut has been detected
        save the sum of all the differences, starting at the possible start
    }
    if (sum >= high treshold) {
	gradual transition was successful, save the correct framenumber to denote a shot
    }
    else if (difference >= high treshold){
        cut was detected, reject the gradual  transition and save the correct framenumber to denote a shot
    }
  }
}

how algo 5 works:

-iterate over all the frames, calculate their localhistogram and save the differences between all consecutive frames
-set up a low and high treshold, determined by the differences
-iterate over all differences, if a difference is higher than the high treshold -> cut
			       if a difference is lower than the high treshold and higher than low treshold -> possible start of gradual transition
-if its possible to have a gradual transition, iterate over all the consecutive frames until the difference is lower than the low treshold or diff >= high treshold
-save and adjust the sum of all the differences whenever its possible to have a gradual transition
-when sum >= high treshold, gradual transition found
-whenever a difference >= high treshold, reject the gradual transition possibility and save the hard cut to denote the end/start of a cut

Best parameters:

generalized:

csi: 16 bins 9 blocks
star wars: 16 bins 9 blocks
youth: 64 bins 9 blocks

low treshold: 1.5 * mean, found by reading several papers and trial and error, by just using the mean, too many possible starts were found
by using the median the results were not better
1.5 * mean was finally found by some interpolation 

high treshold: mean + 2.0* standard deviation: this formula was found in a paper as mean + alpha * standard deviation
the paper used the value 5.0 for alpha, but for these movies that value was too high, not enough shots were detected
by trying some lower values, finally the value of around 2.0 was the best fit

9 blocks: tested out with several values (9, 25, 16, 36, 81, ...), and it seemed that 9 (as in the project explanation) was the best fit
16 bins: should lie within 1 and 256 (the colour values), tested out with 8, 16 and 32, better results going from 8 to 16, worse results going from 16 to 32, so 16 was picked
64 bins: 16 bins was not restrictive enough for the youth movie, the bins had more impact than the blocks so we made it more restrictive by adjusting the bins parameter, 64 was the best fit


bins: amount of bins for the local histogram, every colour value has a value of 0-255 (with RGB), amount of different colour values stored in one bin = 256/#bins
range: 1-256
blocks: the amount of blocks that are used for the local histogram, 9 blocks means that the frame is split into 9 equal blocks (3 horizontal, 3 vertical)
range: 1-81(?) (can be higher, but not really useful then), must be a squared number




Pixel Difference ShotDetection:

  Threshold 1: Is a threshold, to determine if two pixels are changed or not. If the sum of the differences of the 3 colors, is greater than threshold 1, those pixels is counted as 'different'. So: given two pixels x and y, x is different than y if: |x_red - y_red| + |x_green - y_green| + |x_blue - y_blue| > threshold1

  Threshold 2: Percentage (0-100) of how many pixels should have changed(with threshold1) between two frames to count those frames as the end and start of a shot.

 Motion Estimation ShotDetection:

  Threshold: For all blocks, the best matching block is determined. The sum of the pixels of the block itself and the pixels of the matching block are substracted. If we sum up those differences of all the blocks, and that difference is greater than the threshold, we have detected a shot.

  Block size: size of each block, should be a common divisor of the height and width of the frames.

  Window size: the 'window' is the area in which you search for matching blocks. The greater this window size is, the more abrupt changes you are able to detect. The window size is defined as half of the actual size of the window, as it is how far you look in all directions.

 Global Histogram ShotDetection:

  Threshold: If the sum of the differences between the bins in the histograms of two frames, is greater than the threshold, a shot is detected.

  Bins: number of parts in which you divide the RGB-values. Should be between 0 and 256.

 Local Histogram ShotDetection:

  Threshold: For each block, the sum of the differences between the bins in the histograms of two frames, is determined. If the sum of those differences of all blocks is greater than the threshold, a shot is detected.

  Bins: number of parts in which you divide the RGB-values. Should be between 0 and 256.

  Blocks: Number of blocks in the frame; should be a square.

  
Parameters that give acceptable results for the return_jedi_trailer_cuts-only.avi file:

Pixel Difference: 
  Threshold1: 25-30
  Threshold2: 70-80
Motion Estimation: 
  Threshold: 2000000
  Block size: 22
  Window size: 50
Global Histogram:
  Threshold: 100000
  Number of bins: 64
Local Histogram:
  Threshold: 150000
  Number of bins: 64
  Blocks: 16

