﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitRecognizer
{
    public class Evaluator
    {
        public static double Correct(
            IEnumerable<Observation> validationSet,
            IClassifier classifier)
        {
            return validationSet.Select(obs => Score(obs, classifier))
                                .Average();
        }

        public static double Score(
            Observation obs,
            IClassifier classifier)
        {
            if (classifier.Predict(obs.Pixels) == obs.Label)
            {
                return 1.0;
            }
            
            return 0.0;
        }
    }
}
