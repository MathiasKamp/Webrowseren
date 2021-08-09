using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Webrowseren
{
    /// <summary>
    /// WebRequester class has the purpose of requesting a webpage and returns its content
    /// </summary>
    public class WebRequester
    {
        /// <summary>
        /// New instance of the ConfigCollector class 
        /// </summary>
        private ConfigCollector Config { get; } = new ConfigCollector();

        /// <summary>
        /// Method GetWebPage is an async task that gets the webpage content with or without html tags but it depends on what has been written in the app.config
        /// </summary>
        public async Task GetWebPage()
        {
            try
            {
                // new instance of HttpClient
                var client = new HttpClient();
                // collect the webpage from the app.config
                var webPage = Config.GetWebPage();
                // collect the value if the user wants with or without html tags
                var withoutHtml = Config.GetWithOutHtml();
                // get the webpage
                var response = client.GetAsync(webPage).Result;
                // ensure that we get a successStatusCode (200)
                response.EnsureSuccessStatusCode();
                // store the content of the webpage's body in a string
                var responseBody = await response.Content.ReadAsStringAsync();
                
                // check if withoutHtml is true
                if (withoutHtml)
                {
                    // run the method removeHtmlTags on the string content of the webpage
                    var stringWithoutHtml = RemoveHtmlTags(responseBody);
                    // write the string to a file
                    WriteHTMLToFile(stringWithoutHtml);
                }

                else
                {
                    // if withoutHtml is false we write the full body content to the file.
                    WriteHTMLToFile(responseBody);
                }
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        
        /// <summary>
        /// method WriteHtmlToFile has the purpose of writing a string of html to a file
        /// </summary>
        
        private void WriteHTMLToFile(string html)
        {
            try
            {
                // folder to store the file
                var path = @".\HtmlRequest";
                // folder and file name
                var pathAndFile = path + @"\htmlFile.html";
                // create the folder if it dosn't exists
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                // new instance of streamWriter that writes to the new file.
                var sw = new StreamWriter(pathAndFile,true);

                // write the string of html to the fle
                sw.WriteLine(html);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        /// <summary>
        /// Method RemoveHtmlTags has the purpose of removing all html tags from the string
        /// </summary>
        /// <returns>pageWithOutHtml</returns>
        public string RemoveHtmlTags(string html)
        {
            string pageWithOutHtml = null;
            try
            {
                // using regex to replace all html tags with an empty string.
               pageWithOutHtml = Regex.Replace(html, "<.*?>", String.Empty);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
    
            return pageWithOutHtml;
        }
    }
}