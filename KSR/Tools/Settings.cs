﻿using System;
using System.Collections.Generic;
using KSR.Tools.Features;
using KSR.Tools.Frequency;
using KSR.Tools.SimliarityFunctions;

namespace KSR.Tools
{
    public static class Settings
    {
        public static int testingPercentage = 40;
        public static int learningPercentage = 60;
        public static int kNNNeighbours = 15;
        public static string articleSerializerPath = "data.txt";
        public static string filteredArticleSerializerPath = "dataFiltered.txt";
        public static string DirectoryForResults = "results";
        public static Dictionary<IFeature, bool> featuresSettings = new Dictionary<IFeature, bool>()
        {
            {new BinaryArticleBodyFeature(), true },
            {new KeyWords20PercentArticleBodyFeature(), false },
            {new KeyWordsArticleBodyFeature(), false },
            {new KeyWordsFirstParagraphArticleBodyFeature(), false },
            {new Simliarity30PercentBody(){ SimilarityFunction = new BinaryFunction()}, true },
            {new Simliarity30PercentBody(){ SimilarityFunction = new JaccardFunction()}, false },
            {new Simliarity30PercentBody(){ SimilarityFunction = new LCSFunction()}, false },
            {new Simliarity30PercentBody(){ SimilarityFunction = new LevenshteinFunction()}, false },
            {new Simliarity30PercentBody(){ SimilarityFunction = new NGramFunction()}, true },
            {new Simliarity30PercentBody(){ SimilarityFunction = new NiewiadomskiFunction()}, false },
            {new SimilarityBodyFeature(){ SimilarityFunction = new NGramFunction()}, true },
        };
        public static int keyWords = 20;
        public static string stoplistfile = @"../../Data/stoplist.txt";
        public static IFrequency keyWordsExtractor = new TFFrequency();
        
        public static void printCurrentSettings()
        {
            Console.WriteLine("-------------------Printing settings------------------------------");
            
            Console.WriteLine("{");
            foreach (var fe in Settings.featuresSettings)
            {
                if(fe.Key.ToString() == "KSR.Tools.Features.SimilarityBodyFeature")
                      Console.WriteLine(string.Format("{0},",fe.Key.SimilarityFunction.ToString()));
                  else
                      Console.WriteLine(string.Format("{0},",fe.Key));
            }
            Console.WriteLine("}");
            Console.WriteLine(string.Format("Testing percentage: {0}, Learning percentage: {1}",Settings.testingPercentage,Settings.learningPercentage));
            Console.WriteLine(string.Format("kNN neighbors: {0}",Settings.kNNNeighbours));
            Console.WriteLine(string.Format("Chosen keyWordsExtractor: {0}",Settings.keyWordsExtractor.ToString()));
            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}