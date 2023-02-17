using System;
using System.Xml;
using MonoAstroids;


namespace MyAstroids
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            object testPlanet = new LevelMyAstroids();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            //using (XmlWriter xmlWriter = XmlWriter.Create("test.xml", xmlSettings))
            //{
            //    IntermediateSerializer.Serialize(xmlWriter, testPlanet, null);
            //}


            using (Game1 game = new Game1())
            {
                game.Run();
            }

            

        }
    }
}

