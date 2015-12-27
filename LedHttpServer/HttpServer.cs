using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedHttpServer
{
    public class HttpServer
    {
        private HttpListener httpListener;

        public int Port { get; private set; }


        public bool IsRunning
        {
            get { return httpListener.IsListening; }
        }


        public HttpServer(int port)
        {
            Initialize(port);
        }

        private void Initialize(int port)
        {
            Port = port;
            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://+:" + Port.ToString() + "/");
        }

        public void Start()
        {
            if (IsRunning)
            {
                return;
            }
            httpListener.Start();
            httpListener.BeginGetContext(Process, httpListener);
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            httpListener.Stop();
        }

        static void Process(IAsyncResult result)
        {
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;

                HttpListenerContext ctx = listener.EndGetContext(result);
                Console.WriteLine("url: " + ctx.Request.Url.AbsolutePath);

                ctx.Response.Close();
                Console.WriteLine("reqeust handling done.");
                listener.BeginGetContext(Process, listener);
            }
            catch (Exception)
            {

            }
        }
    }
}
