using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;

namespace RestFulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /// <summary>
        /// Function to return top used words in different URLs passed
        /// </summary>
        /// <param name="URLs"></param>
        /// <returns>Array of strings with most common used words</returns>
        public String[] TopUsedWords(string URLs)
        {
            ServiceReference2.ServiceClient Web2String = new ServiceReference2.ServiceClient();
            string handledURLs = "";
            string incorrectURLs = "";
            String[] urlArray = URLs.Split(';');
            Regex R = new Regex(@"https://([A-Za-z0-9\-]+).[A-Za-z0-9\-]+");
            int correctURLs = 0;
            foreach (string u in urlArray)
            {
                if (R.Match(u).Success == false)
                {
                    incorrectURLs = incorrectURLs + ";" + u;
                }
                else
                {
                    handledURLs = handledURLs + ";" + u;
                    correctURLs++;
                }

            }
            //To remove first semicolon added earlier
            handledURLs = handledURLs.Remove(0, 1);

            String[] tobePassedURLs = handledURLs.Split(';');
            String[] urlWiseContent = new String[tobePassedURLs.Count()];
            SortedDictionary<string, int>[] dictWeb = new SortedDictionary<string, int>[tobePassedURLs.Count()];
            for (int i = 0; i < tobePassedURLs.Count(); i++)
            {
                dictWeb[i] = new SortedDictionary<string, int>();
            }
            int siteNum = 0;
            foreach (string url in tobePassedURLs)
            {
                urlWiseContent[siteNum++] = Web2String.GetWebContent(url);
            }
            int dictNum = 0;
            foreach (string webString in urlWiseContent)
            {
                dictWeb[dictNum++] = WordDictionary(webString);
            }
            double weightage = 1 / Convert.ToDouble(tobePassedURLs.Count());
            double val = 0;
            int flag = 0;
            SortedDictionary<string, double> TopWords = new SortedDictionary<string, double>();
            foreach (var k in dictWeb[0])
            {
                val = 0;
                flag = 0;
                for (int inner = 1; inner < tobePassedURLs.Count(); inner++)
                {
                    val = weightage * Convert.ToDouble(k.Value);
                    if (dictWeb[inner].ContainsKey(k.Key))
                    {
                        flag = 1;
                        val = val + weightage * dictWeb[inner][k.Key];
                    }
                    else
                    {
                        flag = 0;
                        continue;
                    }
                }
                if (TopWords.ContainsKey(k.Key) && flag == 1)
                    TopWords[k.Key] = TopWords[k.Key] + val;
                else if (!(TopWords.ContainsKey(k.Key)) && flag == 1)
                    TopWords.Add(k.Key, val);
                else
                    continue;
            }
            var sortedWordList = TopWords.OrderByDescending(kvp => kvp.Value);
            int countotopWords = sortedWordList.Count();
            String[] sTopWords = new String[countotopWords];
            for (int i = 0; i < countotopWords; i++)
            {
                sTopWords[i] = sortedWordList.ElementAt(i).Key.ToString();
            }

            return sTopWords;
        }
        public SortedDictionary<string, int> WordDictionary(string url)
        {
        ServiceReference1.Service1Client stringPurify = new ServiceReference1.Service1Client();
        // Sorted Dictionary to Hold All Words and their Counts as Key Value Pair resp
        SortedDictionary<String, int> S = new SortedDictionary<String, int>();

            //List of words that will be removed from dictionary as these are used in sentences to connect
            String[] uselessWords = {"an","the","for","in","on","are","as","be","can","did","do","have","had"
            ,"has","of","say","she","he","and","to","by","is","or","was","with","that","at","it","been"};
            string purifiedString = stringPurify.StringPurifier(url, "Top10Words");

            //Add each word to Dictionary and keep updating count
            foreach (string s in purifiedString.Split())
            {
                // Length grater than 1 to avoid single letters like a and mistakenly added single characters
                if (s.Trim().Length > 1)
                {
                    if (!S.ContainsKey(s))
                    {
                        S.Add(s, 1);
                    }
                    else
                    {
                        S[s]++;
                    }
                }
            }

            //After adding remove all the words that are used as connectors in sentences 
            foreach (string uW in uselessWords)
                if (S.ContainsKey(uW))
                    S.Remove(uW);

            return S;
        }
    }
}
