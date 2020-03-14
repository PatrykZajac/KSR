﻿using System;
using System.Collections.Generic;
using System.Linq;
using KSR.Model;
using KSR.Tools.Features;
using NumSharp;

namespace KSR.Tools.Helpers
{
    public class FeatureExtractorHelper
    {
        public static void ExtractFeature(List<IFeature> features, ref Article article, List<string> keyWords)
        {
            article.FeaturesD = new double[features.Count];
            int count = 0;
            var max_value = 0d;
            foreach (var feature in features)
            {
                article.FeaturesD[count] = feature.Calc(article, keyWords);
                max_value = Math.Max(max_value, article.FeaturesD[count]);
                count++;
            }
            //var max = np.max(article.Features);
            article.FeaturesD = article.FeaturesD.Select(item => item / max_value).ToArray();
        }
    }
}
