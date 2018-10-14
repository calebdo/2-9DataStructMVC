using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_9DataStructMVC.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDict = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDict = null;
            ViewBag.MyFatDict = null;
            ViewBag.MyClearDict = null;
            ViewBag.MyDisplayDict = null;
            ViewBag.MyDeleteDict = null;
            ViewBag.MySearchDict = null;
            ViewBag.StopWatchDict = null;
            return View("Dictionary");
        }


        int dictCount = 0;

        //Add one item to Dictionary (works)
        public ActionResult Add()
        {
            dictCount = myDict.Count();
            myDict.Add(dictCount+1, "New entry #" + (dictCount + 1));
            ViewBag.MyDict = myDict.Last() + " added";
            return View("Dictionary");
        }

        //add a bunch of items to Dictionary (works)
        public ActionResult AddList()
        {
            myDict.Clear();
            for (int i = 0; i < 2000; i++)
            {
                dictCount = myDict.Count();
                myDict.Add(dictCount+1, "New entry #" + (dictCount + 1));
            }
            ViewBag.MyFatDict = "2000 items added";
            return View("Dictionary");
        }

        //displays Dictionary
        public ActionResult Display()
        {
            ViewBag.MyDisplayDict = myDict;

            return View("Dictionary");
        }

        //delete an item from Dictionary
        public ActionResult Delete()
        {
            if (myDict.Count() > 0)
            {
                myDict.Remove(myDict.Count());
                ViewBag.MyDeleteDict = "An item has been deleted";
            }
            else
            {
                ViewBag.MyDeleteDict = "There is nothing in the Dictionary to delete";
            }

            return View("Dictionary");
        }

        //clear entire Dictionary
        public ActionResult Clear()
        {
            myDict.Clear();
            ViewBag.MyClearDict = "The Dictionary has been cleared";
            return View("Dictionary");
        }

        //search for an item within Dictionary
        public ActionResult Search()
        {
            if (myDict.Count() > 0)
            {

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();

                if (myDict.ContainsKey(3))
                {
                    ViewBag.MySearchDict = "New entry #3 found";
                }
                else
                {
                    ViewBag.MySearchDict = "New entry #3 not found";
                }

                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.StopWatchDict = ts;
            }
            else
            {
                ViewBag.MySearchDict = "There is nothing in the Dictionary to search";
            }

            return View("Dictionary");
        }

    }
}