using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContractorFraudDetectionHackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Alex\Documents\Visual Studio 2017\DailyProgrammingTestFiles\decConFraudTest3.txt";
            //read through the file and parse the data
            // This text is added only once to the file.
            string[] fileLines = File.ReadAllLines(path);
            string [] fraud = findFraud(fileLines);
            foreach(string k in fraud)
            Console.WriteLine(k);
            Console.Read();
        }

        static string [] findFraud(string[] lines)
        {
            string vioShortend = "SHORTENED_JOB";
            string errorSusBatch = "SUSPICIOUS_BATCH";
            //use a dictionary to keep track of the location of where they logged their time.
            ////string is the name of the employee
            ////list is the list of numbers that they have entered the jobs at
            Dictionary<string, List<int>> userJobs = new Dictionary<string, List<int>>();
            
            //keep the last entry available for each name
            Dictionary<string, int> lastEntry = new Dictionary<string, int>();

            List<string> errorCodes = new List<string>();
            //list of the inputs
            ////string is the name
            ////bool is whether or not the job has ended
            ////long is the time entry
            List<string> name = new List<string>();
        List<bool> started = new List<bool>();
        List<long> entryTime = new List<long>();
        List<int> startLine = new List<int>();
        List<int> finishLines = new List<int>();

            //keep track of the lines
        int lineCounter = 0;
            //parse the string and load the items into their states
            foreach (string input in lines)
            {
                string[] tokens = input.Split(';');

                //start and add another item
                if (tokens[1].Contains("START"))
                {
                    ////check if name already exists and mark that another job has started
                    if (!userJobs.ContainsKey(tokens[0]))
                    {
                        //add a new starter job
                        List<int> inputLocations = new List<int>();
                        inputLocations.Add(name.Count());
                        //add the input location
                        userJobs.Add(tokens[0], inputLocations);
                        lastEntry.Add(tokens[0], 0);
                    }
                    else
                    {
                        //add the new line to the list of inputs
                        userJobs[tokens[0]].Add(name.Count());
                    }
                    //entryInformation newEntry = new entryInformation(tokens[0], false, 0, lineCounter);
                    //     userJobs.Add(tokens[0], 1);
                    name.Add(tokens[0]);
                    started.Add(false);
                    entryTime.Add(0);
                    startLine.Add(lineCounter);
                    finishLines.Add(0);
                    //logTimes.Add(newEntry);

                    // }
                }
                //singular entry
                //start must have already been called, 
                else
                {
                    //get all of the entries
                    string[] jobEntriesString = tokens[1].Split(',');
                    //keep track of the position when going through the entries
                    int i = lastEntry[tokens[0]];
                    foreach (string j in jobEntriesString)
                    {
                        Int64 num = Convert.ToInt64(j);

                        //mark and set the time
                        int logPosition = userJobs[tokens[0]].ElementAt(i);
                        //logTimes[logPosition].setEntryTime(num);
                        //do for other as well;
                        entryTime[logPosition] = num;
                        started[logPosition] = true;
                        finishLines[logPosition] = lineCounter;

                        //nest for each loop to determine whether or not it is a valid entry, only need to check finished inputs
                        //foreach (string s in userJobs.Keys)
                        //{
                        //    if (s != tokens[0])
                        //    {
                        //        foreach(int fraudVal in userJobs[s])
                        //        {
                        //            if(started[fraudVal])
                        //            {
                        //                //error
                        //                if(num < entryTime[fraudVal] && startLine[logPosition] > finishLines[fraudVal])
                        //                {
                        //                    lineCounter++;
                        //                    if(jobEntriesString.Length > 1)
                        //                    {
                        //                        errorSusBatch = lineCounter.ToString() + ";" + tokens[0]+ ";" + "SUSPICIOUS_BATCH";
                        //                        if(!errorCodes.Contains(errorSusBatch))
                        //                            errorCodes.Add(errorSusBatch);
                        //                    }
                        //                    else
                        //                    {
                        //                        int realStart = startLine[logPosition] + 1;
                        //                        vioShortend = realStart + ";" + tokens[0] + ";" + "SHORTENED_JOB";
                        //                        if (!errorCodes.Contains(vioShortend))
                        //                            errorCodes.Add(vioShortend);
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        foreach (string s in userJobs.Keys)
                        {
                            // if (s != tokens[0])
                            // {
                            foreach (int fraudVal in userJobs[s])
                            {
                                if (started[fraudVal])
                                {
                                    //error
                                    if (num < entryTime[fraudVal] && startLine[logPosition] > finishLines[fraudVal])
                                    {
                                        if (jobEntriesString.Length > 1)
                                        {
                                            int realStart = startLine[logPosition] + 1;
                                            errorSusBatch = realStart.ToString() + ";" + tokens[0] + ";" + "SUSPICIOUS_BATCH";
                                            if (!errorCodes.Contains(errorSusBatch))
                                                errorCodes.Add(errorSusBatch);
                                            else
                                            { 
}

                                        }
                                        else
                                        {
                                            int realStart = startLine[logPosition] + 1;
                                            vioShortend = realStart + ";" + tokens[0] + ";" + "SHORTENED_JOB";
                                            if (!errorCodes.Contains(vioShortend))
                                                errorCodes.Add(vioShortend);
                                        }
                                    }
                                }
                            }
                            //}
                        }

                        i++;
                        //report the error as shortened or a suspitious batch
                    }
                    lastEntry[tokens[0]] = i;
                }

                lineCounter++;
            }
            //determine if anyone finished a job without finishing// loop through in reverse since the last option should return nothing

            return errorCodes.ToArray();
        }
    }

    //quick class for entry information
    public class entryInformation
    {
        protected string name;
        protected bool started;
        protected long entryTime;
        protected int startLine;
        protected int finishLine;

        //contstructor
        public entryInformation(string name, bool started, long entryTime, int startLine)
        {
            this.name = name;
            this.started = started;
            this.entryTime = entryTime;
            this.startLine = startLine;
        }
        
        //getters
        public string getName()
        {
            return name;
        }
        public bool getStartBool()
        {
            return started;
        }
        public long getTime()
        {
            return entryTime;
        }
        public int getStartLineNum()
        {
            return startLine;
        }
        public int getFinishLine()
        {
            return finishLine;
        }

        //setters
        public void setName(string newName)
        {
            this.name = newName;
        }
        public void setStartBool(bool nStarted)
        {
            this.started = nStarted;
        }
        public void setEntryTime(long nEntryTime)
        {
            this.entryTime = nEntryTime;
        }
        public void setStartLineNum(int nLineNumber)
        {
            this.startLine = nLineNumber;
        }
        public void setFinishLineNum(int nLineNumber)
        {
            this.finishLine = nLineNumber;
        }
    }
}
