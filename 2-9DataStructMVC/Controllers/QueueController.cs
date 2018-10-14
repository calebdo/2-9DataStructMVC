using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_9DataStructMVC.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = null;
            ViewBag.MyFatQueue = null;
            ViewBag.MyClearQueue = null;
            ViewBag.MyDisplayQueue = null;
            ViewBag.MyDeleteQueue = null;
            ViewBag.MySearchQueue = null;
            ViewBag.StopWatchQueue = null;
            return View("Queue");
        }

        int queueCount = 0;

        //Add one item to Queue (works)
        public ActionResult Add()
        {
            queueCount = myQueue.Count();
            myQueue.Enqueue("New entry #" + (queueCount + 1));
            ViewBag.MyQueue = myQueue.Last() + " added";
            return View("Queue");
        }

        //add a bunch of items to Queue (works)
        public ActionResult AddList()
        {
            myQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                queueCount = myQueue.Count();
                myQueue.Enqueue("New entry #" + (queueCount + 1));
            }
            ViewBag.MyFatQueue = "2000 items added";
            return View("Queue");
        }

        //displays queue
        public ActionResult Display()
        {
            ViewBag.MyDisplayQueue = myQueue;

            return View("Queue");
        }

        //delete an item from Queue
        public ActionResult Delete()
        {
            if (myQueue.Count() > 0)
            {
                ViewBag.MyDeleteQueue = myQueue.Dequeue() + " has been deleted";
            }
            else
            {
                ViewBag.MyDeleteQueue = "There is nothing in the queue to delete";
            }

            return View("Queue");
        }

        //clear entire Queue
        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.MyClearQueue = "The queue has been cleared";
            return View("Queue");
        }

        //search for an item within Queue
        public ActionResult Search()
        {
            if (myQueue.Count() > 0)
            {

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();

                if (myQueue.Contains("New entry #3"))
                {
                    ViewBag.MySearchQueue = "New entry #3 found";
                }
                else
                {
                    ViewBag.MySearchQueue = "New entry #3 not found";
                }

                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.StopWatchQueue = ts;
            }
            else
            {
                ViewBag.MySearchQueue = "There is nothing in the queue to search";
            }

            return View("Queue");
        }

    }
}