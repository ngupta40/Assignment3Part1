using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Assignment3Part1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        String[] topPlaces = new String[100];
        /// <summary>
        /// Function to purify input string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="parentFunc"></param>
        /// <returns> String that is purified removed with all html and xml tags</returns>
        public string StringPurifier(string str, string parentFunc)
        {
            string strConverted = str;
            String[] Words = new String[10];
            try
            {
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(str);

                var root = document.DocumentNode;
                var vStringBuilder = new StringBuilder();
                foreach (var node in root.DescendantsAndSelf())
                {
                    if (node.Attributes.Contains("style")) { node.Attributes.Remove("style"); }
                    if (node.Attributes.Contains("class")) { node.Attributes.Remove("class"); }

                    if (!node.HasChildNodes)
                    {
                        if (!(node.ParentNode.Name == "script") && !(node.ParentNode.Name == "#html") && !(node.Name == "#comment") && !(node.ParentNode.Name == "title"))
                        {
                            if (!string.IsNullOrEmpty(node.InnerText))
                                vStringBuilder.AppendLine(node.InnerText.Trim());
                        }

                    }
                }
                if (parentFunc == "Top10Words")
                {
                    Regex R = new Regex("[^a-zA-Z]");
                    strConverted = R.Replace(vStringBuilder.ToString(), " ").ToLower();
                }

                else
                    strConverted = vStringBuilder.ToString();
            }

            catch (Exception E)
            {
                Console.WriteLine("Exception Occured: {0} ", E.Message);
            }

            return strConverted;
        }
        /// <summary>
        /// Function to find top 10 used words 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>An array of strings that are most used words in the given url content</returns>
        public String[] Top10Words(string url)
        {
            Web2StringSvc.ServiceClient web2String = new Web2StringSvc.ServiceClient();
            String output = web2String.GetWebContent(url);
            // Sorted Dictionary to Hold All Words and their Counts as Key Value Pair resp
            SortedDictionary<String, int> S = new SortedDictionary<String, int>();
            //List of words that will be removed from dictionary as these are used in sentences to connect
            String[] uselessWords = {"an","the","for","in","on","are","as","be","can","did","do","have","had"
            ,"has","of","say","she","he","and","to","by","is","or","was","with","that","at","it","been"};
            string purifiedString = StringPurifier(output, "Top10Words");

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
            // SOrting descendingly on values as dictionaries dont allow direct sort on values
            var sortedEle = S.OrderByDescending(kvp => kvp.Value);

            // Variable to maintain total words just incase the total distinct words itself dont exceed more than 10 we keep max as 10 
            //but it can be less depending on the size of wordlist in dictionary

            int countotop10Words = 0;

            if (sortedEle.Count() > 10)
                countotop10Words = 10;
            else
                countotop10Words = sortedEle.Count();

            //Building a string to keep first 10 ten words from sorted dictionary elements as they have the maximum count 
            String[] sTop10Words = new String[countotop10Words];
            for (int i = 0; i < countotop10Words; i++)
            {
                sTop10Words[i] = sortedEle.ElementAt(i).Key.ToString();
            }

            return sTop10Words;

        }
        /// <summary>
        /// Function to filter the strings removing stop words
        /// </summary>
        /// <param name="str"></param>
        /// <returns>filtered string</returns>
        public string WordFilter(string str)
        {
            string filteredString = "";
            String[] stopWords = {"a", "an", "in", "on", "the", "is", "are", "am"};
                //{"a","an","the","for","in","on","are","as","be","can","did","do","have","had"
            //,"has","of","say","she","he","and","to","by","is","or","was","with","that","at","it","been"};

            filteredString = StringPurifier(str, "WordFilter");
            filteredString = string.Join(" ", filteredString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Except(stopWords));
            return filteredString;
        }
        /// <summary>
        /// Function takes file path and returns transaction summary
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Transaction summary</returns>
        public string TransactionSummary(string filePath)
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);

                string line, transactionSummary = "";
                SortedDictionary<string, double> transactionDetail = new SortedDictionary<string, double>();

                string transactiontype = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (line != "" && line.Split().Length > 2)
                    {
                        String[] tr = line.Split();
                        if (tr[2] == "DEBIT" || tr[2] == "DB" || tr[2] == "Db" || tr[2] == "db" || tr[2] == "-")
                        {
                            transactiontype = "DEBIT";
                            if (transactionDetail.ContainsKey(transactiontype))
                            {
                                transactionDetail[transactiontype] = transactionDetail[transactiontype] + Convert.ToDouble(tr[3]);
                            }
                            else
                                transactionDetail.Add(transactiontype, Convert.ToDouble(tr[3]));
                        }
                        else if (tr[2] == "CREDIT" || tr[2] == "Cr" || tr[2] == "CR" || tr[2] == "cr" || tr[2] == "+")
                        {
                            transactiontype = "CREDIT";
                            if (transactionDetail.ContainsKey(transactiontype))
                            {
                                transactionDetail[transactiontype] = transactionDetail[transactiontype] + Convert.ToDouble(tr[3]);
                            }
                            else
                                transactionDetail.Add(transactiontype, Convert.ToDouble(tr[3]));
                        }
                    }
                }
                file.Close();
                double total = 0.0;
                foreach (var kvp in transactionDetail)
                {
                    total = total + kvp.Value;
                    transactionSummary = transactionSummary + " " + kvp.Key + ":" + kvp.Value;
                }
                if (transactionDetail.Count != 0)
                    transactionSummary = transactionSummary + " TOTAL TRANSACTIONS: " + total;
                else
                    transactionSummary = "File is not in correct format, file format should be Column1 Column2 Column3=>TransactionType(Debit/Credit) Column4=>Amount";

                return transactionSummary;
            }


            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Classes for handling GOOGLE PLACES DATA
        /// Can be used in future to extend
        /// </summary>
        public class GeoLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Geometry
        {
            public GeoLocation location { get; set; }
        }
        public class OpeningHours
        {
            public bool open_now { get; set; }
            public List<object> weekday_text { get; set; }
        }
        public class Photo
        {
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }
        public class Result
        {
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public OpeningHours opening_hours { get; set; }
            public List<Photo> photos { get; set; }
            public string place_id { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public string scope { get; set; }
            public List<string> types { get; set; }
            public string vicinity { get; set; }
        }
        public class PlacesApiQueryResponse
        {
            public List<object> html_attributions { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
        /// <summary>
        /// Function takes in zipcode and returns top rated nearby places in descending order  
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>Array of strings of nearby places</returns>
        public String[] TopNearByPlaceFinder(string zipCode)
        {
            ZipCodeFinder.ZipCodeLookupSoapClient zipFinder = new ZipCodeFinder.ZipCodeLookupSoapClient();
            Regex R = new Regex(@"^\d+$");
            if (zipCode != "" && R.Match(zipCode).Success)
            {
                ZipCodeFinder.ZIPCode[] zF = zipFinder.GetZIPCodeInformation(zipCode);

                string Lat = zF[0].Latitude;
                string Lon = zF[0].Longitude;

                var task = googleapis(Lat, Lon);
                task.Wait();
                if(topPlaces.Length == 0)
                {
                    topPlaces = new String[1];
                    topPlaces[0] = "Zip Code is incorrect";
                }
                else
                {
                    int i = 0;
                    foreach (string s in topPlaces)
                    {
                        if (s == null)
                            topPlaces.ElementAt(i).Remove(i);
                        i++;
                    }
                }
                return topPlaces;
            }
            else
            {
                topPlaces = new String[1];
                topPlaces[0] = "Zip Code is in incorrect format";
                return topPlaces;
            }
                
        }
        public async Task googleapis(string Lat, string Lon)
        {
            SortedDictionary<string, double> displayDict = new SortedDictionary<string, double>();
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=400&key=AIzaSyCHOLDCkdwU7QOKgeDKlBUFmZSdUuOMy3o", Lat, Lon));
                var result = JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response);
                foreach (Result r in result.results)
                {
                    if (r.rating > 0.0)
                    {
                        string overall = r.name + ":" + r.vicinity;
                        displayDict.Add(overall, r.rating);
                    }
                }
            }
            var sortedEle = displayDict.OrderByDescending(kvp => kvp.Value);
            int i = 0;
            topPlaces = new String[sortedEle.Count()];
            foreach (var k in sortedEle)
            {
                topPlaces[i++] = k.Key;
            }
        }

    }
}
