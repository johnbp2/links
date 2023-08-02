using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AngleSharp.Html.Dom;

namespace Links.App
{
    public static class DocumentParserFacade
    {
        public static bool IsValidSavePath(string path)
        {
            return IsValidPath(path, false);
        }

        public static bool IsValidWebPageFileExtension(string path)
        {
            return IsValidPath(path, true);
            
        }

        //public static void test()
        //{
        //System.IO.Path.GetFileName()
        //}
        private static bool IsValidPath(string path, bool fileShouldExist)
        {

            if (path == null)
            {
                return false;
            }
            if (!Path.Exists(path))
            {

                return false;
            }
            else
            {
                if (fileShouldExist)
                {

                    try
                    {
                        var file = new FileInfo(path);
                        if (!file.Exists)
                        {

                            return false;
                        }
                        else
                        {

                            if (file.Extension == ".html" || file.Extension == ".htm")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // throw ex;
                        return false;
                    }

                }
                else
                {
                    //it's a valid path to a directory thats allm we care about
                    return true;
                }

            }

        }


        private static string getFileContents(string path)
        {
            return File.ReadAllText(path);

          
        }


        private static IHtmlDocument AngleSharpParse(string filePath)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(getFileContents(filePath));
            return document;
        }


        public static IEnumerable<Tuple<string, string>> ProcessDocumentNodes(string filePath, out IHtmlCollection<IElement> hrefs )
        {
            var hrefTags = new List<Tuple<string, string>>();
            var document = DocumentParserFacade.AngleSharpParse(filePath);    
            hrefs = document.QuerySelectorAll("a");
            foreach (IElement element in document.QuerySelectorAll("a"))
            {
                var t = new Tuple<string, string>(element.InnerHtml, element.GetAttribute("href")?? "");

                hrefTags.Add(t);
            }

            return hrefTags;
        }


        public static IHtmlAllCollection?  GetNodes(string filePath)
        {
            var doc = DocumentParserFacade.AngleSharpParse(filePath);
            return doc.All;
        }
    }
}
