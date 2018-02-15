﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main()
        {
            WebClient client = new WebClient();
            /*
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                "http://kurser.iha.dk/eit/it-dkt1/test.htm");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            */        
            Stream dataStream = client.OpenRead("http://kurser.iha.dk/eit/it-dkt1/test.htm"); //response.GetResponseStream();
                                                     // Open the stream using a StreamReader for easy access.

            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.  
            reader.Close();
            //response.Close();
        }
    }
}