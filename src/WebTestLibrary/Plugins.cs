using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace WebTestLibrary
{
    /* Strings generator for using with web/performance tests in Visual Studio:
        {{RANDOM_STRING}} – 5-character string, e.g. "IBRWU"
        {{RANDOM_NUM_STRING}} – 4-character numeric string, e.g. "3180"
        {{NEW_GUID}} - UUID4
        {{TIME_STAMP}} – timestamp, e.g. "13.07.2016 12:12:44:150"
        {{TIME_STAMP_SQL}} - SQL timestamp, e.g. "2016-07-13T12:12:44"
        {{DATE}} - short date in DD.MM.YYYY format 
        {{UNIXTIME}} - Unix timestamp (milliseconds since 1970-01-01)
    */

    public class StringGenerator : WebTestPlugin
    {
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            //Random rand = new Random();
            e.WebTest.Context["RANDOM_STRING"] = GetRandomString(5);
            e.WebTest.Context["RANDOM_NUM_STRING"] = GetRandomNumberString(4);
            e.WebTest.Context["NEW_GUID"] = GetNewGuid();
            e.WebTest.Context["TIME_STAMP"] = GetTimeStamp();
            e.WebTest.Context["TIME_STAMP_SQL"] = GetDateTimeSQL();
            e.WebTest.Context["DATE"] = GetDate();
            e.WebTest.Context["UNIXTIME"] = GetUnixTime();
        }

        protected string GetRandomString(int length)
        {
            Random rand = new Random();
            char[] charArray = new char[length];

            for (int i = 0; i < length; i++)
            {
                charArray[i] = (char)rand.Next(65, 90);
            }
            return new string(charArray);
        }

        protected string GetRandomNumberString(int length)
        {
            Random rand = new Random();
            char[] charArray = new char[length];

            for (int i = 0; i < length; i++)
            {
                charArray[i] = (char)rand.Next(48, 57);
            }
            return new string(charArray);
        }

        protected Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        protected string GetTimeStamp()
        {
            DateTime dt = DateTime.Now;
            return dt.ToShortDateString() + " " + dt.ToLongTimeString() + ":" + dt.Millisecond;
        }

        protected string GetDateTimeSQL()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        protected string GetDate()
        {
            DateTime dt = DateTime.Now;
            return dt.ToShortDateString();
        }

        protected string GetUnixTime()
        {
            long unixTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return unixTime.ToString();
        }
    }
}
