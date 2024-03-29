﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AISC_Team10_Modules.EmotionDetection
{
    class FPSTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long data);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long data);

        private EmotionDetectionForm form;
        private long freq, last;
        private int fps;

        public FPSTimer(EmotionDetectionForm mf)
        {
            form = mf;
            QueryPerformanceFrequency(out freq);
            fps = 0;
            QueryPerformanceCounter(out last);
        }

        public void Tick(string text)
        {
            long now;
            QueryPerformanceCounter(out now);
            fps++;
            if (now - last > freq) // update every second
            {
                last = now;
                form.UpdateStatus(text + " FPS=" + fps);
                fps = 0;
            }
        }
    }
}
