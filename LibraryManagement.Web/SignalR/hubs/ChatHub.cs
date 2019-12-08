using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

namespace LibraryManagement.Web.Controllers
{
    public class ChatHub : Hub
    {
        private OrderController orderController =  DependencyResolver.Current.GetService<OrderController>();

        public void Send(string orderId, string name, string message)
        {
            var group = Clients.Group(orderId);

            // Send message to clients
            group.addNewMessageToPage(name, message);

            //Save message in DB
            orderController.AddMessage(int.Parse(orderId), message);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.Add(Context.ConnectionId, roomName);
        }
    }
}