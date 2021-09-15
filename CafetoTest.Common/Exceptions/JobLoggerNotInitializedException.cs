﻿using System;

namespace CafetoTest.Common.Exceptions
{
    public class JobLoggerNotInitializedException : Exception
    {
        public JobLoggerNotInitializedException() : base("You must create an instance of JobLogger to configure it.")
        {

        }
    }
}