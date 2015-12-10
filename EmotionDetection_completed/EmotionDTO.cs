using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC.EmotionDetection
{
    static class EmotionDTO
    {
        static public DateTime prev_time;
        static public string prev_sentiment;

        static public DateTime cur_time;
        static public string cur_sentiment;
    }
}
