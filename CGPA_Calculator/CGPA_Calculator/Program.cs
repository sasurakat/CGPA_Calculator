using CGPA_Calculator;
using System;
using System.Collections.Generic;
using System.Threading;


namespace CGPA_Calculator
{

class Program
{
    static void Main(string[] args)
    {

            Animation.DisplayLoadingAnimation(0.25F);

            AppEntry entry = new AppEntry();
            entry.AppStart();
    }

   
}
}
