using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AspCorePluSight.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePluSight.Controllers
{
    public class DeserialiseController : Controller
    {
        public IActionResult Index()
        {
           Election.Person person = null;
            string path = @"C:\Users\hyarimaga\Desktop\New folder\new.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Election.Person));

            StreamReader reader = new StreamReader(path);
            person = (Election.Person)serializer.Deserialize(reader);
            reader.Close();
            
            return View(person);

        }
    }
}