using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_9DataStructMVC.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = null;
            ViewBag.MyFatStack = null;
            ViewBag.MyClearStack = null;
            ViewBag.MyDisplayStack = null;
            ViewBag.MyDeleteStack = null;
            ViewBag.MySearchStack = null;
            ViewBag.StopWatchStack = null;
            return View("Stack");
        }

        int stackCount = 0;

        //Add one item to stack (works)
        public ActionResult Add()
        {
            stackCount = myStack.Count();
            myStack.Push("New entry #" + (stackCount + 1));
            ViewBag.MyStack = myStack.Peek() + " added";
            return View("Stack");
        }

        //add a bunch of items to stack (works)
        public ActionResult AddList()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                stackCount = myStack.Count();
                myStack.Push("New entry #" + (stackCount + 1));
            }
            ViewBag.MyFatStack = "2000 items added";
            return View("Stack");
        }

        //still under construction, prints each character individually for this stack is empty
        public ActionResult Display()
        {
            ViewBag.MyDisplayStack = myStack;
            
            return View("Stack");
        }

        //delete an item from stack (returns each char individually like display, but does delete. need to handle <0 error)
        public ActionResult Delete()
        {
            if (myStack.Count() > 0)
            {
                ViewBag.MyDeleteStack = myStack.Pop() + " has been deleted";
            }
            else
            {
                ViewBag.MyDeleteStack = "There is nothing in the stack to delete";
            }

            return View("Stack");
        }

        //clear entire stack
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyClearStack = "The stack has been cleared";
            return View("Stack");
        }

        //search for an item within stack
        public ActionResult Search()
        {
            if (myStack.Count() > 0)
            {

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();

                if (myStack.Contains("New entry #3"))
                {
                    ViewBag.MySearchStack = "New entry #3 found";
                }
                else
                {
                    ViewBag.MySearchStack = "New entry #3 not found";
                }

                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.StopWatchStack = ts;
            }
            else
            {
                ViewBag.MySearchStack = "There is nothing in the stack to search";
            }

            return View("Stack");
        }
    }
}
