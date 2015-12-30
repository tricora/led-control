using System;
using System.Collections.Concurrent;
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

        private ConcurrentQueue<string> messageQueue;

        public int Port { get; private set; }


        public bool IsRunning
        {
            get { return httpListener.IsListening; }
        }


        public HttpServer(int port)
        {
            Initialize(port, new ConcurrentQueue<string>());
        }

        public HttpServer(int port, ConcurrentQueue<string> queue)
        {
            Initialize(port, queue);
        }

        private void Initialize(int port, ConcurrentQueue<string> queue)
        {
            messageQueue = queue;
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

        void Process(IAsyncResult result)
        {
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;

                HttpListenerContext ctx = listener.EndGetContext(result);
                messageQueue.Enqueue("test");
                ctx.Response.Close();
                listener.BeginGetContext(Process, listener);
            }
            catch (Exception)
            {

            }
        }

        //static void 
    }
}
