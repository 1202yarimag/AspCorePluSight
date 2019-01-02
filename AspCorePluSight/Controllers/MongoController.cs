using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AspCorePluSight.Models;
using AspCorePluSight.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;


namespace AspCorePluSight.Controllers
{
    public class MongoController : Controller
    {
        private IMongoDatabase mongoDatabase;
        private IConfiguration _configuration;
        private IMongo _mongo;

        public MongoController(IMongo mongo, IConfiguration configuration)
        {
            _configuration = configuration;
            _mongo = mongo;
        }
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            return mongoClient.GetDatabase("CustomerDb");

        }

        public IActionResult Index()
        {
            //Election.Person person = null;
            //string path = @"C:\Users\hyarimaga\Desktop\New folder\new.xml";

            //XmlSerializer serializer = new XmlSerializer(typeof(Election.Person));

            //StreamReader reader = new StreamReader(path);
            //person = (Election.Person)serializer.Deserialize(reader);
            //reader.Close();


            //_mongo.addPerson(person);

            //Deputy.milletvekili milletvekili = null;
            //string path = @"C:\Users\hyarimaga\Downloads\Secim Son\Secim Son\aday.xml";

            //XmlSerializer serializer = new XmlSerializer(typeof(Deputy.milletvekili));

            //StreamReader reader = new StreamReader(path);
            //milletvekili = (Deputy.milletvekili)serializer.Deserialize(reader);
            //reader.Close();

            //foreach (var item in milletvekili.aday)
            //{
            //    _mongo.addDeputy(item);
            //}

            //_mongo.addPerson(person);

            //AASecimBolge.AA  secim = null;
            //string path = @"C:\Users\hyarimaga\Downloads\Secim Son\Secim Son\AA_MVSecimi2018_SecimCevresi.xml";

            //XmlSerializer serializer = new XmlSerializer(typeof(AASecimBolge.AA));

            //StreamReader reader = new StreamReader(path);
            //secim = (AASecimBolge.AA)serializer.Deserialize(reader);
            //reader.Close();

            //foreach (var item in secim.TurkiyeGeneli.PartiSonuclari)
            //{
            //    _mongo.AddIttifak(item);
            //}

            return View(_mongo.GetData());
        }
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //Get the database connection
            //mongoDatabase = GetMongoDatabase();
            //fetch the details from CustomerDB and pass into view
            //Customer customer = mongoDatabase.GetCollection<Customer>("Customers").Find<Customer>(k => k.CustomerId == id).FirstOrDefault();
            var customer = _mongo.Get(Convert.ToInt16(id));

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerEdit customerEdit)
        {
            

            var customer = new Customer();
            customer.CustomerName = customerEdit.CustomerName;
            customer.Address = customerEdit.Address;
            _mongo.Add(customer);
            return View("Details",customer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null)
                return NotFound();
           
            mongoDatabase = GetMongoDatabase();
            var customer = mongoDatabase.GetCollection<Customer>("Customers").Find<Customer>(k => k.CustomerId == id).FirstOrDefault();
            if (customer == null)
                return NotFound();


            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            _mongo.Edit(customer);
            //return RedirectToAction("Index");

            return View("Details",customer);
        }
        public IActionResult Delete(int id)
        {

            if (id==null)
            {
                return NotFound();
            }
           var result= _mongo.Delete(id);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else return NotFound();

           

        }

    }
}