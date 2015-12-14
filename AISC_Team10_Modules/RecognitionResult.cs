using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_Modules
{
    public class RecognitionResult
    {
        public DateTime _time { get; set; }

        public float _heartBeat { get; set; }

        public int _usingTime { get; set; }

        public int[] _emotions = new int[7];

        public int[] _sentiments = new int[3];

        public RecognitionResult()
        {
            _time = DateTime.Now;
            _heartBeat = 0;
            _usingTime = 0;
            Array.Clear(_emotions, 0, _emotions.Length - 1);
            Array.Clear(_sentiments, 0, _sentiments.Length - 1);
        }

        public void updateData(float heartbeat, string emotion, string sentiment)
        {

            if (heartbeat > 0 && isValidEmotion(emotion) && isValidSentiment(sentiment))
            {
                _usingTime++;

                if (_heartBeat == 0) { _heartBeat = heartbeat; }
                else
                {
                    _heartBeat = ((_heartBeat * (_usingTime - 1)) + heartbeat) / _usingTime;
                }

                updateEmotionRecognition(emotion);
                updateSentimentRecognition(sentiment);
            }
            
            
        }

        private bool isValidEmotion(string emotion)
        {
            switch (emotion)
            {
                case "ANGER":
                case "CONTEMPT":
                case "DISGUST":
                case "FEAR":
                case "JOY":
                case "SADNESS":
                case "SURPRISE":
                    return true;
                default:
                    return false;
            }
        }

        private bool isValidSentiment(string sentiment)
        {
            switch (sentiment)
            {
                case "NEGATIVE":
                case "POSITIVE":
                case "NEUTRAL":
                    return true;
                default:
                    return false;
            }
        }

        private void updateEmotionRecognition(string emotion)
        {
            switch (emotion)
            {
                case "ANGER":
                    _emotions[(int)EMOTIONS.ANGER]++;
                    break;
                case "CONTEMPT":
                    _emotions[(int)EMOTIONS.CONTEMPT]++;
                    break;
                case "DISGUST":
                    _emotions[(int)EMOTIONS.DISGUST]++;
                    break;
                case "FEAR":
                    _emotions[(int)EMOTIONS.FEAR]++;
                    break;
                case "JOY":
                    _emotions[(int)EMOTIONS.JOY]++;
                    break;
                case "SADNESS":
                    _emotions[(int)EMOTIONS.SADNESS]++;
                    break;
                case "SURPRISE":
                    _emotions[(int)EMOTIONS.SURPRISE]++;
                    break;
                default:
                    return;
            }
        }

        private void updateSentimentRecognition(string sentiment)
        {
            switch(sentiment)
            {
                case "NEGATIVE":
                    _sentiments[(int)SENTIMENTS.NEGATIVE]++;
                    break;
                case "POSITIVE":
                    _sentiments[(int)SENTIMENTS.POSITIVE]++;
                    break;
                case "NEUTRAL":
                    _sentiments[(int)SENTIMENTS.NEUTRAL]++;
                    break;
                default:
                    return;
            }
        }

        public float computeNegativeTimeSpan()
        {
            float res = _sentiments[(int)SENTIMENTS.NEGATIVE];
            return res;
        }

        public float computeNormalTimeSpan()
        {
            float res = _sentiments[(int)SENTIMENTS.NEUTRAL];
            return res;
        }

        public float computePositiveTimeSpan()
        {
            float res = _sentiments[(int)SENTIMENTS.POSITIVE];
            return res;
        }
    }
}
