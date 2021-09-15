using CafetoTest.Common.Interfaces;
using CafetoTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using static CafetoTest.Common.Enums.DestinationEnum;
using static CafetoTest.Common.Enums.LogTypeEnum;

namespace CafetoTest
{
    public class JobLogger : IJobLogger
    {
        public void LogMessage(IEnumerable<Destination> destinations, LogType type, string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    throw new Exception(ValidationMessages.ValidateEmptyText);
                }

                text = $"[{DateTime.Now.ToShortDateString()}] [{type}] {text}";

                foreach (Destination destination in destinations)
                {
                    switch (destination)
                    {
                        case Destination.File:
                            string basePath = ConfigurationManager.AppSettings.Get("LogFileDirectory")?.ToString();

                            string path =
                                Path.Combine(string.IsNullOrEmpty(basePath) ? Environment.CurrentDirectory : basePath,
                                    $"LogFile {DateTime.Now.ToShortDateString().Replace("/", ".")}.txt");

                            using (StreamWriter writer = new StreamWriter(path, File.Exists(path)))
                            {
                                writer.WriteLine(text);
                                writer.Close();
                            }
                            break;

                        case Destination.Console:
                            Console.WriteLine(text);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}