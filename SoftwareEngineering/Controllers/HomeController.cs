using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using SoftwareEngineering.Models;

namespace SoftwareEngineering.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult GetView(string URL)
        {
            WebFetch wFetch = new WebFetch();
            GenericViewModel Model = new GenericViewModel();
            Model.DisplayString = wFetch.GetView(URL);
            return PartialView("RefreshView",Model);
        }

        class WebFetch
        {
            public string GetView(string URL)
            {

                StringBuilder sb = new StringBuilder();
                try
                {
                    // used on each read operation
                    byte[] buf = new byte[8192];

                    // prepare the web page we will be asking for
                    HttpWebRequest request = (HttpWebRequest)
                        WebRequest.Create(URL);

                    // execute the request
                    HttpWebResponse response = (HttpWebResponse)
                        request.GetResponse();

                    // we will read data via the response stream
                    Stream resStream = response.GetResponseStream();

                    string tempString = null;
                    int count = 0;

                    do
                    {
                        // fill the buffer with data
                        count = resStream.Read(buf, 0, buf.Length);

                        // make sure we read some data
                        if (count != 0)
                        {
                            // translate from bytes to ASCII text
                            tempString = Encoding.ASCII.GetString(buf, 0, count);

                            // continue building the string
                            sb.Append(tempString);
                        }
                    } while (count > 0); // any more data to read?}
                }
                catch (Exception ex)
                {
                }
                finally { }
                return sb.ToString();
            }

        }

        public ActionResult User()
        {
            return View();
        }
    }

}
