﻿using Akka.Util;

namespace SpiceJetElementsInteractionTests1
{
    public class RandomUtilsBase
    {

        public static String randomSubjectFromArr()
        {
            String[] arr = { "", "", "", "" };
            int randIdx = ThreadLocalRandom.Current.Next(arr.Length);
            String randomElem = arr[randIdx];
            return randomElem;
        }
    }
}