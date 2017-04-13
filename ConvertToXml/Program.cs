using System;
using System.Xml;

namespace xml
{
    class Program
    {
        static void Main(string[] args)
        {
            //pliki Xml utowrzone w folderze bin>Debug

            Console.WriteLine("wprowadz zdanie");
            var sentens = Console.ReadLine();
            //Console.WriteLine(ConvertToXmlMethod1(sentens));
            System.IO.File.WriteAllText("ConvertToXmlMethod1.xml", ConvertToXmlMethod1(sentens));
            ConvertToXmlMethod2(sentens);
            Console.ReadKey();
        }

        public static string ConvertToXmlMethod1(string str)
        {
            string result;
            str = str.Replace(",", " ");
            var temp = str.Split();
            var title = ("<? xml version = \"1.0\" encoding = \"UTF - 8\" standalone = \"yes\" ?>\r\n");

            result =title;
            result+="<text>\r\n";
            result+="\t<sentence>\r\n";

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].IndexOf(".") == -1)
                {
                    result+="\t\t<word>" + temp[i] + "</word>\r\n";
                }
                else
                {
                    temp[i] = temp[i].Replace(".", "");
                    if (i == temp.Length - 1)
                    {
                        result+="\t\t<word>" + temp[i] + "</word>\r\n";
                        result+="\t</sentense>\r\n";
                        result+="</text>\r\n";
                    }
                    else
                    {
                        result += "\t\t<word>" + temp[i] + "</word>\r\n";
                        result += "\t</sentense>\r\n";
                        result += "\t<sentense>\r\n";
                    }
                }
            }
            return result;
        }

        public static void ConvertToXmlMethod2(string str)
        {
            str = str.Replace(",", " ");
            var temp = str.Split();

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes"); 
            doc.AppendChild(docNode); 

            XmlNode productsNode = doc.CreateElement("text");
            doc.AppendChild(productsNode);

            XmlNode productNode = doc.CreateElement("sentence");
            productsNode.AppendChild(productNode);

            XmlNode nameNode;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].IndexOf(".") == -1)
                {                    
                    nameNode = doc.CreateElement("word"); 
                    nameNode.AppendChild(doc.CreateTextNode(temp[i])); 
                    productNode.AppendChild(nameNode);
                }
                else
                {
                    temp[i] = temp[i].Replace(".", "");
                    if (i == temp.Length - 1)
                    {   nameNode = doc.CreateElement("word"); 
                        nameNode.AppendChild(doc.CreateTextNode(temp[i]));
                        productNode.AppendChild(nameNode);
                    }
                    else
                    {
                        nameNode = doc.CreateElement("word"); 
                        nameNode.AppendChild(doc.CreateTextNode(temp[i])); 
                        productNode.AppendChild(nameNode);

                        productNode = doc.CreateElement("sentence");
                        productsNode.AppendChild(productNode);
                    }
                }
            }
          //  doc.Save(Console.Out);
            doc.Save("ConvertToXmlMethod2.xml");    
        }
    }
}
