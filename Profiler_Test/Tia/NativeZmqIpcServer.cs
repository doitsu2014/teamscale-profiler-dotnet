using Cqse.Teamscale.Profiler.Commons.Ipc;
using ZeroMQ;

namespace Cqse.Teamscale.Profiler.Dotnet.Tia
{
    public class NativeZmqIpcServer : IpcServer
    {
        private readonly ZContext context = new ZContext();

        public NativeZmqIpcServer(IpcConfig config, RequestHandler requestHandler) : base(config, requestHandler)
        {
            // delegate to base class
        }

        override protected void StartRequestHandler()
        {
            using (var responseSocket = new ZSocket(this.context, ZSocketType.REP))
            {
                responseSocket.Bind(this.config.RequestSocket);
                while (true)
                {
                    using (ZFrame request = responseSocket.ReceiveFrame())
                    {
                        string response = this.requestHandler(request.ReadString());
                        responseSocket.Send(new ZFrame(response));
                    }
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this.context.Dispose();
        }
    }
}
